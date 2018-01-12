using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;

namespace Example_7.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private OrderVM _selectedBlueprint;

        public ObservableCollection<OrderVM> BlueprintCollection { get; set; }
        public OrderVM SelectedBlueprint {
            get { return _selectedBlueprint; }
            set { _selectedBlueprint = value; RaisePropertyChanged(); }
            }
        Communication communication;

        public MainViewModel()
        {
            BlueprintCollection = new ObservableCollection<OrderVM>();

            GenerateDemoData();
        }

        private void GenerateDemoData()
        {
            //string[] car = { "Engine", "Tires", "Center", "Gear" };
            //string[] motorcycle = { "Engine", "Tires", "Chassis", "Tank" };
            //string[] bicycle = { "Rack", "Tires", "Pedals" };

            string car = "Engine, Tires, Center, Gear";
            string motorcycle = "Engine, Tires, Chassis, Tank";
            string bicycle = "Rack, Tires, Pedals";


            BlueprintCollection.Add(new OrderVM("Car", 10, DateTime.Now.AddHours(3), DateTime.Now, car));
            BlueprintCollection.Add(new OrderVM("Motorcycle", 50, DateTime.Now.AddHours(6), DateTime.Now, motorcycle));
            BlueprintCollection.Add(new OrderVM("Bicycle", 30, DateTime.Now, DateTime.Now, bicycle));
        }
    }
}