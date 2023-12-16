using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.ComponentModel;
using System.Threading;

namespace Network_Serial_Ports
{
    public delegate void SerialPortEventHandler(Object sender, SerialPortEventArgs e);

    public class SerialPortEventArgs : EventArgs
    {
        public bool isOpend = false;
        public Byte[] receivedBytes = null;
    }

    public class SerialPortModel
    {
        private SerialPort sp = new SerialPort();

        public event SerialPortEventHandler comReceiveDataEvent = null;
        public event SerialPortEventHandler comOpenEvent = null;
        public event SerialPortEventHandler comCloseEvent = null;

        private Object thisLock = new Object();

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp.BytesToRead <= 0)
            {
                return;
            }

            lock (thisLock)
            {
                int len = sp.BytesToRead;
                Byte[] data = new Byte[len];
                try
                {
                    sp.Read(data, 0, len);
                }
                catch (System.Exception)
                {
                    //catch read exception
                }
                SerialPortEventArgs args = new SerialPortEventArgs();
                args.receivedBytes = data;
                if (comReceiveDataEvent != null)
                {
                    comReceiveDataEvent.Invoke(this, args);

                }
            }
        }

        public bool DataSend(Byte[] bytes)
        {
            if (!sp.IsOpen)
            {
                return false;
            }

            try
            {
                sp.Write(bytes, 0, bytes.Length);
            }
            catch (System.Exception)
            {
                return false;   //write failed
            }
            return true;        //write successfully
        }


        public void Open(string portName, String baudRate,
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
                //Never delete this property
                sp.RtsEnable = true;
                sp.DtrEnable = true;
            }

            SerialPortEventArgs args = new SerialPortEventArgs();
            try
            {
                sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                sp.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                sp.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake);
                sp.WriteTimeout = 1000; /*Write time out*/
                sp.Open();
                sp.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                args.isOpend = true;
            }
            catch (System.Exception)
            {
                args.isOpend = false;
            }
            if (comOpenEvent != null)
            {
                comOpenEvent.Invoke(this, args);
            }

        }

        public void Close()
        {
            Thread closeThread = new Thread(new ThreadStart(CloseSpThread));
            closeThread.Start();
        }
        private void CloseSpThread()
        {
            SerialPortEventArgs args = new SerialPortEventArgs();
            args.isOpend = false;
            try
            {
                sp.Close();
                sp.DataReceived -= new SerialDataReceivedEventHandler(DataReceived);
            }
            catch (Exception)
            {
                args.isOpend = true;
            }
            if (comCloseEvent != null)
            {
                comCloseEvent.Invoke(this, args);
            }

        }

    }
}
