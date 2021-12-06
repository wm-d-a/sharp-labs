using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class lab11 
    {
        static void Main(string[] args)
        {
            //Number 1
            ResearchTeamCollection sample1 = new ResearchTeamCollection();
            ResearchTeamCollection sample2 = new ResearchTeamCollection();
            //--------
            //Number 2
            TeamsJournal journal1 = new TeamsJournal();
            TeamsJournal journal2 = new TeamsJournal();
            
            sample1.ResearchTeamAdded += journal1.TeamEventHandler;
            sample1.ResearchTeamInserted += journal1.TeamEventHandler;

            sample1.ResearchTeamAdded += journal2.TeamEventHandler;
            sample1.ResearchTeamInserted += journal2.TeamEventHandler;

            sample2.ResearchTeamAdded += journal2.TeamEventHandler;
            sample2.ResearchTeamInserted += journal2.TeamEventHandler;
            //--------
            //Number 3
            sample1.AddDefaults();
            sample1.AddResearchTeams(new ResearchTeam("sampleNname", "---", 23, TimeFrame.Year));
            sample2.AddDefaults();
            sample2.InsertAt(1, new ResearchTeam("sampleName2", "---", 23, TimeFrame.Year));
            sample2.InsertAt(6, new ResearchTeam("sampleName3", "---", 23, TimeFrame.Year));
            //--------
            //Number 4
            Console.WriteLine(journal1.ToString());
            Console.WriteLine();
            Console.WriteLine(journal2.ToString());
            Console.ReadLine();
            //--------
        }
    }
}
