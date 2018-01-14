using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Example_8_Client.ClientCom
{
    public class Client
    {
        byte[] buffer = new byte[512];
        Socket ClientSocket;
        Action<string> GuiUpdater;
        DispatcherTimer timer = new DispatcherTimer();
        private int Port;

        public Client(int port)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Loopback, port);
                ClientSocket = client.Client;
                Task.Factory.StartNew(StartTimer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void StartTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Send();
        }

        private void Send()
        {
            Console.WriteLine("ShipId@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000");
            try
            {
                ClientSocket.Send(Encoding.UTF8.GetBytes("ShipId@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000"));
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Client(int port, Action<string> guiUpdater)
        {
            try
            {
            this.GuiUpdater = guiUpdater;

            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Loopback, port);
            ClientSocket = client.Client;
            Task.Factory.StartNew(Receive);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Receive()
        {
            string message = "";

            while (true)
            {
                int length = ClientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                GuiUpdater(message);
            }
        }
    }
}
