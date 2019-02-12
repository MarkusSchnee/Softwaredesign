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
            foreach (Room room in allRooms) //takes first room in allRooms
            {
                foreach (Day day in room.timetable.week) //set day
                {

                    if (allCourses.Count == 0) //control if list is filled
                        return;

                    Course course = GetPossibleCourse(room, day.numberOfDay - 1, block); //course that fits 

                    if (course == null) //course does not focus any object
                        continue; 

                    course.studium.timetable.week[day.numberOfDay - 1].blocksPerDay[block].course = course; 
                    room.timetable.week[day.numberOfDay - 1].blocksPerDay[block].course = course;
                    course.dozent.timetable.week[day.numberOfDay - 1].blocksPerDay[block].course = course;

                    allCourses.Remove(course);
                }
            }
        }

        private Course GetPossibleCourse(Room room, int numberOfDay, int block)
        {
            List<Course> tempAllCourses = new List<Course>(); //temporary list
            foreach (Course copyCourse in allCourses)
                tempAllCourses.Add(copyCourse);

            int i = 0;
            Course course = null; 
            while (i != 1)
            {
                if ((tempAllCourses == null) || (tempAllCourses.Count == 0)) 
                    return null;

                course = tempAllCourses[0];                                                                                                                                

                if (!course.dozent.IsBlocked(numberOfDay) && course.dozent.HasTime(numberOfDay, block) && course.studium.HasTime(numberOfDay, block) && room.CompareWithCourse(course))
                {
                    i = 1;
                }
                else
                {
                    tempAllCourses.Remove(course); //course ist deleted because something does not fit
                    course = null; 
                }
            }
            return course; //while loop ok, course fits and will be returned
        }

    }
}