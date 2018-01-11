using Example_6.TheClient;
using Example_6.TheServer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Example_6.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PersonVM> PersonCollection { get; set; }
        public ObservableCollection<PersonVM> FilterCollection { get; set; }
        public List<string> IdTypeList { get; set; }

        private const int port = 10100;
        private const string ip = "127.0.0.1";

        public Server server;
        public Client client;

        public RelayCommand ClientBtnClicked { get; set; }
        public RelayCommand ServerBtnClicked { get; set; }

        public string SelectedIdType {
            get { return _selectedIdType; }
            set {
                _selectedIdType = value;
                StartFilter();
                }
        }

        private void StartFilter()
        {
            //PersonVM[] originalList;

            //if (_selectedIdType != "")
            //{
            //    originalList = new PersonVM[PersonCollection.Count];
            //    PersonCollection.CopyTo(originalList, 0);
            //}

            //FilterCollection.Clear();

            
            foreach (var person in PersonCollection)
            {
                if (person.IdType == _selectedIdType)
                {
                    FilterCollection.Add(person);
                }
            }
            PersonCollection.Clear();

            foreach (var item in FilterCollection)
            {
                PersonCollection.Add(item);
            }

            if (_selectedIdType == "")
            {
                PersonCollection.Clear();
                FilterCollection.Clear();
                GenerateDemoData();
            }

            //if(_selectedIdType == "")
            //{
            //    foreach (var item in originalList)
            //    {
            //        PersonCollection.Add(item);
            //    }
            //}
        }

        private bool isConnected = false;
        private string _selectedIdType;

        //public string Firstname { get; set; }
        //public string LastName { get; set; }
        //public int Age { get; set; }
        //public int IdNumber { get; set; }
        //public string IdType { get; set; }
        //public int Rating { get; set; }

        public MainViewModel()
        {
            PersonCollection = new ObservableCollection<PersonVM>();
            FilterCollection = new ObservableCollection<PersonVM>();
            IdTypeList = new List<string>();

            ClientBtnClicked = new RelayCommand(
                () =>
                {
                    client = new Client(ip, port, NewMessageReceived);
                    isConnected = true;

                },
                () => { return !isConnected; });

            ServerBtnClicked = new RelayCommand(
                () =>
                {
                    server = new Server(ip, port, NewMessageReceived);
                    isConnected = true;
                    GenerateDemoData();
                },
                () => { return !isConnected; });

            GenerateIdTypeData();
        }

        private void GenerateDemoData()
        {
            PersonCollection.Add(new PersonVM("Ian", "Burrows", 30, 1234, "Driving License", 1));
            PersonCollection.Add(new PersonVM("Tessa", "Burrows", 27, 1234, "Driving License", 3));
            PersonCollection.Add(new PersonVM("Katharina", "Schermann", 28, 1234, "Identity Card", 5));
            PersonCollection.Add(new PersonVM("Ian", "Burrows", 30, 1234, "Signature", 1));
            PersonCollection.Add(new PersonVM("Ian", "Burrows", 30, 1234, "Signature", 2));
            PersonCollection.Add(new PersonVM("Ian", "Burrows", 30, 1234, "Identity Card", 4));
        }

        private void GenerateIdTypeData()
        {
            IdTypeList.Add("");
            IdTypeList.Add("Driving License");
            IdTypeList.Add("Identity Card");
            IdTypeList.Add("Signature");
        }

        private void NewMessageReceived(string message)
        {

        }
    }
}