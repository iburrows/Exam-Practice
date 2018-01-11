using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_6.TheServer
{
    public class Server
    {
        private string ip;
        private int port;
        private Action<string> NewMessageReceived;
        private Socket serverSocket;
        Thread acceptingThread;

        List<ClientHandler> clients = new List<ClientHandler>();

        public Server(string ip, int port, Action<string> newMessageReceived)
        {
            this.ip = ip;
            this.port = port;
            this.NewMessageReceived = newMessageReceived;

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serverSocket.Listen(5);
            StartAccepting();
        }

        private void StartAccepting()
        {
            acceptingThread = new Thread(new ThreadStart(Accept));
            acceptingThread.IsBackground = true;
            acceptingThread.Start();
        }

        private void Accept()
        {
            try
            {
                while (acceptingThread.IsAlive)
                {
                    clients.Add(new ClientHandler(serverSocket.Accept()));
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Send(string message)
        {
            NewMessageReceived(message);

            foreach (var item in clients)
            {
                item.Send(message);
            }
        }
    }
}
