using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class lab4
    {
        static void output(List<int> s) {
            Console.WriteLine("-----------------");
            for(int i = 0; i < s.Count; i++)
            {
                Console.Write($"{s[i], 5}");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
        }
        static void Main(string[] args)
        {
            //1
            Random rand = new Random();
            List<int> s1 = new List<int>(5) {
                rand.Next(1, 100),
                rand.Next(1, 100),
                rand.Next(1, 100),
                rand.Next(1, 100),
                rand.Next(1, 100),
            };  
            output(s1);
            s1.Add(rand.Next(1, 100));
            output(s1);
            //------------------------
            //2
            List<int> s2 = new List<int>(5) {
                rand.Next(1, 100),
                rand.Next(1, 100),
                rand.Next(1, 100),
            };
            output(s2);
            //------------------------
            //3
            s1.InsertRange(2, s2);
            output(s1);
            //------------------------
            //4
            Console.WriteLine($"Длина первого списка: {s1.Count}\n");
            //------------------------
            //5
            s1.Sort();
            s1.Reverse();
            Console.WriteLine($"Максимальный элемент первого списка: {s1[0]}\n");
            //------------------------
            //6
            s1.Reverse();
            Console.WriteLine($"Минимальный элемент первого списка: {s1[0]}");
            //------------------------
            //7
            int[] mas = s2.ToArray();
            Console.WriteLine("\ns2 to Array:");
            for (int i = 0; i < mas.Length; i++) {
                Console.Write($"{mas[i],5}");
            }
            Console.WriteLine();
            //------------------------
            //8
            s2.RemoveAt(1);
            output(s2);
            //------------------------
            Console.ReadLine();
        }
    }
}
