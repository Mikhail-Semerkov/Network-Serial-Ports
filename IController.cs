using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Timers;
using Network_Serial_Ports;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Network_Serial_Ports
{

    public class IController
    {
        SerialPortModel SerialPortModel = new SerialPortModel();
        ServerTCPModel SeverTCPModel = new ServerTCPModel();
        IView view;

        public IController(IView view)
        {
            this.view = view;
            view.SetController(this);
            SerialPortModel.comCloseEvent += new SerialPortEventHandler(view.CloseComEvent);
            SerialPortModel.comOpenEvent += new SerialPortEventHandler(view.OpenComEvent);
            SerialPortModel.comReceiveDataEvent += new SerialPortEventHandler(view.ComReceiveDataEvent);

            SeverTCPModel.TcpServerStopEvent += new TcpServerEventHandler(view.TcpServerStopEvent);
            SeverTCPModel.TcpServerStartEvent += new TcpServerEventHandler(view.TcpServerStartEvent);
            SeverTCPModel.TcpServerReceiveDataEvent += new TcpServerEventHandler(view.TcpServerReceiveDataEvent);
        }


        public bool SerialDataSend(Byte[] data)
        {
            return SerialPortModel.DataSend(data);
        }

        public bool SerialDataSend(String str)
        {
            if (str != null && str != "")
            {
                return SerialPortModel.DataSend(Encoding.Default.GetBytes(str));
            }
            return true;
        }

        public void SerialOpen(string portName, String baudRate,
            string dataBits, string stopBits, string parity, string handshake)
        {
            if (portName != null && portName != "")
            {
                SerialPortModel.Open(portName, baudRate, dataBits, stopBits, parity, handshake);
            }
        }

        public void SerialClose()
        {
            SerialPortModel.Close();
        }



        public async Task ServerStart(int port)
        {
            await SeverTCPModel.StartAsync(port);
        }

        public void ServerStop()
        {
            SeverTCPModel.Stop();
        }

        public bool ServerDataSend(Byte[] data)
        {
            return SeverTCPModel.SendToAllClients(data);
        }

        public bool ServerDataSend(String str)
        {
            if (str != null && str != "")
            {
                return SeverTCPModel.SendToAllClients(Encoding.Default.GetBytes(str));
            }
            return true;
        }
    }
}
