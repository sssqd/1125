using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _1125
{
    public class Cat
    {
        int _hungryStatus;
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
            get { return (byte)_hungryStatus; }
            set
            {
                int newStatus = 0;
                if (value < 0)
                    newStatus = 0;
                else if (value > 100)
                    newStatus = value;
                if (newStatus != _hungryStatus)
                {
                    _hungryStatus = newStatus;
                    HungryStatusChanged?.Invoke(this, null);
                }
                else
                    _hungryStatus = 0;
            }
        }
        public void Feed(byte needFood)
        {
            HungryStatus += needFood;
        }
        public string GetStatus(string color)
        {
            string name = Name;
            string age = Convert.ToString(GetAge());
            string status = Convert.ToString(HungryStatus);
            Console.WriteLine($" {Name}, Возрост: {GetAge()}, {HungryStatus}");
            if (HungryStatus < 10)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkRed));
            }
            else if (HungryStatus >= 10 && HungryStatus <= 40)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Red));
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkYellow));
            }
            else if (HungryStatus > 70 && HungryStatus <= 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Yellow));
            }
            else if (HungryStatus > 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Green));
            }
            string getStatus = $"{color}, Имя: {name}, Возраст: {age}, Статус: {status}";
            return getStatus;
        }
        async Task LifeCircle()
        {
            await Task.Delay(100);
            HungryStatus -= 10;
            await LifeCircle();
        }
    }
}