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

        public Studium getByName(string name)
        {
            foreach (Studium studium in allStudys)
            {
                if (studium.name.Equals(name))
                    return studium;
            }
            return null;
        }

        public void fillBlock(int block)
        {
            //Random rnd = new Random();
            foreach (Room room in allRooms)
            {
                foreach (Day day in room.roomTimetable.week)
                {

                    if (allCourses.Count == 0)
                        return;

                    Course course = getPossibleCourse(room, day.numberOfDay-1, block);

                    if (course == null)
                        continue;

                    course.studium.timetable.week[day.numberOfDay-1].blocksOnDay[block].course = course;
                    room.roomTimetable.week[day.numberOfDay-1].blocksOnDay[block].course = course;
                    course.dozent.timetable.week[day.numberOfDay-1].blocksOnDay[block].course = course;

                    allCourses.Remove(course);
                }
            }
        }

        private Course getPossibleCourse(Room room, int numberOfDay, int block)
        {
            List<Course> tempAllCourses = new List<Course>();
            foreach (Course copyCourse in allCourses)
                tempAllCourses.Add(copyCourse);

            int i = 0;
            Course course = null;
            while (i != 1)
            {
                if ((tempAllCourses == null) || (tempAllCourses.Count == 0))
                    return null;

                course = tempAllCourses[0];

                if (!course.dozent.isBlocked(numberOfDay) && course.dozent.hasTime(numberOfDay, block) && course.studium.hasTime(numberOfDay, block) && room.compareWithCourse(course))
                {
                    i = 1;
                }
                else
                {
                    tempAllCourses.Remove(course);
                    course = null;
                }
            }
            return course;
        }


    }
}