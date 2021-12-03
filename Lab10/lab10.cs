using System;
using Lab10;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeamCollection resTeams = new ResearchTeamCollection();
            resTeams.AddDefaults();
            {
                Console.WriteLine("Number 1");
                Console.WriteLine(resTeams);
                Console.WriteLine();
            }
            {
                Console.WriteLine("Number 2");
                Console.WriteLine("Sort RegNumber");
                resTeams.SortRegNumber();
                Console.WriteLine(resTeams);
                Console.WriteLine("Sort theme name");
                resTeams.SortThemeName();
                Console.WriteLine(resTeams);
                Console.WriteLine("Sort Papers");
                resTeams.SortPapers();
                Console.WriteLine(resTeams);
                Console.WriteLine();

            }
            {
                Console.WriteLine("Number 3");
                Console.WriteLine($"Min regNumber: {resTeams.MinRegNumber}");
                Console.WriteLine("ResTeams for Two Years:");
                foreach (var item in resTeams.ResearchesTwoYear) Console.WriteLine(item);
                Console.WriteLine("Conunt Persons (2):");
                foreach (var item in resTeams.NGroup(2)) Console.WriteLine(item);
                Console.WriteLine();

            }
            {
                Console.WriteLine("Number 4");
                TestCollections testTeams = new TestCollections(1000000);
                testTeams.Result(1);
                testTeams.Result(2323);
                testTeams.Result(234523);
                testTeams.Result(7654);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
