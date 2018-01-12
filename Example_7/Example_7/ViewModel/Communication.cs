using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example_7.ViewModel
{
    public class Communication:ViewModelBase
    {
        private Socket serverSocket, clientSocket;
        private int port = 10100;
        private Action<byte[]> Informer;
        private byte[] buffer = new byte[512];
        public bool ActAsServer { get { return serverSocket == null; } }

        public Communication(bool isServer, Action<byte[]> informer)
        {
            this.Informer = informer;

            if (isServer)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, port));
                serverSocket.Listen(5);
                Task.Factory.StartNew(StartAccepting);
            }
            else
            {
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Loopback, port));
                clientSocket = client.Client;
                Task.Factory.StartNew(Receive);
            }
        }

        private void StartAccepting()
        {
            clientSocket = serverSocket.Accept();
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while (true)
            {
                clientSocket.Receive(buffer);
                informer(buffer);
            }
        }
    }
}
