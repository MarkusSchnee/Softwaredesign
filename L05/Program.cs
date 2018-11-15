using System;
using System.Collections.Generic;

namespace L05
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            
            //turnaroundword();
            turnaroundsentence();
        }

        public static void turnaroundword()
        {
            Console.WriteLine("Geben Sie das zu umdrehende Wort an: ");
            string inputWord = Console.ReadLine();
            char[] word = inputWord.ToCharArray();
            Array.Reverse(word);

            Console.WriteLine("So lautet ihr Wort umgedreht: ");
            Console.WriteLine(word);
        }

        public static void turnaroundsentence()
        {

            Console.WriteLine("Geben Sie einen Satz an: ");
            string inputSatz = Console.ReadLine();
            string[] splitter = inputSatz.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Ihr Satz wird von hinten nach vorne zurückgegeben: ");

            for (int i = splitter.Length - 1; i >= 0; i--)
            {
               
                Console.WriteLine(splitter[i]);
            }


        }


    }
}
