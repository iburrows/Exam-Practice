using Example_8.ServerCom;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;

namespace Example_8.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public ObservableCollection<ShipVM> ShipCollection { get; set; }
        public ObservableCollection<ShipItemVM> ItemCollection { get; set; }
        Server server;
        private ShipVM _selectedShip;
        private const int port = 10100;
        private const string ip = "127.0.0.1";


        //public ShipItemVM SelectedShip { get; set; }
        public ShipVM SelectedShip {
            get => _selectedShip;
            set
            {
                _selectedShip = value;
                RaisePropertyChanged();
                //AddToItemCollection(_selectedShip);
            }
        }

        private void AddToItemCollection(ShipVM selected_ship)
        {
            foreach (var ship in ShipCollection)
            {
                if (ship.ShipId == selected_ship.ShipId)
                {
                    foreach (var shipItem in selected_ship.ShipItem)
                    {
                        ItemCollection.Add(shipItem);
                    }
                }
            }
        }

        public MainViewModel()
        {
            ShipCollection = new ObservableCollection<ShipVM>();
            ItemCollection = new ObservableCollection<ShipItemVM>();

            server = new Server(port, ip, NewMessageReceived);
        }

        private void NewMessageReceived(string obj)
        {
            //ShipId@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000
            string[] message = obj.Split(new char[] { '@', '|' });

            string shipId = message[0];

            string[] NewMessage = new string[message.Length - 1];

            for (int i = 0; i < message.Length - 1; i++)
            {
                NewMessage[i] = message[i + 1];
            }
            App.Current.Dispatcher.Invoke(() => { ShipCollection.Add(new ShipVM(shipId, AddItems(NewMessage))); });


        }

        private ShipItemVM[] AddItems(string[] newMessage)
        {
            ShipItemVM[] itemArray = new ShipItemVM[newMessage.Length];
            ShipItemVM itemsToAdd;
            int i = 0;
            foreach (var item in newMessage)
            {
                string[] theItem = item.Split(',');
                itemsToAdd = new ShipItemVM(theItem[0], int.Parse(theItem[1]), int.Parse(theItem[2]));
                itemArray[i] = itemsToAdd;
                i++;
            }

            return itemArray;
        }
    }
}