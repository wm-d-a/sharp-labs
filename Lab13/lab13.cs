using System;
using System.IO;


namespace Lab13
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //
            Console.WriteLine("NUMBER 1");
            ResearchTeam sample = new ResearchTeam();
            sample.AddPersons(
                new Person(),
                new Person("TestName", "Surname", new System.DateTime(2000, 1, 1))
            );
            sample.AddPapers(
                new Paper(),
                new Paper("Test", new Person(), new System.DateTime(2000, 1, 1))
            );
            ResearchTeam sampleCopy = sample.DeepCopy();
            Console.WriteLine($"Original: {sample.ToShortString()}");
            Console.WriteLine($"Copy: {sampleCopy.ToShortString()}");
            Console.WriteLine();
            //--------
            //Number 2
            Console.WriteLine("NUMBER 2");
            Console.Write("Name: ");
            string buf_path = @"C:\C_SHARP\labs_\Lab13\exp.txt";
            if (!sample.Load(buf_path))
            {
                sample.Save(buf_path);
            }
            Console.WriteLine(sample);
            Console.WriteLine();
            //--------
            //Number 3
            Console.WriteLine("NUMBER 3");
            sample.AddFromConsole();
            sample.Save(buf_path);
            Console.WriteLine(sample);
            Console.WriteLine();
            //--------
            //Number 4
            Console.WriteLine("NUMBER 4");
            ResearchTeam.Load(buf_path, sample);
            sample.AddFromConsole();
            ResearchTeam.Save(buf_path, sample);
            Console.WriteLine(sample);
            //---------
            Console.ReadKey();
        }
    }
}

