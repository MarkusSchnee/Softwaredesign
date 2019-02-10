﻿using System;
using System.Collections.Generic;

namespace Abschlussabgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            Settings settings = new Settings(new int[6] { 2, 3, 4, 1, 5, 6 }, 5, 2, 3);
            Datas.createDatas(generator);

            createTimetables(generator, settings);

            Console.WriteLine(generator.allStudys[0].name + ":");
            generator.allStudys[0].timetable.show();

            Console.WriteLine();
            Console.WriteLine(generator.allDozenten[6].prename);
            generator.allDozenten[6].timetable.show();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Nicht gesetzte Kure:");
            foreach (Course course in generator.allCourses)
                Console.Write(course.name + " ,");
        }

        public static void createTimetables(Generator generator, Settings settings)
        {
            foreach (int block in settings.orderBlocks)
            {
                generator.fillBlock(block - 1);
            }


        }
    }
}

