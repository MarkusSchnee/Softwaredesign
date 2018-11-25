using System;


namespace L06
{

     class Quizelement
    {

        public string question;
        public Answer[] answers;
        public void IsAnswerCorrect(int choice, Player _player)
        {

            if (answers[choice - 1].truth == true)
            {
                Console.WriteLine("Ihre Antwort ist korrekt");
                _player.calculatescore(true);
            }
            else
            {
                Console.WriteLine("Ihre Antwort ist falsch");
                _player.calculatescore(false);
            }

        }
        public void show()
        {
            Console.WriteLine(question);
            for (int i = 0; i < this.answers.Length; i++)
            {
                int displayedNumberOfQuestion = i + 1;
                Console.WriteLine(displayedNumberOfQuestion + ". " + this.answers[i].text);
            }
        }
    }

}