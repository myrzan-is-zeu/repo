using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassStudent
{
    class Student
    {
        string name;
        string surname;
        public double mark;

        public Student(string name, string surname, double mark)
        {
            this.name = name;
            this.surname = surname;
            this.mark = mark;
        }
        public void ReadInfo()
        {
            name = Console.ReadLine();
            surname = Console.ReadLine();
            mark = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
        public void PrintInfo()
        {
            Console.WriteLine(surname + " " + name + " " + mark);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            List<Student> L = new List<Student>();
            Random r = new Random();
            int n = r.Next(10, 25);
            for (int i = 0; i < n; i++)
            {
                double mark = r.Next(0, 6) + r.NextDouble();
                Student S = new Student("Myrzan" + " " + i, "Izimbetov", mark: mark);
                L.Add(S);
            }
            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = i + 1; j < n - 1; ++j)
                {
                    if (L[i].mark > L[j].mark)
                    {
                        Student t = L[i];
                        L[i] = L[j];
                        L[j] = t;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                L[i].PrintInfo();
            }
            Console.ReadKey();
        }
    }
}