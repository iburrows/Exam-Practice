using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_7.ViewModel
{
    public class OrderVM:ViewModelBase
    {

        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime CompletionTime { get; set; }
        public DateTime ReceivedTime { get; set; }
        public int Rating { get; set; }
        //public ObservableCollection<string> Components { get; set; }
        public string Components { get; set; }

        //public OrderVM(string name, int amount, DateTime completionTIme, DateTime receivedTime ,string[] components)
        public OrderVM(string name, int amount, DateTime completionTIme, DateTime receivedTime, string components)
        {
            //Components = new ObservableCollection<string>();
            Name = name;
            Amount = amount;
            CompletionTime = completionTIme;
            ReceivedTime = receivedTime;
            Components = components;
            //foreach (var item in components)
            //{
            //    Components.Add(item);
            //}

            Rating = CalculateRating(completionTIme, receivedTime);
        }

        private int CalculateRating(DateTime completionTIme, DateTime receivedTime)
        {
            double difference = completionTIme.Subtract(receivedTime).TotalHours;

            double rounded = Math.Ceiling(difference);
            return (int)rounded;
        }

    }
}
