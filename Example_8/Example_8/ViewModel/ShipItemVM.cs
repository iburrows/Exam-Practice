using GalaSoft.MvvmLight;

namespace Example_8.ViewModel
{
    public class ShipItemVM:ViewModelBase
    {

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Weight { get; set; }
        public ShipItemVM(string name, int amount, int weight)
        {
            Name = name;
            Amount = amount;
            Weight = weight;
        }
    }
}