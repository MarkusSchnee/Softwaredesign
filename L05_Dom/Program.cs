using System;

namespace L05_Dom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte schreiben Sie einen Satz: ");
            string text = Console.ReadLine();
            //Console.WriteLine(ReverseLetters());
            Console.WriteLine(ReserveWords(text));
            Console.WriteLine(ReserveSentence(text));

        }

        /* public static string ReserveLetters(string text)
        {
            string reserved = " ";


            foreach (string word in text.Split(' '))
            {
                reserved = " ";

                foreach (string letter in word.ToCharArray())
                {

                }
            }

            foreach (string letter in word.ToCharArray())
            {
                reserved = letter + reserved;
            }




        } */

        public static string ReserveWords(string text)
        {
            string[] word = text.Split(' ');
            Array.Reverse(word);

            return string.Join(" ", word);
        }

        public static string ReserveSentence(string text)
        {
            char[] characterArray = text.ToCharArray();

            string reserve = string.Empty;

            for (int i = characterArray.Length - 1; i >= 0; i--)
            {
                reserve += characterArray[i];

            }
            Console.WriteLine(reserve);

            return null;


        }
    }
}
