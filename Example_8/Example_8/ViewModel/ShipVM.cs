using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Example_8.ViewModel
{
    public class ShipVM:ViewModelBase
    {
        private int sum;



        public string ShipId { get; set; }
        public ObservableCollection<ShipItemVM> ShipItem { get; set; }
        public int Sum {
            get {return sum; }
            set
            {
                sum = value;
                RaisePropertyChanged();
            }
            
        }

        public ShipVM(string shipId, ShipItemVM[] shipCargo)
        {
            ShipId = shipId;

            if (ShipItem == null)
            {
            ShipItem = new ObservableCollection<ShipItemVM>();

            }
            foreach (var cargo in shipCargo)
            {
                ShipItem.Add(cargo);
            }

            foreach (var ship in ShipItem)
            {
                sum += ship.Weight;
            };
        }

    }
}