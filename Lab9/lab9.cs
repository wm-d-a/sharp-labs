using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
    
    enum TimeFrame { Year, TwoYear, Long }
    
    class lab9
    {
        static void Main(string[] args)
        {
            {  // NUMBER 1
                Console.WriteLine("NUMBER 1");
                Team sample1 = new Team();
                Team sample2 = new Team();
                //Team test = sample1.DeepCopy();
                Console.WriteLine($"sample1 is sample2? Answer: {sample1.GetHashCode() == sample2.GetHashCode()}");
                Console.WriteLine($"sample1 == sample2? Answer: {sample1 == sample2}");
                Console.WriteLine($"sample1.Equals(sample2)? Answer: {sample1.Equals(sample2)}");
                Console.WriteLine($"sample1 hash: {sample1.GetHashCode()}");
                Console.WriteLine($"sample2 hash: {sample2.GetHashCode()}\n");
            }
            { // NUMBER 2
                Console.WriteLine("Number 2");
                ResearchTeam test = new ResearchTeam();
                try {
                    test.RegNumber = -1;  
                }
                catch(Exception error)
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine();
            }
            { // NUMBER 3
                Console.WriteLine("Number 3");
                ResearchTeam test = new ResearchTeam();
                test.AddPerson(new Person("Dan", "Houser", new DateTime(1995, 12, 2)));
                test.AddPaper(new Paper("OriginalTitle :D", test.Persons[1], new DateTime(2021, 11, 26)));
                Console.WriteLine(test);
                Console.WriteLine();
            }
            { // NUMBER 4
                Console.WriteLine("Number 4");
                ResearchTeam test = new ResearchTeam();
                Console.WriteLine(test.Team);
                Console.WriteLine();
            }
            { // NUMBER 5
                Console.WriteLine("Number 5");
                ResearchTeam test = new ResearchTeam();
                ResearchTeam testCopy = (ResearchTeam) test.DeepCopy();
                test.AddPerson(new Person("AnotherName", "AnotherSurname", new DateTime(1000, 1, 1)));
                test.OrgName = "Another orgName";
                Console.WriteLine(test);
                Console.WriteLine("\n------------------\n");
                Console.WriteLine(testCopy);
                Console.WriteLine();
            }
            { // NUMBER 6
                Console.WriteLine("Number 6");
                ResearchTeam test = new ResearchTeam();
                test.AddPerson(new Person("Dave", "Hudson", new DateTime(1992, 3, 18)));
                Console.WriteLine(test);
                Console.WriteLine("\nUsers without publications:\n");
                foreach (Person i in test.GetPersons()) {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
            { // NUMBER 7
                Console.WriteLine("Number 7");
                ResearchTeam test = new ResearchTeam();
                List<Paper> papers = new List<Paper>();
                papers.Add(new Paper("Django", test.Persons[0], new DateTime(2020, 7, 21)));
                papers.Add(new Paper("Python", test.Persons[0], new DateTime(2020, 3, 6)));
                papers.Add(new Paper("History", test.Persons[0], new DateTime(2015, 2, 12)));
                test.AddPapers(papers);
                foreach (Paper i in test.GetPapers(2)) {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
            // ДОПЫ
            {
                Console.WriteLine("Number 8");
                ResearchTeam test = new ResearchTeam();
                test.AddPerson(new Person("Dave", "Hudson", new DateTime(1992, 3, 18)));
                Console.WriteLine(test);
                Console.WriteLine("\nUsers with publications:\n");
                foreach (Person i in test.GetPersons2())
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
            {
                Console.WriteLine("Number 9");
                ResearchTeam test = new ResearchTeam();
                test.AddPerson(new Person("Dave", "Hudson", new DateTime(1992, 3, 18)));
                test.AddPerson(new Person("Olivia", "Hudson", new DateTime(1990, 6, 1)));
                test.AddPaper(new Paper("Original Title1", test.Persons[0], new DateTime(2020, 2, 2)));
                test.AddPaper(new Paper("Original Title2", test.Persons[0], new DateTime(2020, 2, 2)));
                test.AddPaper(new Paper("Original Title3", test.Persons[2], new DateTime(2020, 2, 2)));
                test.AddPaper(new Paper("Original Title4", test.Persons[2], new DateTime(2020, 2, 2)));
                test.AddPaper(new Paper("Original Title5", test.Persons[2], new DateTime(2020, 2, 2)));
                test.AddPaper(new Paper("Original Title6", test.Persons[1], new DateTime(2020, 2, 2)));
                Console.WriteLine(test);
                Console.WriteLine("\nUsers with 1+ publications:\n");
                foreach (Person i in test.GetPersons3())
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
            {
                Console.WriteLine("Number 10");
                ResearchTeam test = new ResearchTeam();
                List<Paper> papers = new List<Paper>();
                papers.Add(new Paper("Django", test.Persons[0], new DateTime(2020, 7, 21)));
                papers.Add(new Paper("Python1", test.Persons[0], new DateTime(2020, 3, 6)));
                papers.Add(new Paper("Python2", test.Persons[0], new DateTime(2021, 3, 6)));
                papers.Add(new Paper("Python3", test.Persons[0], new DateTime(2021, 3, 6)));
                papers.Add(new Paper("History", test.Persons[0], new DateTime(2015, 2, 12)));
                test.AddPapers(papers);
                foreach (Paper i in test.GetPapersYear())
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
