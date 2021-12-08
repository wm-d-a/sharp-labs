using System.Collections.Generic;
using System.Linq;

namespace Lab13
{
    class ResearchTeamCollection
    {
        List<ResearchTeam> researchTeams;
        public ResearchTeamCollection()
        {
            researchTeams = new List<ResearchTeam>();
        }
        public void AddDefaults()
        {
            ResearchTeam rt = new ResearchTeam("sfdghj", "65rewe", 261, TimeFrame.Long);
            rt.AddPapers(
                new Paper(),
                new Paper("Nothing", new Person(), new System.DateTime(2021, 10, 2)),
                new Paper("JGDSJFDSF", new Person("safsdfsd", "fdssdgsdgd", new System.DateTime(1920, 9, 25)), new System.DateTime(2010, 11, 1))
                );
            rt.AddPersons(
                new Person(),
                new Person("fgjhhk", "gfhhj", new System.DateTime(1980, 7, 31))
                );
            researchTeams.Add(rt);

            rt = new ResearchTeam("stghjtresdf", "Nothing", 2213, TimeFrame.TwoYear);
            rt.AddPapers(
                new Paper(),
                new Paper(),
                new Paper("Something", new Person(), new System.DateTime(2021, 10, 2))
                );
            rt.AddPersons(
                new Person(),
                new Person(),
                new Person("gfh", "fdh", new System.DateTime(2202, 8, 20))
                );
            researchTeams.Add(rt);

            rt = new ResearchTeam("drfgh", "fds", 122, TimeFrame.TwoYear);
            rt.AddPapers(
                new Paper("sdfgh", new Person(), new System.DateTime(2021, 10, 2))
                );
            rt.AddPersons(
                new Person()
                );
            researchTeams.Add(rt);
        }
        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            this.researchTeams.AddRange(researchTeams);
        }
        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < researchTeams.Count; i++)
                temp += $"{i + 1}) {researchTeams[i]}";
            return temp;
        }
        public virtual string ToShortString()
        {
            string temp = "";
            for (int i = 0; i < researchTeams.Count; i++)
                temp += $"{i + 1}) {researchTeams[i].ToShortString()}";
            return temp;
        }
        public void SortById() => researchTeams.Sort((x, y) => x.Team.CompareTo(y.Team));
        public void SortByTheme() => researchTeams.Sort(new ResearchTeam());
        public void SortByCountPapers() => researchTeams.Sort(new ResearchTeamComparer());
        public int MinId
        {
            get
            {
                try
                {
                    return researchTeams.Min(x => x.Id);
                }
                catch (System.InvalidOperationException)
                {
                    return -1;
                }
            }
        }
        public IEnumerable<ResearchTeam> ResearchesTwoYear
        {
            get => researchTeams.Where(x => x.TF == TimeFrame.TwoYear);
        }
        public List<ResearchTeam> NGroup(int value)
        {
            return
                researchTeams
                .GroupBy(
                    x => x.Persons.Count,
                    (count, rt) => new { Count = count, Value = rt }
                    )
                .FirstOrDefault(group => group.Count == value).Value.ToList();
        }
    }
}