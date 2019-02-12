using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Abschlussabgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            //JsonRead(generator);
            Settings settings = new Settings(new int[6] { 2, 3, 4, 1, 5, 6 }, 5, 2, 3);

            /*foreach(Studium studium in generator.allStudys)
            {
                Console.WriteLine(studium.name);  //Testzwecke
            }*/

            Datas.CreateDatas(generator); //fill empty lists out of generator

            //JsonWrite(generator);

            CreateTimetables(generator, settings);

            Console.WriteLine("MIB2");
            generator.GetStudiumByName("MIB2").timetable.Show();

            Console.WriteLine();
            Console.WriteLine("Krach");
            generator.GetByNameDozent("Krach").timetable.Show();

            Console.WriteLine();
            generator.allStudys[3].PossibleWPMs(generator);
        }

        private static void CreateTimetables(Generator generator, Settings settings)
        {
            foreach (int block in settings.orderBlocks) //geht durch des array für 6 blöcke durch
            {
                generator.FillBlock(block - 1);
            }
            generator.timetablesAreCalculated = true;
        }

        private static void JsonWrite(Generator generator)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented,
            };

            string JStudys = JsonConvert.SerializeObject(generator.allStudys, settings);  //convert object to string
            string JRooms = JsonConvert.SerializeObject(generator.allRooms, settings);
            string JCourses = JsonConvert.SerializeObject(generator.allCourses, settings);
            string JDozenten = JsonConvert.SerializeObject(generator.allDozenten, settings);
            string JWpms = JsonConvert.SerializeObject(generator.allWpms, settings);

            using (StreamWriter sw = new StreamWriter("Studiengänge.json", false)) { sw.WriteLine(JStudys); }
            using (StreamWriter sw = new StreamWriter("Räume.json", false)) { sw.WriteLine(JRooms); }
            using (StreamWriter sw = new StreamWriter("Kurse.json", false)) { sw.WriteLine(JCourses); }
            using (StreamWriter sw = new StreamWriter("Dozenten.json", false)) { sw.WriteLine(JDozenten); }
            using (StreamWriter sw = new StreamWriter("WPMs.json", false)) { sw.WriteLine(JWpms); }

        }

        private static void JsonRead(Generator generator)  //liest aus Json datei raus, bsp Studiengänge.json --> befüllt Liste Studium
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented,
            };

            generator.allStudys = JsonConvert.DeserializeObject<List<Studium>>(File.ReadAllText("Studiengänge.json"), settings);
            generator.allRooms = JsonConvert.DeserializeObject<List<Room>>(File.ReadAllText("Räume.json"), settings);
            generator.allCourses = JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText("Kurse.json"), settings);
            generator.allDozenten = JsonConvert.DeserializeObject<List<Dozent>>(File.ReadAllText("Dozenten.json"), settings);
            generator.allWpms = JsonConvert.DeserializeObject<List<WPM>>(File.ReadAllText("WPMs.json"), settings);
        }
    }
}

