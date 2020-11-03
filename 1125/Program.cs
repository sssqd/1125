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
            Console.ReadLine();
        }
    }
}
