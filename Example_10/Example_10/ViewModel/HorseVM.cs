using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_10.ViewModel
{
    public class HorseVM:ViewModelBase
    {

        public int Speed { get; set; }
        public string Name { get; set; }
        public HorseVM(int speed, string name)
        {
            Speed = speed;
            Name = name;
        }
    }
}
