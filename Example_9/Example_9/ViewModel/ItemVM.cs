using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Example_9.ViewModel
{
    public class ItemVM
    {
        //private string SelectedCategory;

        public string SelectedCategory { get; set; }
        public BitmapImage  Image { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public int PosY { get; set; }
        public int PosX { get; set; }
        public ItemVM(BitmapImage image, string description, int priority, string amount, string status)
        {
            Image = image;
            Description = description;
            Priority = priority;
            Amount = amount;
            Status = status;
        }

        public ItemVM(BitmapImage image, string selectedCategory, string description, int priority, string amount, string status)
        {
            Image = image;
            SelectedCategory = selectedCategory;
            Description = description;
            Priority = priority;
            Amount = amount;
            Status = status;
            SetYCoOrdinates(selectedCategory);
            SetXCoOrdinates(priority);
        }

        public ItemVM(BitmapImage image, string selectedCategory, string description, int priority, string amount, string status, int posX) : this(image, selectedCategory, description, priority, amount, status)
        {
            Image = image;
            SelectedCategory = selectedCategory;
            Description = description;
            Priority = priority;
            Amount = amount;
            Status = status;
            SetYCoOrdinates(selectedCategory);
            PosX = posX;
        }

        private void SetXCoOrdinates(int priority)
        {
            switch (priority)
            {
                case 1:
                    this.PosX = 10;
                    break;
                case 2:
                    this.PosX = 150;
                    break;
                case 3:
                    this.PosX = 290;
                    break;
            }
        }

        private void SetYCoOrdinates(string selectedCategory)
        {
            switch (selectedCategory)
            {
                case "Engine":
                    this.PosY = 10;
                    //this.PosX = 10;
                    break;
                case "Tyres":
                    this.PosY = 100;
                    //this.PosX = 10;
                    break;
                case "Paint":
                    this.PosY = 190;
                    //this.PosX = 10;
                    break;
                case "Doors":
                    this.PosY = 280;
                    //this.PosX = 10;
                    break;
                default:
                    break;
            }
        }
    }
}
