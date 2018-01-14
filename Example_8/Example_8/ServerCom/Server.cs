using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_8.ServerCom
{
    public class Server : ViewModelBase
    {
        Socket serverSocket;
        private Action<string> GuiUpdater;
        Thread acceptingThread;
        //private Action<string> action;
        //private object guiUpdater;
        List<Clients> ClientList = new List<Clients>();

        public Server(int port, string ip ,Action<string> guiUpdater)
        {
            this.GuiUpdater = guiUpdater;

                if (serverSocket == null)
                {
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                    serverSocket.Listen(5);
                }


            //Task.Factory.StartNew(StartAccepting);
            StartAccepting();
        }

        private void StartAccepting()
        {
            acceptingThread = new Thread(Accept);
            acceptingThread.IsBackground = true;
            acceptingThread.Start();
            
        }

        private void Accept()
        {
            while (acceptingThread.IsAlive)
            {
                try
                {
                ClientList.Add(new Clients(serverSocket.Accept(), new Action<string>(NewMessageReceived)));

                }
                catch (Exception)
                {

                    throw;
                }
            }
            StopAccepting();
        }

        private void StopAccepting()
        {
            serverSocket.Close();
            acceptingThread.Abort();
            foreach (var item in ClientList)
            {
                item.Close();
            }
        }

        public void NewMessageReceived(string message)
        {
            GuiUpdater(message);

            foreach (var client in ClientList)
            {
                client.Send(message);
            }
        }
    }
}
