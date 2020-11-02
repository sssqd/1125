using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _1125
{
    class Cat
    {
        public Cat(string name, DateTime birthday)
        {
            Name = name;
            BirthDay = birthday;
        }
        public string Name
        {
            get; set;
        }
        public DateTime BirthDay
        {
            get; set;
        }
        public void MakeNoise()
        {
            Console.WriteLine(Name + " мяукает");
        }
        public int GetAge()
        {
            return (DateTime.Today - BirthDay).Days / 365;
        }

    }

}