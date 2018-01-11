using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example_6.TheServer
{
    class ClientHandler
    {
        private Socket clientSocket;
        byte[] buffer = new byte[512];
        

        public ClientHandler(Socket socket)
        {
            this.clientSocket = socket;
        }

        internal void Send(string message)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
