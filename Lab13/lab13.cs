using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab13
{
    class lab13
    {
        static void Main(string[] args)
        {
            //NUMBER 1
            Console.WriteLine("NUMBER 1\n");
            ResearchTeam sample1 = new ResearchTeam();
            ResearchTeam sample1Copy = sample1.DeepCopy();

            Console.WriteLine("\nNUMBER 2\n");
            Console.Write("Input file name: ");
            //testname
            string filename = System.Convert.ToString(Console.ReadLine());
            string buf = @"C:\C_SHARP\labs_\Lab13\" + filename + ".txt";
            try
            {
                sample1.Load(buf);
            }
            catch {
                File.Create(buf);
            }
            Console.WriteLine(sample1.ToString());

            Console.WriteLine("\nNUMBER 3\n");
            sample1.AddFromConsole();
            sample1.Save(buf);

            Console.WriteLine("\nNUNBER 4\n");
            ResearchTeam.Load(buf, sample1);
            sample1.AddFromConsole();
            ResearchTeam.Save(buf, sample1);
            Console.WriteLine(sample1);
            Console.ReadLine();
        }
    }
}
