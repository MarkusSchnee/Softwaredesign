using System;
using System.Collections.Generic;

namespace L08
{
    class Program
    {
        static int score = 0;

        static List<Quizelement> quizelements = new List<Quizelement>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void GetDefaultQuestion()
        {
            quizelements.Add(new Quizelement("Wer war der erste Bundeskanzler der BRD?", new Answer[] {
                new Answer("Sherlock Holmes", false),
                new Answer("Abraham Lincoln", false),
                new Answer("Konrad Adenauer", true),
                new Answer("Helmut Kohl", false)
            }));
        }

        public static Boolean FollowUserinstruction()
        {
            if (score != 0)
                Console.Write($"\nYour score is {score}\n");

            Console.Write("\nDo you want to:\n\nS) Solve a regular question \nY) Solve a yes/no question \nA) Add a question or\nE) End the program?\n\n> ");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    AddQuestion();
                    return true;
                case "E":
                    Console.Clear();
                    Console.Write("You left the game.\n\n");
                    return false;
                case "Y":
                    if (currentYesNoElement < yesnoelements.Count)
                    {
                        SolveYesNoQuestion(yesnoelements[currentYesNoElement]);
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
                case "M":
                    if (currentMultipleChoiceElement < multipleChoiceElements.Count)
                    {
                        SolveMultipleChoiceQuestion(multipleChoiceElements[currentMultipleChoiceElement]);
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
                case "F":
                    if (currentFreeElement < freeElements.Count)
                    {
                        SolveFreeQuestion(freeElements[currentFreeElement]);
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
                default:
                    if (currentQuizelement < quizelements.Count)
                    {
                        SolveAQuestion(quizelements[currentQuizelement]);
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
            }
        }

         public static void SolveAQuestion(Quizelement quizelement) {
            Console.Clear();
            quizelement.ShowQuestion();
            Console.Write("\nYour choice: ");
            if (quizelement.answers[Int32.Parse(Console.ReadLine()) - 1].isTrue()) {
                score += 10;
                Console.Write("\nRight Answer! 10 Points to Gryffindor!");
            } else {
                Console.Write("\nWrong Answer. Sorry for that, bro!");
            }
            currentQuizelement++;
        }

        public static void SolveYesNoQuestion(YesNoElement yesNoElement){
            Console.Clear();
            yesNoElement.ShowQuestion();
            Console.Write("\nYour choice: ");
            switch(Console.ReadLine().ToUpper()){
                case "Y":
                    if(yesNoElement.verity == true){
                        score += 10;
                        Console.Write("\nRight Answer! 10 Points to Gryffindor!");
                    } else {
                        Console.Write("\nWrong Answer. Sorry for that, bro!");
                    }
                    break;
                case "N":
                    if(yesNoElement.verity == false){
                        score += 10;
                        Console.Write("\nRight Answer! 10 Points to Gryffindor!");
                    } else {
                        Console.Write("\nWrong Answer. Sorry for that, bro!");
                    }
                    break;
                default:
                    Console.Write("\nNo valid input selected");
                    break;
            }
            currentYesNoElement++;
        }

        public static void SolveMultipleChoiceQuestion(MultipleChoiceElement multipleChoiceElement)
        {
            int correctAnswers = 0;
            Console.Clear();
            multipleChoiceElement.ShowQuestion();
            Console.Write("\nYour choices (separated by a space): ");
            String[] splitAnswers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var answer in splitAnswers){
                if(multipleChoiceElement.answers[Int32.Parse(answer) - 1].isTrue())
                {
                    correctAnswers++;
                } else {
                    Console.Write("\nA wrong answer has been chosen...");
                    return;
                }
            }
            if(correctAnswers == multipleChoiceElement.correctAnswers)
            {
                score += 10;
                Console.Write("\nRight Answer! 10 Points to Gryffindor!");
            } else {
                Console.Write("\nWrong Answer. Sorry for that, bro!");
            }
        }

        public static void SolveFreeQuestion(FreeElement freeElement)
        {
            Console.Clear();
            freeElement.ShowQuestion();
            Console.Write("\nYour answer (not case-sensitive): ");
            if(Console.ReadLine().ToUpper() == freeElement.answer.ToUpper())
            {
                score += 10;
                Console.Write("\nRight Answer! 10 Points to Gryffindor!");
            } else {
                Console.Write("\nWrong Answer. Sorry for that, bro!");
            }

        }

        public static void AddQuestion() {
            Console.Clear();
            Console.Write("\nType in the Question you want to ask:\n> ");
            String newQuestion = Console.ReadLine();

            Console.Write("\nHow many chooseable answers do you want to give? (2-6)\n> ");
            int answerCount = Int32.Parse(Console.ReadLine());
            Answer[] newAnswers = new Answer[answerCount];

            
            Console.Write("\nType in your first AND TRUE answer: \n> ");
            newAnswers[0] = new Answer(Console.ReadLine(), true);
            
            for (int i = 1; i < answerCount; i++) {
                Console.Write($"\nType in your {i+1}. answer: \n> ");
                newAnswers[i] = new Answer(Console.ReadLine(), false);
            }
            
            quizelements.Add(new Quizelement(newQuestion, newAnswers));
        }

    }
}
    


