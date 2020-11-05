using System;

namespace _1125
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Пейн", new DateTime(2014, 03, 31));
            Console.WriteLine($"Коту по имени {cat.Name} уже {cat.GetAge()} лет");
            cat.HungryStatus = 150;
            cat.HungryStatusChanged += Cat_HungryStatusChanged;
            Cat cat2 = new Cat("Джуга", new DateTime(2018, 10, 14));
            Console.WriteLine($"Коту по имени {cat2.Name} уже {cat2.GetAge()} лет");
            cat2.HungryStatusChanged += Cat2_HungryStatusChanged;
            Console.ReadLine();

        }

        private static void Cat_HungryStatusChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Cat cat = (Cat)sender;
            if (cat.HungryStatus < 20 && rnd.Next(0, 10) < 5)
                cat.Feed();
            else
                cat.GetStatus();
        }
        private static void Cat2_HungryStatusChanged(object sender, EventArgs e)

        {
            Random rnd = new Random();
            Cat cat = (Cat)sender;
            if (cat.HungryStatus < 20 && rnd.Next(0, 10) < 5)
                cat.Feed();
            else
                cat.GetStatus();
            

        }
    }
}
