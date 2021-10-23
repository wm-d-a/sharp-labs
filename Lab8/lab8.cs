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
        }
        //Методы
        public void Fill() {
            Console.WriteLine("\nInput elements in Set\n");
            for (int i = 0; i < this.Count; i++) {
                Console.Write($"Input {i + 1} element of Set: ");
                int buf = Convert.ToInt32(Console.ReadLine());
                this.Elements[i] = buf;
                Console.WriteLine();
            }
        }
        public int IndexOf(int Value) {
            int index = -1;
            for (int i = 0; i < this.Count; i++){
                if (Value == this.Elements[i]) {
                    index = i;
                    break;
                }
            } 
            return index;
        }
        public void ShowSet() {
            Console.Write("Elemets in Set: ");
            string buf = "";
            for (int i = 0; i < this.Count; i++) {
                buf += Elements[i] + "; ";                
            }
            Console.WriteLine(buf);
        }
        public void Add(int NewElement) {
            Array.Resize(ref this.Elements, this.Elements.Length + 1);
            this.Elements[Elements.Length - 1] = NewElement;
        }
    }
    class lab8
    {
        static void Main(string[] args)
        {
        }
    }
}
