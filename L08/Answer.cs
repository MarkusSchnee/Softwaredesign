using System;

namespace L08{

    class Answer
    {
        public string text;
        public bool verity;

        public Answer(string text, bool verity)
        //Konstruktor

        {
            this.text = text;
            this.verity = verity;
        }

        public bool IsTrue()
        {
            return verity;
        }
    }
}