using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_6.ViewModel
{
    public class PersonVM
    {

        public string Firstname { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int IdNumber { get; set; }
        public string IdType { get; set; }
        public int Rating { get; set; }

        public PersonVM(string firstname, string lastName, int age, int idNumber, string idType, int rating)
        {
            Firstname = firstname;
            LastName = lastName;
            Age = age;
            IdNumber = idNumber;
            IdType = idType;
            Rating = rating;
        }

        public PersonVM()
        {

        }
    }
}
