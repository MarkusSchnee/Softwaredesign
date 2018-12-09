using System;

namespace L08
{
    class Quizelement
    {
        public string question;
        public Answer[] answers;

        public Quizelement(string question, Answer[] answers)
        // Konstruktor
        {
            this.question = question;
            this.answers = answers;
        }

        public void ShowQuestion()
        {
            
        }
    }

}