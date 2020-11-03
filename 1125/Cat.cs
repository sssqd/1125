using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _1125
{
    class Cat
    {
        byte _hungryStatus;
        public Cat(string name, DateTime birthday)
        {
            Name = name;
            BirthDay = birthday;
            Task.Run(LifeCircle);
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
        public byte HungryStatus
        {
            get { return _hungryStatus; }
            set
            {
                if (value < 0)
                {
                    _hungryStatus = 0;
                }
                else if (value > 100)
                {
                    _hungryStatus = 100;
                }
                else
                {
                    _hungryStatus = value;
                }
            }
        }
        public void GetStatus()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Возрост: {GetAge()}");
            if (HungryStatus < 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Кот умерает от голода ");
            }
            else if (HungryStatus >= 10 && HungryStatus <= 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Кот очень голоден");
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Кот хочет кушать");
            }
            else if (HungryStatus > 70 && HungryStatus <= 90)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Кот не против перекусить");
            }
            else if (HungryStatus > 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Кот недавно поел ");
            }
            Console.ResetColor();
        }
        async Task LifeCircle()
        {
            await Task.Delay(1000);
            HungryStatus -= 10;
            GetStatus();
            await LifeCircle();
        }
    }
}