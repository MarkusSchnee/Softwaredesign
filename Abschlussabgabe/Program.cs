using System;
using System.Collections.Generic;

namespace Abschlussabgabe
{
    class Program
    {
        public static List<Studium> studys = new List<Studium>();
        public static List<Course> courses = new List<Course>();
        public static List<Dozent> dozenten = new List<Dozent>();
        public static List<Room> rooms = new List<Room>();
        public static List<WPM> wpms = new List<WPM>();
        public static Settings settings;

        static void Main(string[] args)
        {
            newElements();
            Generator generator = new Generator(rooms, studys, dozenten, courses, wpms);
            createTimetables(generator);

            rooms[0].roomTimetable.show();
            Console.WriteLine();
            studys[0].timetable.show();
            Console.WriteLine();
            dozenten[0].personalTimetable.show();
        }

        public static void createTimetables(Generator generator)
        {
            foreach (int block in settings.orderBlocks)
            {
                generator.fillBlock(block);
            }


        }
        public static void newElements()
        {
            dozenten.Add(new Dozent("Michael", "Waldowski", new int[2] { 4, 5 })); //0
            dozenten.Add(new Dozent("Dirk", "Eisenbigler", new int[2] {3,4}));  //1
            dozenten.Add(new Dozent("Fridl", "Dell'Oro", new int[2] { 1, 2 })); //2
            dozenten.Add(new Dozent("Matthias", "Reusch", new int[2] { 2, 3 })); //3
            dozenten.Add(new Dozent("Achim", "Herbstreit", new int[2] { 4, 5 })); //4
            dozenten.Add(new Dozent("Thomas", "Schneider", new int[2] { 3, 5 })); //5
            dozenten.Add(new Dozent("Nikolaus", "Hottong", new int[2] { 1, 2 })); //6
            dozenten.Add(new Dozent("Ullrich", "Dittler", new int[2] { 1, 5 })); //7
            dozenten.Add(new Dozent("Christian", "Fries", new int[2] { 2, 5 })); //8
            dozenten.Add(new Dozent("Christoph", "Eberle", new int[2] { 1, 2 })); //9
            
            studys.Add(new Studium("MIB4", 12)); //0
            studys.Add(new Studium("MIB1", 35)); //1
            
            courses.Add(new Course("GDV", "Grafische Datenverarbeitung", dozenten[0], new List<Studium>(){studys[0]}, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("SWD", "Softwaredesign", dozenten[2], new List<Studium>(){studys[0]}, new List<Conditions> { Conditions.Computer }));
            courses.Add(new Course("PGR", "Programmieren", dozenten[1], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));
            courses.Add(new Course("AT", "Audiotechnik", dozenten[3], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));
            courses.Add(new Course("BWL", "Grundlagen der Betriebswirtschaftslehre", dozenten[4], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));
            courses.Add(new Course("PGR PR", "Programmieren Praktikum", dozenten[1], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));
            courses.Add(new Course("BWL PR", "Grundlagen der Betriebswirtschaftslehre Praktikum", dozenten[4], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));
            courses.Add(new Course("MatMedInf1", "Mathematik in Medien und Informatik 1", dozenten[5], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Vorlesungssaal}));
            courses.Add(new Course("VideoTech", "Videotechnik", dozenten[6], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));
            courses.Add(new Course("MedTechPra", "Medientechnik Praktikum", dozenten[6], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Fernsehstudio}));
            courses.Add(new Course("MedPsych", "Medienpsychologie", dozenten[7], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Vorlesungssaal}));
            courses.Add(new Course("PhysMedInf", "Physik in Medien und Informatik", dozenten[5], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Vorlesungssaal}));
            courses.Add(new Course("MINT-Pra", "MINT-Praktikum", dozenten[5], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Vorlesungssaal}));
            courses.Add(new Course("GrMedGest", "Grundlagen Mediengestaltung", dozenten[8], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Vorlesungssaal}));
            courses.Add(new Course("GrMedGestPra", "Grundlagen Mediengestaltung Praktikum", dozenten[9], new List<Studium>(){studys[1]}, new List<Conditions>(){Conditions.Normal}));

            rooms.Add(new Room("I0.01", 30, new List<Conditions> { Conditions.Normal }));
            rooms.Add(new Room("L1.01", 30, new List<Conditions> { Conditions.Computer }));
            rooms.Add(new Room("L1.06a", 40, new List<Conditions> { Conditions.Normal }));
            rooms.Add(new Room("I0.15", 90, new List<Conditions> { Conditions.Vorlesungssaal }));
            rooms.Add(new Room("I0.16", 90, new List<Conditions> { Conditions.Vorlesungssaal }));
            rooms.Add(new Room("L2.07a", 40, new List<Conditions> { Conditions.Computer }));
            rooms.Add(new Room("I0.14", 40, new List<Conditions> { Conditions.Vorlesungssaal }));
            rooms.Add(new Room("I1.20", 40, new List<Conditions> { Conditions.Normal }));
            rooms.Add(new Room("I2.21", 40, new List<Conditions> { Conditions.Normal }));
            rooms.Add(new Room("L2.07a", 40, new List<Conditions> { Conditions.Computer }));
            rooms.Add(new Room("I0.17", 90, new List<Conditions> { Conditions.Vorlesungssaal }));
            rooms.Add(new Room("I0.13", 40, new List<Conditions> { Conditions.Normal }));

            settings = new Settings(new int[6] { 2, 3, 4, 1, 5, 6 }, 5, 2, 3);

        }
    }
}

