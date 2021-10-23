using System;

namespace ConsoleApp1

{
    enum Frequency
    {
        Weekly = 1,
        Monthly,
        Yearly,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Frequency sample;
            sample = Frequency.Weekly;
            Console.WriteLine(sample);
            Console.ReadLine();
        }
    }
}