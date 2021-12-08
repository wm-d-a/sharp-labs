using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab13
{
    enum TimeFrame { Year, TwoYear, Long }
    [Serializable]
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
                if (papers.Count == 0) return null;
                else return (Paper)papers[papers.Count - 1];
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
        public IEnumerable GetPersonsWithoutPapers()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                bool have_paper = false;
                foreach (Paper item in papers)
                    if (item.Author == (Person)persons[i])
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
                    if (item.Author == (Person)persons[i])
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

        public new ResearchTeam DeepCopy()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return (ResearchTeam)formatter.Deserialize(stream);
        }

        public bool Save(string filename) => Save(filename, this);
        public bool Load(string filename) => Load(filename, this);
        public static bool Save(string filename, ResearchTeam rt)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, rt);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public static bool Load(string filename, ResearchTeam rt)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    ResearchTeam tmp = (ResearchTeam)formatter.Deserialize(fs);
                    rt.Name = tmp.Name;
                    rt.Organization = tmp.Organization;
                    rt.Id = tmp.Id;
                    rt.Papers = tmp.Papers;
                    rt.Persons = tmp.Persons;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Input data: Name, Surname, Birth");
            char[] separators = "; ".ToCharArray();
            Console.Write("Separator - ';'");
            foreach (var i in separators) Console.Write(i);
            Console.WriteLine();
            try
            {
                string[] diff = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Persons.Add(new Person(diff[0], diff[1], Convert.ToDateTime(diff[2])));
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
