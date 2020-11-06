using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _1125
{
    public class Cat
    {
        byte _hungryStatus;
        public event EventHandler HungryStatusChanged;
        public Cat(string name, DateTime birthday)
        {
            Name = name;
            BirthDay = birthday;
            Task.Run(LifeCircle);
        }
        public string Name
        {
            get;
            set;
        }
        public void MakeNoise()
        {
            Console.WriteLine($"{Name } мяукает");
        }
        public DateTime BirthDay
        {
            get; set;
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
                byte status = value;
                if (status < 0)
                {
                    status = 0;
                }
                else if (status > 100)
                {
                    status = 100;
                }
                else
                    _hungryStatus = value;
                if (_hungryStatus != value)
                {
                    HungryStatusChanged?.Invoke(this, null);
                }
            }
        }
        public void Feed(byte needFood)
        {
            HungryStatus += needFood;
        }
        public void GetStatus()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Возраст: {GetAge()}");
            if (HungryStatus <= 10)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Кот умирает от голода");
            }
            else if (HungryStatus > 10 && HungryStatus <= 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Кот очень голоден");
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Кот хочет кушать");
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Кот не против перекусить");
            }
            else if (HungryStatus > 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Кот недавно поел");
            }
            Console.ResetColor();
        }
        async Task LifeCircle()
        {
            await Task.Delay(100);
            HungryStatus -= 10;
            await LifeCircle();
        }
    }
}