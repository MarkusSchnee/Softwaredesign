using System;

namespace L05_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie ihr Satz an: ");
            string inputText = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine(turnaroundword(inputText));
            Console.WriteLine(" ");
            Console.WriteLine(turnaroundsentence(inputText));
            Console.WriteLine(turnaroundwordsandsentence(inputText));
        }

        public static string turnaroundword(string inputText)
        {

            char[] word = inputText.ToCharArray();
            Array.Reverse(word);


            return new string(word);
        }

        public static string turnaroundsentence(string inputText)
        {
            string[] burster = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = burster.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(burster[i]);
            }



            return null;


        }

        public static string turnaroundwordsandsentence(string inputText)
        {

            string[] burster = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = burster.Length - 1; i >= 0; i--)
            {
                char[] words = burster[i].ToCharArray();
                Array.Reverse(words);
                Console.WriteLine(words);

            }


            return null;
        }
    }
}
