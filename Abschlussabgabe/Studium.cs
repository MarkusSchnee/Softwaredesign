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
        
    }
}