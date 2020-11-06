using System;

namespace _1125
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Пейн", new DateTime(2014, 03, 31));
            cat.MakeNoise();
            Console.WriteLine($"Коту по имени {cat.Name} уже {cat.GetAge()} лет");
            Cat cat2 = new Cat("Джуга", new DateTime(2018, 10, 14));
            cat2.MakeNoise();
            Console.WriteLine($"Коту по имени {cat2.Name} уже {cat2.GetAge()} лет");
            CatSmartHouse catHouse = new CatSmartHouse(900);
            catHouse.AddCat(cat);
            catHouse.AddCat(cat2);
            Console.ReadLine();
        }
    }
}
