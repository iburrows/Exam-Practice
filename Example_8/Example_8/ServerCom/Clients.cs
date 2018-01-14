using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_8.ServerCom
{
    public class Clients
    {
        private Socket ClientSocket;
        byte[] buffer = new byte[512];
        Action<string> GuiUpdater;
        CancellationTokenSource ts = new CancellationTokenSource();
        public string ClientName { get; set; }



        public Clients(Socket clientSocket, Action<string> guiUpdater)
        {
            CancellationToken ct = ts.Token;
            this.GuiUpdater = guiUpdater;
            this.ClientSocket = clientSocket;
            Task.Factory.StartNew(Receive, ct);
        }

        private void Receive()
        {
            string message = "";

            while (true)
            {
                int length = ClientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                //if (message.Contains("@"))
                //{
                //    string[] getName = message.Split('@');
                //    ClientName = getName[0];
                //}
                GuiUpdater(message);
            }
            
        }

        public void Send(string message)
        {

            ClientSocket.Send(Encoding.UTF8.GetBytes(message));
        }

        internal void Close()
        {
            ClientSocket.Close(1);
            ts.Cancel();
        }
    }
}