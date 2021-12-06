using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Student {
        public string Surname { get; set; }
        public string Lesson { get; set; }
        public double Rating { get; set; }

        public Student() {
            this.Surname = "DefaultSurname";
            this.Lesson = "DefaultLesson";
            this.Rating = 5;
        }
        public Student(string surname, string lesson, double rating) {
            this.Surname = surname;
            this.Lesson = lesson;
            this.Rating = rating;
        }
    }
    class lab12
    {
        static void Main(string[] args)
        {
            Student[] myClass = {
                new Student("s1", "Math", 2),
                new Student("s2", "IT", 5),
                
                new Student("s7", "Math", 2),
                new Student("s8", "Math", 2),
                new Student("s9", "IT", 2.6),
                new Student("s10", "IT", 2),
                new Student("s15", "Math", 2),
                new Student("s16", "Math", 2),
                new Student("s17", "IT", 1.2),
                new Student("s18", "Math", 2),
                new Student("s19", "Math", 2),
                new Student("s11", "Math", 2),
                new Student("s12", "Math", 2),
                new Student("s13", "Math", 2),
                new Student("s14", "IT", 2.2),
                new Student("s3", "Math", 5),
                new Student("s4", "Math", 5),
                new Student("s5", "Math", 5),
                new Student("s6", "IT", 3.4),
                new Student("s20", "IT", 4.5),
                new Student("s21", "Math", 2),
                new Student("s22", "Math", 2),
                new Student("s23", "Math", 2),
                new Student("s24", "Math", 2),
            };
            {
                Console.WriteLine("NUMBER 1\n");
                var result = from student in myClass
                             orderby student.Surname, student.Rating
                             select student;
                foreach (Student u in result)
                    Console.WriteLine("{0} - {1}", u.Surname, u.Rating);
            }
            {
                Console.WriteLine("\nNUMBER 2\n");
                double avgRating = myClass.Where(u => u.Lesson == "IT").Average(n => n.Rating); // СРЕДНЕЕ ЗНАЧЕНИЕ
                Console.WriteLine($"Avg: {avgRating}");
            }
            {
                Console.WriteLine("\nNUMBER 3\n"); // ФИЛЬТРАЦИЯ

                var selectedStudents = myClass.Where(u => u.Rating > 3 && u.Lesson == "Math");

                foreach (Student u in selectedStudents)
                  Console.WriteLine("{0} - {1}", u.Surname, u.Rating);
            }
            {
                Console.WriteLine("\nNUMBER 4\n");
                var surnames = myClass.Select(u => u.Surname); // ПРОЕКЦИЯ
                foreach (string n in surnames)
                    Console.WriteLine(n);
            }
            {
                Console.WriteLine("\nNUMBER 5\n");
                var studLes = myClass.GroupBy(p => p.Lesson); // ГРУППИРОВКА
                foreach (IGrouping<string, Student> g in studLes)
                {
                    Console.WriteLine(g.Key);
                    foreach (var t in g)
                        Console.WriteLine(t.Lesson);
                    Console.WriteLine();
                }
            }
            {
                Console.WriteLine("\nNUMBER 6\n");
                bool result2 = myClass.All(u => u.Rating > 3); // ALL
                Console.WriteLine(result2);
            }
            {
                Console.WriteLine("\nNUMBER 7\n");
                var result3 = myClass.Skip(myClass.Length / 2).Take(3); // SKIP/TAKE
                foreach (Student i in result3)
                    Console.WriteLine($"{i.Surname}, {i.Lesson}, {i.Rating}");
            }
            Console.ReadKey();
        }
    }
}
