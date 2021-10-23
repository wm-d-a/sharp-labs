using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab6
{
    class lab6
    {
        static void number1() {
            Console.WriteLine("NUMBER 1\n");
            string path = @"C:\C_SHARP\labs_\Lab6\test.txt";
            string s = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    s = (sr.ReadToEnd());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            int prs = s.Split('.').Length - 1;
            string[] mas = new string[prs + 1];
            mas = s.Split('.');
            //Console.WriteLine(mas.Length);
            //for (int i = 0; i < mas.Length; i++) {
            //  Console.WriteLine(mas[i]);
            //}
            //----------------------------
            int max = 0;
            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            int c4 = 0;
            int c5 = 0;
            int c6 = 0;
            int sm = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                c1 = mas[i].Split(',').Length - 1;
                c2 = mas[i].Split(';').Length - 1;
                c3 = mas[i].Split(':').Length - 1;
                c4 = mas[i].Split('-').Length - 1;
                c5 = mas[i].Split('"').Length - 1;
                c6 = mas[i].Split('(').Length - 1;
                //Console.WriteLine(mas[i]);
                //Console.WriteLine($"{c1} {c2} {c3} {c4} {c5} {c6}");
                sm = c1 + c2 + c3 + c4 + c5 + c6;
                if (sm > max)
                {
                    max = sm;
                }
            }
            Console.WriteLine(max);
            for (int i = 0; i < mas.Length; i++)
            {
                c1 = mas[i].Split(',').Length - 1;
                c2 = mas[i].Split(';').Length - 1;
                c3 = mas[i].Split(':').Length - 1;
                c4 = mas[i].Split('-').Length - 1;
                c5 = mas[i].Split('"').Length - 1;
                c6 = mas[i].Split('(').Length - 1;
                sm = c1 + c2 + c3 + c4 + c5 + c6;
                if (sm == max)
                {
                    Console.WriteLine(mas[i]);
                }
            }
            
        }
        static void number2() {
            Console.WriteLine("\nNUMBER 2\n");
            string path = @"C:\C_SHARP\labs_\Lab6\test2.txt";
            string s = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    s = (sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            int prs = s.Split('\n').Length;
            //Console.WriteLine(prs);
            string[] mas = new string[prs];
            mas = s.Split('\n');
            string[] itog = new string[prs];
            int[] count = new int[prs];
            for (int i = 0; i < prs; i++) {
                count[i] = 1;
            }
            int c = 0;
            for (int i = 0; i < mas.Length - 1; i++) {
                string[] buf = mas[i].Split(' ');
                //Console.WriteLine($"{buf[1]}");
                if (Array.Exists(itog, element => element == buf[1]))
                {
                    //Console.WriteLine($"{Array.IndexOf(itog, buf[1])}");
                    count[Array.IndexOf(itog, buf[1])] += 1;
                }
                else {
                    itog[c] = Convert.ToString(buf[1]);
                    //Console.Write($"{buf[1]}    ");
                    c++;
                }

            }

            string text = "";
            for (int i = 0; i < itog.Length; i++) {
                if (itog[i] != null)
                {
                    text += itog[i] + ":\t" + count[i] + '\n';   
                }     
            }
            Console.WriteLine($"{text}");
            string writePath = @"C:\C_SHARP\labs_\Lab6\itog.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            number1();
            number2();
            Console.ReadLine();
        }
    }
}
