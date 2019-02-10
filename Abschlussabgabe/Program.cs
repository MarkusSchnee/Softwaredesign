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

            Console.WriteLine(studys[0].name + ":");
            studys[0].timetable.show();

            Console.WriteLine();
            Console.WriteLine(dozenten[8].prename);
            dozenten[8].personalTimetable.show();

            /*Console.WriteLine(rooms[0].name + ":");
            rooms[0].roomTimetable.show();

            Console.WriteLine();
            Console.WriteLine(rooms[1].name + ":");
            rooms[1].roomTimetable.show();

            Console.WriteLine();
            Console.WriteLine(rooms[2].name + ":");
            rooms[2].roomTimetable.show();

            Console.WriteLine();
            Console.WriteLine(dozenten[0].name);
            dozenten[0].personalTimetable.show();

            Console.WriteLine();
            Console.WriteLine(dozenten[1].name);
            dozenten[1].personalTimetable.show();

            Console.WriteLine();
            Console.WriteLine(dozenten[2].name);
            dozenten[2].personalTimetable.show();*/
        }

        public static void createTimetables(Generator generator)
        {
            foreach (int block in settings.orderBlocks)
            {
                generator.fillBlock(block - 1);
            }


        }
        public static void newElements()
        {
            /*Studium MIB4 = new Studium("MIB4", 12);
             Studium MIB1 = new Studium("MIB1", 35);

             dozenten.Add(new Dozent( "Michael", "Waldowski", new int[2] { 4, 5 }));
             dozenten.Add(new Dozent("Dirk", "Eisenbigler", new int[2] { 3, 4 }));
             dozenten.Add(new Dozent("Fridl", "Dell'Oro", new int[2] {1, 2}));
             studys.Add(MIB4);
             studys.Add(MIB1);
             courses.Add(new Course("GDV", "Grafische Datenverarbeitung", dozenten[0], MIB4, new List<Conditions> { Conditions.Normal }));
             courses.Add(new Course("SWD", "Softwaredesign", dozenten[2], MIB4, new List<Conditions> { Conditions.Computer }));
             courses.Add(new Course("PGR", "Programmieren", dozenten[1], MIB1, new List<Conditions>() { Conditions.Normal }));
             rooms.Add(new Room("I0.01", 30, new List<Conditions> { Conditions.Normal }));
             rooms.Add(new Room("L1.01", 30, new List<Conditions> { Conditions.Computer }));
             rooms.Add(new Room("L1.06a", 40, new List<Conditions> { Conditions.Normal }));*/

            Dozent Waldowski = new Dozent("Michael", "Waldowski", new int[2] { 4, 5 });
            dozenten.Add(Waldowski); //0
            Dozent DellOro = new Dozent("Fridl", "Dell'Oro", new int[2] { 1, 2 });
            dozenten.Add(DellOro); //1
            Dozent Eisenbigler = new Dozent("Dirk", "Eisenbigler", new int[2] { 3, 4 });
            dozenten.Add(Eisenbigler);  //2
            Dozent Reusch = new Dozent("Matthias", "Reusch", new int[2] { 2, 3 });
            dozenten.Add(Reusch); //3
            Dozent Herbstreit = new Dozent("Achim", "Herbstreit", new int[2] { 4, 5 });
            dozenten.Add(Herbstreit); //4
            Dozent Schneider = new Dozent("Thomas", "Schneider", new int[2] { 3, 5 });
            dozenten.Add(Schneider); //5
            Dozent Hottong = new Dozent("Nikolaus", "Hottong", new int[2] { 1, 2 });
            dozenten.Add(Hottong); //6
            Dozent Dittler = new Dozent("Ullrich", "Dittler", new int[2] { 1, 5 });
            dozenten.Add(Dittler); //7
            Dozent Fries = new Dozent("Christian", "Fries", new int[2] { 2, 5 });
            dozenten.Add(Fries); //8
            Dozent Eberle = new Dozent("Christoph", "Eberle", new int[2] { 1, 2 });
            dozenten.Add(Eberle); //9
            Dozent Müller = new Dozent("Christoph", "Müller", new int[2] { 4, 5 });
            dozenten.Add(Müller);
            Dozent Dufner = new Dozent("Timo", "Dufner", new int[2] { 4, 5 });
            dozenten.Add(Dufner);
            Dozent Lasowski = new Dozent("Ruxandra", "Lasowski", new int[2] { 1, 5 });
            dozenten.Add(Lasowski);
            Dozent Krach = new Dozent("Thomas", "Krach", new int[2] { 2, 1 });
            dozenten.Add(Krach);
            Dozent Zydorek = new Dozent("Christoph", "Zydorek", new int[2] { 1, 3 });
            dozenten.Add(Zydorek);
            Dozent Anders = new Dozent("Jürgen", "Anders", new int[2] { 1, 5 });
            dozenten.Add(Anders);
            Dozent Unbekannt = new Dozent("Un", "Bekannt", new int[2] { 1, 5 });
            dozenten.Add(Unbekannt);


            Studium MIB1 = new Studium("MIB1", 35);
            studys.Add(MIB1);
            Studium MIB4 = new Studium("MIB4", 12);
            studys.Add(MIB4);
            Studium MIB2 = new Studium("MIB2", 30);
            studys.Add(MIB2);
            Studium MIB5 = new Studium("MIB5", 12);
            studys.Add(MIB5);
            Studium MIB6 = new Studium("MIB6", 10);
            studys.Add(MIB6);

            //MIB6
            courses.Add(new Course("ITuMedpro", "IT und Medienproduktion", Zydorek, MIB6, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("FreSpr", "Fremdsprachenmodul", Unbekannt, MIB6, new List<Conditions> { Conditions.Vorlesungssaal }));

            //MIB5
            courses.Add(new Course("DaVerMePro", "Datenverarbeitung in der Medienproduktion", Müller, MIB5, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("VerAnw", "Verteilte Anwendungen", Eisenbigler, MIB5, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("VerAnw Pra", "Verteilte Anwendungen Praktikum", Eisenbigler, MIB5, new List<Conditions> { Conditions.Computer }));
            courses.Add(new Course("DigAvTec", "Digitale AV-Technik", Hottong, MIB5, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("PrStud", "Projektstudium", Krach, MIB5, new List<Conditions> { Conditions.Normal })); //Dozent? Variabel

            //MIB4
            courses.Add(new Course("GDV", "Grafische Datenverarbeitung 1", Waldowski, MIB4, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("SWD Se", "Softwaredesign Seminar", DellOro, MIB4, new List<Conditions> { Conditions.Computer }));
            courses.Add(new Course("GrafDV", "Grafische Datenverarbeitung 2", Waldowski, MIB4, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("GrafDV Üb", "Grafische Datenverarbeitung Übung", Waldowski, MIB4, new List<Conditions> { Conditions.Computer }));
            courses.Add(new Course("KoSy", "Kommunikationssysteme", Waldowski, MIB4, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("PrStu", "Projektstudium", Krach, MIB4, new List<Conditions> { Conditions.Normal })); //Dozent? Eig variabel
            courses.Add(new Course("SWD Pra", "Softwaredesign Praktikum", DellOro, MIB4, new List<Conditions> { Conditions.Computer }));
            courses.Add(new Course("KoSy Pra", "Kommunikationssysteme Praktikum", Anders, MIB4, new List<Conditions> { Conditions.Normal }));
            courses.Add(new Course("PrStud Vor", "Projektstudium Vorlesung", Zydorek, MIB4, new List<Conditions> { Conditions.Vorlesungssaal }));

            //MIB1
            courses.Add(new Course("PGR", "Programmieren", Eisenbigler, MIB1, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("AT", "Audiotechnik", Reusch, MIB1, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("BWL", "Grundlagen der Betriebswirtschaftslehre", Herbstreit, MIB1, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("PGR PR", "Programmieren Praktikum", Eisenbigler, MIB1, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("BWL PR", "Grundlagen der Betriebswirtschaftslehre Praktikum", Herbstreit, studys[0], new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("MatMedInf1", "Mathematik in Medien und Informatik 1", Schneider, MIB1, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("VideoTech", "Videotechnik", Hottong, MIB1, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("MedTechPra", "Medientechnik Praktikum", Hottong, MIB1, new List<Conditions>() { Conditions.Fernsehstudio }));
            courses.Add(new Course("MedPsych", "Medienpsychologie", Dittler, MIB1, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("PhysMedInf", "Physik in Medien und Informatik", Schneider, MIB1, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("MINT-Pra", "MINT-Praktikum", Schneider, MIB1, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("GrMedGest", "Grundlagen Mediengestaltung", Fries, MIB1, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("GrMedGestPra", "Grundlagen Mediengestaltung Praktikum", Eberle, MIB1, new List<Conditions>() { Conditions.Normal }));

            //MIB2
            courses.Add(new Course("MathSimSem", "Mathematik und Simulation Seminar", Schneider, MIB2, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("ComGra", "Computergrafik Vorlesung", Müller, MIB2, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("GIS", "Grundlagen Interaktiver Systeme", Dufner, MIB2, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("MathSim", "Mathematik und Simulation", Lasowski, MIB2, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("MathSimPra", "Mathematik und Simulation Praktikum", Lasowski, MIB2, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("GIS Pra", "Grundlagen Interaktiver Systeme Praktikum", Dufner, MIB2, new List<Conditions>() { Conditions.Normal }));
            courses.Add(new Course("UsExDe", "User Experience Design Vorlesung", Krach, MIB2, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("ComGraPra", "Computergrafik Praktikum", Müller, MIB2, new List<Conditions>() { Conditions.Computer }));
            courses.Add(new Course("MedÖko", "Medienökonomie", Zydorek, MIB2, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("Mark", "Marketing", Zydorek, MIB2, new List<Conditions>() { Conditions.Vorlesungssaal }));
            courses.Add(new Course("UsExDeSe", "User Experience Design Seminar", Krach, MIB2, new List<Conditions>() { Conditions.Normal }));

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
            rooms.Add(new Room("L1.05a", 40, new List<Conditions> { Conditions.Normal }));
            rooms.Add(new Room("C0.02", 50, new List<Conditions> { Conditions.Vorlesungssaal }));
            rooms.Add(new Room("L2.08", 40, new List<Conditions> { Conditions.Computer }));
            rooms.Add(new Room("A3.11", 40, new List<Conditions> { Conditions.Normal }));

            settings = new Settings(new int[6] { 2, 3, 4, 1, 5, 6 }, 5, 2, 3);

        }
    }
}

