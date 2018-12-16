using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;

namespace L09
{
    class QuizFree : QuizElement
    {
        [JsonProperty("correct")]
        public string correct{get; set;}
        public QuizFree(String question, string answer)
        {
            this.question = question;
            this.correct = correct;
            this.callToAction = "Tippen Sie die korrekte Antwort ein:";
            this.type = "Free";
        }
        public override void Show()
        {
            Console.WriteLine(question);
            Console.WriteLine(callToAction);
        }
        public override bool isAnswerChoiceCorrect(string choice)
        {
            if (choice == correct)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}