using System;

namespace L08
{
    class MultipleChoiceElement
    {
        public string question;
        public Answer[] answers;

        public int correctAnswers;

        public MultipleChoiceElement(string question, Answer[] answers, int correctAnswers)
        {
            this.question = question;
            this.answers = answers;
            this.correctAnswers = correctAnswers;
        }

        public void ShowQuestion()
        {

        }
    }
}