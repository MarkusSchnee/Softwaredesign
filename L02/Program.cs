using System;

namespace L02
{
    class Program
    {
        static void Main(string[] args)
        {
            var i= 42;
            var pi= 3.145;
            var salute ="Hello,World";
            var shortValue= 1034;

            System.Type type = shortValue.GetType();

            Console.WriteLine(i);
            Console.WriteLine(pi);
            Console.WriteLine(salute);
            Console.WriteLine(type);
        }
    }
}
