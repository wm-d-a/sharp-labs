using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab10
{
    enum TimeFrame { Year, TwoYear, Long }
    class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {
        string theme;
        TimeFrame tf;
        // ArrayList papers, persons;
        List<Paper> papers;
        List<Person> persons;
        public ResearchTeam()
            : base()
        {
            theme = "NoTheme";
            tf = TimeFrame.Year;
            papers = new List<Paper>();
            persons = new List<Person>();
        }
        public ResearchTeam(string theme, string organization, int id, TimeFrame tf)
            : base(organization, id)
        {
            this.theme = theme;
            this.id = id;
            this.tf = tf;
            papers = new List<Paper>();
            persons = new List<Person>();
        }
        public Paper Paper
        {
            get
            {
                if(papers.Count == 0) return null;
                else return (Paper) papers[papers.Count - 1];
            }
        }
        public Team Team
        {
            get => new Team(this.organization, this.id);
            set
            {
                organization = value.Organization;
                id = value.Id;
            }
        }
        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }
        public TimeFrame TF
        {
            get { return tf; }
            set { tf = value; }
        }
        public List<Paper> Papers
        {
            get { return papers; }
            set { papers = value; }
        }
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }
        public bool this[TimeFrame tf] { get => this.tf == tf; }
        public void AddPapers(params Paper[] papers) => this.papers.AddRange(papers);
        public void AddPersons(params Person[] persons) => this.persons.AddRange(persons);
        public override string ToString()
        {
            string temp = $"{theme} {organization} {id} {tf}\nУчастники ({persons.Count}):\n";
            foreach (var item in persons) temp += item + "\n";
            temp += $"Публикации:\n";
            foreach (var item in papers) temp += item + "\n";
            return temp;
        }
        public string ToShortString() => $"{theme} {organization} {id} {tf}";
        public override object DeepCopy()
        {
            ResearchTeam rt = new ResearchTeam(theme, organization, id, tf);
            var papers_new = new List<Paper>();
            foreach (Paper item in papers) papers_new.Add((Paper) item.DeepCopy());
            rt.papers = papers_new;
            var persons_new = new List<Person>();
            foreach (Person item in persons) persons_new.Add((Person) item.DeepCopy());
            rt.persons = persons_new;
            return rt;
        }
        public IEnumerable GetPersonsWithoutPapers()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                bool have_paper = false;
                foreach (Paper item in papers)
                    if (item.Author == (Person) persons[i])
                    {
                        have_paper = true;
                        break;
                    }
                if (have_paper) continue;
                else yield return persons[i];
            }
        }
        public IEnumerable GetPersonsWithPapers()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                bool have_paper = false;
                foreach (Paper item in papers)
                    if (item.Author == (Person) persons[i])
                    {
                        have_paper = true;
                        break;
                    }
                if (!have_paper) continue;
                else yield return persons[i];
            }
        }
        public IEnumerable GetPapersForLastYears(int n)
        {
            int year = DateTime.Now.Year - n;
            for (int i = 0; i < papers.Count; i++)
                if ((papers[i] as Paper).Publication.Year > year) yield return papers[i];
        }
        public IEnumerable GetPapersForLastYear() => GetPapersForLastYears(1);
        public IEnumerator GetEnumerator() => new ResearchTeamEnumerator(persons);
        public int Compare(ResearchTeam rt1, ResearchTeam rt2) => string.Compare(rt1.Theme, rt2.Theme);
    }
}