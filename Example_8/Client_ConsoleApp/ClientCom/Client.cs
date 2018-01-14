using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_ConsoleApp.ClientCom
{
    public class Client
    {
        Socket socket;

        public Client()
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Loopback, 10100);
            socket = client.Client;
        }

        public void Send(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void Close()
        {
            socket.Close();
        }
    }
}
