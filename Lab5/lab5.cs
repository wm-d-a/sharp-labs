using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class lab5
    {
        static void number1() {
            Console.WriteLine("NUBBER 1\n");
            string input = Console.ReadLine();
            string[] subs = input.Split(' ');
            for (int i = subs.Length - 1; i > -1; i--) {
                Console.Write($"{subs[i]} ");
            }
            for (int i = subs.Length - 1; i > -1; i--) {
                Console.Write($"{subs[i]} ");
            }
        }
        static void number2() {
            Console.WriteLine("\nNUMBER 2\n");
            string input = Console.ReadLine();
            string[] subs = input.Split(' ');
            int K = number2_1(subs);
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            for (int i = 0; i < subs.Length; i++)
            {
                for (int j = 0; j < subs[i].Length; j++)
                {
                    if (Char.IsLetter(subs[i][j]))
                    {
                        //Console.Write($"{s[i][j]} ");
                        int id = Array.IndexOf(alphabet, char.ToUpper(subs[i][j]));
                        //Console.WriteLine(id);
                        id += K;
                        subs[i] = subs[i].Replace(subs[i][j], char.ToLower(alphabet[id % 26]));
                    }
                }
                //Console.WriteLine(s[i]);
            }
            output(subs);

        }
        static void output(string[] subs) {
            bool up = false;
            string buf = "";
            subs[0] = subs[0].Replace(subs[0][0], char.ToUpper(subs[0][0]));
            for (int i = 0; i < subs.Length; i++) {
                if (up)
                {
                    subs[i] = subs[i].Replace(subs[i][0], char.ToUpper(subs[i][0]));
                    //Console.WriteLine(Char.ToUpper(subs[i][0]));
                    up = false;
                }

                else if ((subs[i][subs[i].Length - 1] == '.') || (subs[i][subs[i].Length - 1] == '!') || (subs[i][subs[i].Length - 1] == '?')) {
                    up = true;
                }
                
                buf += subs[i] + " ";
            }
            Console.WriteLine(buf);
        }
        static int number2_1(string[] subs)
        {
            int K = 0;
            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i].Length > K)
                {
                    K = subs[i].Length;
                }
            }
            return K;
        }
        static void Main(string[] args)
        {
            number1();
            number2();
            Console.ReadLine();
        }
    }
}

/*
 * язык программирования C#
Hello world! Great world, how are you? Today is sunny day.
 */
