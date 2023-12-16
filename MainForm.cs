using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Serial_Ports
{
    public interface IView
    {
        void SetController(IController controller);
        void OpenComEvent(Object sender, SerialPortEventArgs e);
        void CloseComEvent(Object sender, SerialPortEventArgs e);
        void ComReceiveDataEvent(Object sender, SerialPortEventArgs e);

        void TcpServerStopEvent(Object sender, TcpServerEventArgs e);
        void TcpServerStartEvent(Object sender, TcpServerEventArgs e);
        void TcpServerReceiveDataEvent(Object sender, TcpServerEventArgs e);
    }

    public partial class MainForm : Form, IView
    {
        //SerialPortModel serialPort = new SerialPortModel();
        //ServerTCPModel serverTCP = new ServerTCPModel();
        ToolModel toolModel = new ToolModel();

        private IController controller;

        private int rxBytesCount;
        private int txBytesCount;

        public MainForm()
        {
            InitializeComponent();
            initcom();
        }

        private void initcom()
        {
            //BaudRate
            int[] baudRate = { 4800, 9600, 19200, 38400, 57600, 115200 };

            for (int i = 0; i < baudRate.Length; i++)
            {
                baudRate_cbx.Items.Add(baudRate[i]);
            }

            baudRate_cbx.SelectedIndex = 5;

            //Data bits

            int[] dataBits = { 7, 8 };

            for (int i = 0; i < dataBits.Length; i++)
            {
                dataBits_cbx.Items.Add(dataBits[i]);
            }

            dataBits_cbx.SelectedIndex = 1;

            //Stop bits

            string[] stopBits = { "One", "Two" };

            for (int i = 0; i < stopBits.Length; i++)
            {
                stopBits_cbx.Items.Add(stopBits[i]);
            }

            stopBits_cbx.SelectedIndex = 0;

            //Parity

            string[] parity = { "None", "Even", "Mark", "Odd", "Space" };

            for (int i = 0; i < parity.Length; i++)
            {
                parity_cbx.Items.Add(parity[i]);
            }

            parity_cbx.SelectedIndex = 0;


            //Com Ports
            string[] ArrayComPortsNames = SerialPort.GetPortNames();
            if (ArrayComPortsNames.Length == 0)
            {
                status_lbl.Text = "No COM found !";
                open_btn.Enabled = false;
            }
            else
            {
                Array.Sort(ArrayComPortsNames);
                for (int i = 0; i < ArrayComPortsNames.Length; i++)
                {
                    comlist_cbx.Items.Add(ArrayComPortsNames[i]);
                }
                comlist_cbx.Text = ArrayComPortsNames[0];
                open_btn.Enabled = true;
            }

        }

        public void TcpServerStopEvent(Object sender, TcpServerEventArgs e)
        {

        }
        public void TcpServerStartEvent(Object sender, TcpServerEventArgs e)
        {

        }
        public void TcpServerReceiveDataEvent(Object sender, TcpServerEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Object, TcpServerEventArgs>(TcpServerReceiveDataEvent), sender, e);
                    Thread.Sleep(20);
                }
                catch (Exception ex)
                {
                    status_lbl.Text = ex.Message;
                }
                return;
            }

            controller.SerialDataSend(e.ReceivedBytes);
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public async void OpenComEvent(Object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<Object, SerialPortEventArgs>(OpenComEvent), sender, e);
                return;
            }

            if (e.isOpend)  //Open successfully
            {
                status_lbl.Text = comlist_cbx.Text + " Opend";
                open_btn.Text = "Close";
                comlist_cbx.Enabled = false;
                baudRate_cbx.Enabled = false;
                dataBits_cbx.Enabled = false;
                stopBits_cbx.Enabled = false;
                parity_cbx.Enabled = false;
                refresh_btn.Enabled = false;

                send_btn.Enabled = true;
            }
            else    //Open failed
            {
                status_lbl.Text = "Open failed !";
            }
        }

        public void CloseComEvent(Object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<Object, SerialPortEventArgs>(CloseComEvent), sender, e);
                return;
            }

            if (!e.isOpend) //close successfully
            {
                status_lbl.Text = comlist_cbx.Text + " Closed";
                open_btn.Text = "Open";
                comlist_cbx.Enabled = true;
                baudRate_cbx.Enabled = true;
                dataBits_cbx.Enabled = true;
                stopBits_cbx.Enabled = true;
                parity_cbx.Enabled = true;
                refresh_btn.Enabled = true;
            }
        }


        public void ComReceiveDataEvent(Object sender, SerialPortEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Object, SerialPortEventArgs>(ComReceiveDataEvent), sender, e);
                    Thread.Sleep(20);
                }
                catch (Exception ex)
                {
                    status_lbl.Text = ex.Message;
                }
                return;
            }

            rxBytesCount += e.receivedBytes.Length;
            rx_label.Text = $"RX: {rxBytesCount}";

            controller.ServerDataSend(e.receivedBytes);

        }

        private async void open_btn_Click(object sender, EventArgs e)
        {
            if (open_btn.Text == "Open")
            {
                try
                {
                    controller.SerialOpen(comlist_cbx.Text, baudRate_cbx.Text, dataBits_cbx.Text, stopBits_cbx.Text, parity_cbx.Text, "None");
                    await controller.ServerStart(4005);
                }
                catch (Exception ex)
                {
                    status_lbl.Text = ex.Message;
                }

            }
            else
            {
                controller.SerialClose();
                controller.ServerStop();
            }
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            //byte[] data = toolModel.Hex2Bytes("HELLO WORLD!\r\n");

            //txBytesCount += data.Length;
            //tx_label.Text = $"TX: {txBytesCount}";

            controller.SerialDataSend("HELLO WORLD!\r\n");
        }
    }
}
