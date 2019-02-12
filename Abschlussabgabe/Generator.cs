using System;
using System.Collections.Generic;

namespace Abschlussabgabe
{
    class Generator
    {
        public Generator()
        {
            this.allRooms = new List<Room>();
            this.allStudys = new List<Studium>();
            this.allDozenten = new List<Dozent>();
            this.allCourses = new List<Course>();
            this.allWpms = new List<WPM>();
        }

        public List<Room> allRooms;

        public List<Studium> allStudys;

        public List<Dozent> allDozenten;

        public List<Course> allCourses;

        public List<WPM> allWpms;

        public bool timetablesAreCalculated;

        public Studium GetStudiumByName(string name)
         {
             foreach (Studium studium in allStudys)
             {
                 if (studium.name.Equals(name))
                     return studium;
             }
             return null;
         }

         public Dozent GetByNameDozent(string prename)
        {
            foreach (Dozent dozent in allDozenten)
            {
                if (dozent.prename.Equals(prename))
                    return dozent;
            }
            return null;
        }

        // public void createEmtyTimetable()
        // {
        //     foreach(Studium studium in allStudys)
        //     {
        //         studium.timetable = new Timetable();
        //     }

        //     foreach(Dozent dozent in allDozenten)
        //     {
        //         dozent.timetable = new Timetable();
        //     }

        //     foreach(Room room in allRooms)
        //     {
        //         room.timetable = new Timetable();
        //     }
        // }

        public void FillBlock(int block)
        {
            foreach (Room room in allRooms) //nehmen ersten Raum in allRooms
            {
                foreach (Day day in room.timetable.week) //setzen Tag fest
                {

                    if (allCourses.Count == 0) //schauen uns Länge von Liste an, wenn leer gehen wir direkt raus
                        return;

                    Course course = GetPossibleCourse(room, day.numberOfDay - 1, block); //haben jetzt durch Methode unten course, der passt

                    if (course == null)
                        continue; //geht wieder hoch zur foreach schleife

                    course.studium.timetable.week[day.numberOfDay - 1].blocksPerDay[block].course = course; //alle drei sprechen gleichen Zeitpunkt an
                    room.timetable.week[day.numberOfDay - 1].blocksPerDay[block].course = course;
                    course.dozent.timetable.week[day.numberOfDay - 1].blocksPerDay[block].course = course;

                    allCourses.Remove(course); //dass course nicht zweimal verwendet wird, course wird aus liste course entfernt
                }
            }
        }

        private Course GetPossibleCourse(Room room, int numberOfDay, int block)
        {
            List<Course> tempAllCourses = new List<Course>(); //neue Liste aus allCourses erstellen, temporäre Liste
            foreach (Course copyCourse in allCourses)
                tempAllCourses.Add(copyCourse);

            int i = 0;
            Course course = null; 
            while (i != 1)
            {
                if ((tempAllCourses == null) || (tempAllCourses.Count == 0)) 
                    return null;

                course = tempAllCourses[0];                                                                                                                  //richtige Anforderungen, richtige Größe              

                if (!course.dozent.IsBlocked(numberOfDay) && course.dozent.HasTime(numberOfDay, block) && course.studium.HasTime(numberOfDay, block) && room.CompareWithCourse(course)) //wenn jeder dieser Bedingung true ist wird i = 1 gesetzt, While schleife brcht dann ab
                {
                    i = 1;
                }
                else
                {
                    tempAllCourses.Remove(course); //wenn wir hier landen, wird aktueller course aus Liste gelöscht, weil iwas nicht passt
                    course = null; //nicht unbedingt nötig
                }
            }
            return course; //wenn wir aus while schleife raus kommen, passt alles und course wird returned
        }

    }
}