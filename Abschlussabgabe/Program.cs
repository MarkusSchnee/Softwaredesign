using System;
using System.Collections.Generic;

namespace Abschlussabgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Course kurs = new Course
            {
                name= "GDV",
                description = "Mega Schnurbi",
                conditions = new List<Condition>(Tonstudio),
            }
        }
    }
}
