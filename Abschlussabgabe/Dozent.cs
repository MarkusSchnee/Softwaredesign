using System;
using System.Collections.Generic;

namespace Abschlussabgabe
{
    class Dozent
    {
        public Dozent(string name, string prename, Timetable personalTimetable, List<Course>course, int[] blockedDays)
        {
            this.name = name;
            this.prename = prename;
            this.personalTimetable = personalTimetable;
        }

        public string name;
        public string prename;
        public Timetable personalTimetable; 
        
    }
}