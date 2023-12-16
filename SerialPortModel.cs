using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Network_Serial_Ports
{
    public delegate void SerialPortEventHandler(object sender, SerialPortEventArgs e);

    public class SerialPortEventArgs : EventArgs
    {
        public bool IsOpen { get; set; }
        public byte[] ReceivedBytes { get; set; }
    }

    public class SerialPortModel : IDisposable
    {
        private SerialPort sp = new SerialPort();

        public event SerialPortEventHandler ComReceiveDataEvent;
        public event SerialPortEventHandler ComOpenEvent;
        public event SerialPortEventHandler ComCloseEvent;

        public bool IsOpen => sp.IsOpen;

        public List<string> ScanSerialPorts() => new List<string>(SerialPort.GetPortNames());

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp.BytesToRead <= 0) return;

            var args = new SerialPortEventArgs();

            try
            {
                int len = sp.BytesToRead;
                var buff = new byte[len];
                sp.Read(buff, 0, len);

                args.ReceivedBytes = buff;

                ComReceiveDataEvent?.Invoke(this, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                args.IsOpen = false;
                ComCloseEvent?.Invoke(this, args);
            }
        }

        public bool DataSend(byte[] bytes)
        {
            if (!sp.IsOpen) return false;

            try
            {
                sp.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Open(string portName, string baudRate,
            string dataBits, string stopBits, string parity,
            string handshake)
        {
            if (sp.IsOpen)
            {
                Close();
            }

            sp.PortName = portName;
            sp.BaudRate = Convert.ToInt32(baudRate);
            sp.DataBits = Convert.ToInt16(dataBits);

            if (handshake == "None")
            {
                sp.RtsEnable = true;
                sp.DtrEnable = true;
            }

            var args = new SerialPortEventArgs();
            try
            {
                sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                sp.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                sp.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake);
                sp.WriteTimeout = 1000;
                sp.Open();
                sp.DataReceived += DataReceived;
                args.IsOpen = true;
            }
            catch (Exception)
            {
                args.IsOpen = false;
            }
            ComOpenEvent?.Invoke(this, args);
        }

        public void Close()
        {
            var closeThread = new Thread(CloseSpThread);
            closeThread.Start();
        }

        private void CloseSpThread()
        {
            var args = new SerialPortEventArgs { IsOpen = false };
            try
            {
                sp.Close();
                sp.DataReceived -= DataReceived;
            }
            catch (Exception)
            {
                args.IsOpen = true;
            }
            ComCloseEvent?.Invoke(this, args);
        }

        public void Dispose()
        {
            sp.Dispose();
        }
    }
}