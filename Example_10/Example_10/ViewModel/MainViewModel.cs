using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace Example_10.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private string _fastestHorse;

        public RelayCommand AddBtn { get; set; }
        public int Speed { get; set; }
        public string Name { get; set; }
        public ObservableCollection<HorseVM> HorseCollection { get; set; }
        public string FastestHorse {
            get { return _fastestHorse; }
            set { _fastestHorse = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            HorseCollection = new ObservableCollection<HorseVM>();
            AddBtn = new RelayCommand(() =>
            {
                HorseCollection.Add(new HorseVM(Speed, Name));
                GiveFastestHorse();
            });
        }

        private void GiveFastestHorse()
        {
            int maxHorse = 0;
            foreach (var item in HorseCollection)
            {
                maxHorse = Math.Max(item.Speed, maxHorse);
            }

            foreach (var item in HorseCollection)
            {
                if (item.Speed == maxHorse)
                {
                    FastestHorse = item.Name;
                }
            }
        }
    }
}