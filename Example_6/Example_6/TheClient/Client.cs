using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_6.TheClient
{
    public class Client
    {
        private string ip;
        private int port;
        private Action<string> newMessageReceived;

        byte[] buffer = new byte[512];

        Thread receivingThread;
        Socket clientSocket;

        public Client(string ip, int port, Action<string> newMessageReceived)
        {
            this.ip = ip;
            this.port = port;
            this.newMessageReceived = newMessageReceived;
            TcpClient client = new TcpClient();
            
            client.Connect(IPAddress.Parse(ip), port);

            clientSocket = client.Client;

            StartReceiving();
        }

        private void StartReceiving()
        {
            receivingThread = new Thread(new ThreadStart(Receive));
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void Receive()
        {
            string message = "";

            while (receivingThread.IsAlive)
            {
                int length = clientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                newMessageReceived(message);
            }
        }
    }
}
