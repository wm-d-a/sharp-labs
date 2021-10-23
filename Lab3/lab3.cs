using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class lab3
    {
        static double[] init(int n, double[] s) {
            Console.WriteLine($"Введите {n} элементов");
            for (int i = 0; i < n; i++)
            {
                s[i] = Convert.ToDouble(Console.ReadLine());
            }
            return s;
        }

        static double min(int n, double[] s) {
            double m = 0;
            for (int i = 0; i < n; i++) {
                if (s[i] < m) {
                    m = s[i];
                }
            }
            return m;
        }

        
        static void number1() {
            Console.WriteLine("\nNUMBER 1\n");
            Console.Write("Введите N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            // 1 2 3 4 5 -6 -10 -1 8 - 5
            double[] s = new double[n];
            s = init(n, s);
            double max = min(n, s);
            int last_positive = 0;
            for (int i = n - 1; i >= 0; i--) {
                if ((s[i] < 0) & (s[i] > max)) {
                    max = s[i];
                }
                if ((s[i] > 0) & (last_positive == 0)) {
                    last_positive = i;
                }
            }
            double sum = 0;
            for (int i = 0; i < last_positive; i++) {
                sum += s[i];
            }
            Console.WriteLine($"Максимальный отрицательный элемент: {max}\nСумма до последнего положительного элемента: {sum}");
        }
        static void output(int[,] mat, int n1, int n2) {
            for (int i = 0; i < n1; i++) {
                for (int j = 0; j < n2; j++) {
                    Console.Write($"{mat[i,j], 5}");
                }
                Console.WriteLine();
            }
        }
        static void number2() {
            Console.WriteLine("\nNUMBER 2\n");
            int[,] mat = {
                {1, 2, 3, 4, 5, 6, 7, 8},
                {2, 45, 412, 325, 62, 72, 82, 92 },
                {3, 43, 53, 63, 73, 5, 93, 10 },
                {4, 54, 64, 74, 67, 94, 10, 11 },
                {5, 6, 71, 8, 9, 12, 97, 123},
                {6, 324, 13, 564, 21, 3, 4, 6},
                {7, 123, 32, 54, 12, 46, 1, 2 },
                {8, 12, 45, 21, 765, 12, 32, 6}
            };
            output(mat, 8, 8);
            for (int i = 0; i < 8; i++) {
                string buf = "";
                for (int j = 0; j < 8; j++) {
                    buf += Convert.ToString(mat[i,j]);
                }
                string buf2 = "";
                for (int z = 0; z < 8; z++) {
                    buf2 += mat[z, i];
                }
                if (buf == buf2) {
                    Console.WriteLine($"При k = {i} строка равна столбцу");
                }
 
            }
            int[] buf_mat_0 = new int[8];
            int[] buf_mat_7 = new int[8];
            for (int j = 0; j < 8; j++) {
                buf_mat_0[j] = mat[0, j];
            }
            for (int j = 0; j < 8; j++) {
                buf_mat_7[j] = mat[7, j];
            }
            for (int j = 0; j < 8; j++) {
                mat[0, j] = buf_mat_7[j];
                mat[7, j] = buf_mat_0[j];
            }
            output(mat, 8 ,8);

        }
        static void number3() {
            Console.WriteLine("\nNUMBER 3\n");
            Random rand = new Random();
            int[][] mas = new int[5][];
            mas[0] = new int[5];
            mas[1] = new int[3];
            mas[2] = new int[8];
            mas[3] = new int[4];
            mas[4] = new int[6];
            string buf = "";
            for (int i = 0; i < 5; i++) {
                int sum = 0;
                for (int j = 0; j < mas[i].Length; j++) {
                    mas[i][j] = rand.Next(-500, 500);
                    sum += mas[i][j];
                    Console.Write($"{mas[i][j], 5}");
                }
                Console.WriteLine();
                buf += $"Сумма элементов в {i + 1} строке: {sum}\n";
            }
            Console.WriteLine(buf);
        }
        static void Main(string[] args)
        {
            number1();
            number2();
            number3();
            Console.ReadLine();
        }
    }
}
