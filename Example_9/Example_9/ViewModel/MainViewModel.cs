using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Example_9.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public RelayCommand AddBtnClicked { get; set; }
        public List<string> CategoryList { get; set; }
        public List<string> TypeList { get; set; }
        public List<string> PriorityList { get; set; }

        public string SelectedCategory { get; set; }
        public string SelectedType { get; set; }
        public string SelectedPriority { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }

        BitmapImage image;
        

        public static Random random = new Random();

        public ObservableCollection<ItemVM> Items { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<ItemVM>();

            //GenerateDemoItemsData();

            AddBtnClicked = new RelayCommand(()=>
            {
                int priority = int.Parse(SelectedPriority);

                switch (SelectedCategory)
                {
                    case "Engine":
                        image = new BitmapImage(new Uri("../Images/engine.jpg", UriKind.Relative));
                        break;
                    case "Tyres":
                        image = new BitmapImage(new Uri("../Images/tyre.jpg", UriKind.Relative));
                        break;
                    case "Paint":
                        image = new BitmapImage(new Uri("../Images/paint.jpg", UriKind.Relative));
                        break;
                    case "Doors":
                        image = new BitmapImage(new Uri("../Images/car_door.jpg", UriKind.Relative));
                        break;
                }

                if (Items.Count == 0)
                {
                    Items.Add(new ItemVM(image, SelectedCategory, Description, priority, Amount, GetRandomStatus()));
                }
                else
                {
                    int PosX = 10; ;
                    bool MoveUp = false;
                    foreach (var item in Items)
                    {
                        if (item.Priority == priority && item.SelectedCategory == SelectedCategory)
                        {
                            PosX = item.PosX + 140;
                        }
                        else if (item.Priority < priority && item.SelectedCategory == SelectedCategory)
                        {
                            PosX = Math.Max(item.PosX, 0) + 140;
                            MoveUp = true;
                        }
                    }
                    Items.Add(new ItemVM(image, SelectedCategory, Description, priority, Amount, GetRandomStatus(), PosX));
                    if (MoveUp)
                    {

                        for (int i = 0; i < Items.Count; i++)
                        {
                            if (Items[i].PosX == Items[i+1].PosX)
                            {
                                Items[i + 1].PosX += 140;
                            }
                        }
                    }
                
                }

            });
                
            CategoryList = new List<string>();
            TypeList = new List<string>();
            PriorityList = new List<string>();

            GenerateComboBoxes();

        }

        private void GenerateDemoItemsData()
        {
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/engine.jpg", UriKind.Relative)), "Engine", "Engine", 1 , "10", GetRandomStatus()));
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/engine.jpg", UriKind.Relative)), "Engine", "Engine", 2, "10", GetRandomStatus()));
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/engine.jpg", UriKind.Relative)), "Engine", "Engine", 3, "10", GetRandomStatus()));
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/engine.jpg", UriKind.Relative)), "Engine", "Engine", 1, "10", GetRandomStatus()));
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/tyre.jpg", UriKind.Relative)), "Tyres", "Tyres", 1, "15", GetRandomStatus()));
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/paint.jpg", UriKind.Relative)), "Paint", "Paint", 3, "20", GetRandomStatus()));
            Items.Add(new ItemVM(new BitmapImage(new Uri("../Images/car_door.jpg", UriKind.Relative)), "Doors", "Left door", 2, "50", GetRandomStatus()));
        }

        private string GetRandomStatus()
        {
            //random = new Random();
            string[] statuses = {"Ready", "Waiting", "Processing" };
            return statuses[random.Next(0, 2)];
        }

        private void GenerateComboBoxes()
        {
            CategoryList.Add("Engine");
            CategoryList.Add("Tyres");
            CategoryList.Add("Paint");
            CategoryList.Add("Doors");

            TypeList.Add("Car");
            TypeList.Add("Truck");
            TypeList.Add("Bus");

            PriorityList.Add("1");
            PriorityList.Add("2");
            PriorityList.Add("3");
        }
    }
}