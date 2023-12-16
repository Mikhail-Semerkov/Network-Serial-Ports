using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network_Serial_Ports
{
    public delegate void TcpServerEventHandler(object sender, TcpServerEventArgs e);

    public class TcpServerEventArgs : EventArgs
    {
        public bool IsListening { get; set; }
        public byte[] ReceivedBytes { get; set; }
    }

    public class ServerTCPModel
    {
        private TcpListener tcpListener;
        private List<TcpClient> connectedClients = new List<TcpClient>();

        public event TcpServerEventHandler TcpServerReceiveDataEvent;
        public event TcpServerEventHandler TcpServerStartEvent;
        public event TcpServerEventHandler TcpServerStopEvent;

        public ServerTCPModel()
        {
            tcpListener = null;
        }

        private async Task ListenForClientsAsync()
        {
            try
            {
                while (true)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();

                    connectedClients.Add(client); // Добавляем клиента в список подключенных

                    await Task.Run(async () =>
                    {
                        NetworkStream networkStream = client.GetStream();

                        while (client.Connected)
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);

                            if (bytesRead == 0)
                            {
                                // Клиент отключился
                                break;
                            }

                            byte[] data = new byte[bytesRead];
                            Array.Copy(buffer, data, bytesRead);

                            TcpServerEventArgs args = new TcpServerEventArgs();
                            args.ReceivedBytes = data;

                            TcpServerReceiveDataEvent?.Invoke(this, args);
                            await Console.Out.WriteLineAsync("OK");
                        }

                        // Клиент отключился, удаляем его из списка
                        connectedClients.Remove(client);
                        client.Close();
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке клиента: {ex.Message}");
            }
        }

        public async Task StartAsync(int port)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();

                TcpServerEventArgs args = new TcpServerEventArgs
                {
                    IsListening = true
                };

                TcpServerStartEvent?.Invoke(this, args);

                await ListenForClientsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запуске сервера: {ex.Message}");
            }
        }

        public void Stop()
        {
            try
            {
                if (tcpListener != null)
                {
                    tcpListener.Stop();
                }

                // Закрываем все подключенные клиенты
                foreach (TcpClient client in connectedClients)
                {
                    client.Close();
                }

                TcpServerEventArgs args = new TcpServerEventArgs
                {
                    IsListening = false
                };

                TcpServerStopEvent?.Invoke(this, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при остановке сервера: {ex.Message}");
            }
        }



        public bool SendToAllClients(byte[] data)
        {
            foreach (TcpClient client in connectedClients)
            {
                try
                {
                    NetworkStream networkStream = client.GetStream();
                    networkStream.Write(data, 0, data.Length);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при отправке данных клиенту: {ex.Message}");
                    return false;
                }
            }

            return true;
        }
    }
}
