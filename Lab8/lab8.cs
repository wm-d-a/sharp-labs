using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Set {
        private int[] Elements;
        private int Count;
        //Конструкторы
        public Set() {
            Console.Write("Please, input count of elements in Set: ");
            this.Count = Convert.ToInt32(Console.ReadLine());
            this.Fill();
        }
        public Set(int[] Elements) {
            this.Elements = Elements;
            this.Count = Elements.Length;
        }
        //Методы
        public void Fill() {
            Console.WriteLine("\nInput elements in Set\n");
            int count = 0;
            for (int i = 0; i < this.Count; i++) {
                Console.Write($"Input {i + 1} element of Set: ");
                int buf = Convert.ToInt32(Console.ReadLine());
                this.Elements[i] = buf;
                count++;
                Console.WriteLine();
            }
            this.Count = count;
        }
        public int IndexOf(int item) {
            int index = -1;
            for (int i = 0; i < this.Count; i++) {
                if (item == this.Elements[i]) {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void ShowSet() {
            if (this.Count > 0)
            {
                Console.Write("Elemets in Set: ");
                string buf = "";
                for (int i = 0; i < this.Count; i++)
                {
                    buf += this.Elements[i] + "; ";
                }
                Console.WriteLine(buf);
            }
            else Console.WriteLine("Set is empty!");
        }
        public void Add(int NewElement) {
            Array.Resize(ref this.Elements, this.Elements.Length + 1);
            this.Elements[Elements.Length - 1] = NewElement;
            this.Count++;
        }
        // Перегрузки операторов
        public static Set operator ++(Set sample) {  // DONE!
            for (int i = 0; i < sample.Count; i++) {
                sample[i] += 1;
            }
            return sample;
        }
        public static Set operator +(Set sample1, Set sample2)  // DONE!
        {
            int[] buf = { };
            Set buf_set = new Set();
            for (int i = 0; i < sample2.Count; i++) {
                buf_set.Add(sample1[i]);
            }
            for (int i = 0; i < sample2.Count; i++) {
                buf_set.Add(sample2[i]);
            }
            return buf_set;
        }
        public static Set operator *(Set sample1, Set sample2)  // DONE!
        {
            int[] buf = { };
            bool flag = false;
            Set buf_set = new Set(buf);
            for (int i = 0; i < sample1.Count; i++) {
                for (int j = 0; j < sample2.Count; j++) {
                    if (sample1[i] == sample2[j]) {
                        flag = true;
                    }
                }
                if (flag) {
                    buf_set.Add(sample1[i]);
                    flag = false;
                }
            }
            return buf_set;
        }
        public static Set operator /(Set sample1, Set sample2)  // DONE!
        {
            int[] buf = { };
            bool flag = true;
            Set buf_set = new Set(buf);
            for (int i = 0; i < sample1.Count; i++)
            {
                for (int j = 0; j < sample2.Count; j++)
                {
                    if (sample1[i] == sample2[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    buf_set.Add(sample1[i]);
                    flag = true;
                }
            }
            return buf_set;
        }
        public static bool operator >(Set sample1, Set sample2)  // DONE!
        {
            if (sample1.Count > sample2.Count)
            {
                return true;
            }
            else return false;
        }
        public static bool operator <(Set sample1, Set sample2)  // DONE!
        {
            if (sample1.Count < sample2.Count)
            {
                return true;
            }
            else return false;
        }
        // Методы

        // Свойства
        /*
        public int GetCount {

            get { return this.Count; }
        }
        */

        // Индексатор
        public int this[int index]
        {
            get
            {
                return this.Elements[index];
            }
            set {
                this.Elements[index] = value;
            }
        }
    }
    class lab8
    {
        static void Main(string[] args)
        {
            int[] s1 = { 1, 2 };
            int[] s2 = { 3, 4, 5 };

            Set sample1 = new Set(s1);
            Set sample2 = new Set(s2);
            sample1.ShowSet();
            sample2.ShowSet();
            sample1.Add(3);
            Console.WriteLine("ADD");
            sample1.ShowSet();
            Console.WriteLine($"Index of '1' = {sample1.IndexOf(1)}");
            Console.WriteLine("Operetor '+'");
            Set sample3 = sample1 + sample2;
            sample3.ShowSet();
            Console.WriteLine("Operetor '++'");
            
            sample1++;
            sample1.ShowSet();
            Console.WriteLine("Operetor '*'"); // DON't WORK!
            Set sample4 = sample1 * sample2;
            sample4.ShowSet();
            Console.WriteLine("Operetor '/'"); // DON'T WORK!
            Set sample5 = sample1 / sample2;
            sample5.ShowSet();
            Console.WriteLine("Operetor '>'"); // DON'T WORK!
            Console.WriteLine(sample1 > sample2);
            Console.ReadLine();
        }
    }
}
