using System;
using System.Collections.Generic;

namespace Abschlussabgabe
{
    class Studium
    {
        public Studium(string name, int students)
        {
            this.name = name;
            this.students = students;
            this.timetable = new Timetable();
        }

        public string name;

        public int students;

        public Timetable timetable;

        public bool HasTime(int numberOfDay, int block)
        {
            if (timetable.week[numberOfDay].blocksPerDay[block].course == null)
                return true;
            else return false;
        }

        public void PossibleWPMs(Generator generator)
        {
            List<WPM> PossibleWPMs = new List<WPM>();
            if (generator.timetablesAreCalculated == true)
            {
                foreach (WPM wpm in generator.allWpms)
                {
                    if (timetable.week[wpm.day - 1].blocksPerDay[wpm.block - 1].course == null)
                        PossibleWPMs.Add(wpm);
                }

                Console.WriteLine("Mögliche WPMs an deren Terminen du Zeit hast:");
                Console.WriteLine();
                foreach (WPM wpm in PossibleWPMs)
                {
                    Console.WriteLine(wpm.description);
                }
            }
            else Console.WriteLine("Stundenplan noch nicht berechnet");


        }
    }
}