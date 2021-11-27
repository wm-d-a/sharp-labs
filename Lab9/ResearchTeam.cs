using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class ResearchTeam : Team, INameAndCopy
    {
        private string theme;
        private TimeFrame tf;
        private List<Paper> papers = new List<Paper>();
        private List<Person> persons = new List<Person>();
        public ResearchTeam():base()
        {
            this.theme = "NoTheme";
            this.tf = TimeFrame.Year;
            this.papers.Add(new Paper());
            this.persons.Add(new Person()); //???
        }
        public ResearchTeam(string theme, string organization, int id, TimeFrame tf, List<Paper> papers, List<Person> persons) : base(organization, id)
        {
            this.theme = theme;
            this.tf = tf;
            this.papers = papers;
            this.persons = persons;
        }

        public Paper Paper
        {
            get
            {
                DateTime max = new DateTime();
                Paper buf = new Paper();
                if (this.papers.Count == 0) return null;
                for (int i = 0; i < papers.Count; i++)
                {
                    if (this.papers[i].Publication > max)
                    {
                        max = this.papers[i].Publication;
                        buf = this.papers[i];
                    }
                }
                return buf;
            }
        }
        //Свойства
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
        public Team Team {
            get {
                Team buf = new Team(this.orgName, this.regNumber);
                return buf; 
            }
            set {
                Team buf = value;
                this.orgName = buf.OrgName;
                this.regNumber = buf.RegNumber;
            }
        }
        new public string Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        //Методы

        public IEnumerable<Person> GetPersons()
        {
            for (int i = 0; i < persons.Count; i++) {
                if (i == persons.Count)
                {
                    yield break;
                }
                else {
                    bool flag = true;
                    for (int j = 0; j < papers.Count; j++) {
                        if (persons[i] == papers[j].Author) {
                            flag = false;
                        }
                    }
                    if (flag) { }
                    else
                    {
                        yield return persons[i];
                    }
                }
            }
        }
        public IEnumerable<Person> GetPersons2() // number 8
        {
            for (int i = 0; i < persons.Count; i++) {
                if (i == persons.Count)
                {
                    yield break;
                }
                else {
                    for (int j = 0; j < papers.Count; j++) {
                        if (persons[i] == papers[j].Author) {
                            yield return persons[i];
                        }
                    }

                }
            }
        }
        public IEnumerable<Person> GetPersons3() // number 9
        {
            for (int i = 0; i < persons.Count; i++) {
                if (i == persons.Count)
                {
                    yield break;
                }
                else {
                    //bool flag = false;
                    int c = 0;
                    for (int j = 0; j < papers.Count; j++) {
                        if (persons[i] == papers[j].Author) {
                            //Console.WriteLine(persons[i]);
                            c++;
                        }
                    }
                    if (c > 1) {
                        yield return persons[i];
                    }
                }
            }
        }
        public IEnumerable<Paper> GetPapers(int maxYear)
        {
            List<Paper> buf = this.papers;
            buf.Reverse();
            for (int i = 0; i < buf.Count; i++) {
                if (i == buf.Count)
                {
                    yield break;
                }
                else {
                    if (DateTime.Now.Year - buf[i].Publication.Year - maxYear < 0)
                    {
                        yield return buf[i];
                    }
                }
            }
        }
        public IEnumerable<Paper> GetPapersYear() // number 10
        {
            List<Paper> buf = this.papers;
            buf.Reverse();
            for (int i = 0; i < buf.Count; i++) {
                if (i == buf.Count)
                {
                    yield break;
                }
                else {
                    if (DateTime.Now.Year - buf[i].Publication.Year - 1 < 0)
                    {
                        yield return buf[i];
                    }
                }
            }
        }
        public bool this[TimeFrame tf] { get => this.tf == tf; }
        public void AddPapers(List<Paper> papers)
        {
            for (int i = 0; i < papers.Count; i++) {
                this.papers.Add(papers[i]);
            }
        }
        public void AddPersons(List<Person> person)
        {
            for (int i = 0; i < persons.Count; i++) {
                this.persons.Add(person[i]);
            }
        }        
        public void AddPaper(Paper papers)
        {
            this.papers.Add(papers);
        }
        public void AddPerson(Person person)
        {
            this.persons.Add(person);
        }
        public override string ToString()
        {
            string buf = "";
            buf += this.orgName + "\n";
            buf += this.regNumber + "\n";
            buf += this.theme + "\n";
            buf += this.tf + "\n";
            buf += "\nPAPERS:" + "\n";
            for (int i = 0; i < papers.Count; i++) {
                buf += papers[i] + "\n";
            }
            buf += "\nPERSONS:" + "\n";
            for (int i = 0; i < persons.Count; i++) {
                buf += persons[i] + "\n";
            }
            return buf;
        }
        public string ToShortString() => $"{theme} {orgName} {regNumber} {tf}";
        new public object DeepCopy()
        {
            
            List<Paper> cloned_papers = new List<Paper>(); // ???
            for (int i = 0; i < papers.Count; i++) {
                cloned_papers.Add(papers[i]);
            }
            List<Person> cloned_persons = new List<Person>(); // ???
            for (int i = 0; i < persons.Count; i++) {
                cloned_persons.Add(persons[i]);
            }
            return new ResearchTeam
            {
                Theme = this.theme,
                TF = this.tf,
                OrgName = this.orgName,
                RegNumber = this.regNumber,
                Papers = cloned_papers,
                Persons = cloned_persons
            };
        }
        public override bool Equals(object obj)
        {
            ResearchTeam other = obj as ResearchTeam;
            if ((other.theme == this.theme) & (other.orgName == this.orgName) & (other.regNumber == this.regNumber) & (other.tf == this.tf))
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(ResearchTeam sample1, ResearchTeam sample2)
        {
            if ((sample1.theme.GetHashCode() == sample2.theme.GetHashCode()) & (sample1.orgName.GetHashCode() == sample2.orgName.GetHashCode()) & (sample1.regNumber.GetHashCode() == sample2.regNumber.GetHashCode()))
            {
                return true;
            }
            else
            {
                if (sample1.Equals(sample2))
                {
                    return true;
                }
                return false;
            }
            /*
            if ((sample1.theme == sample2.theme) & (sample1.organization == sample2.organization) & (sample1.id == sample2.id) & (sample1.tf == sample2.tf))
            {
                return true;
            }
            return false;
            */
        }
        public static bool operator !=(ResearchTeam sample1, ResearchTeam sample2)
        {
            if ((sample1.theme.GetHashCode() == sample2.theme.GetHashCode()) & (sample1.orgName.GetHashCode() == sample2.orgName.GetHashCode()) & (sample1.tf.GetHashCode() == sample2.tf.GetHashCode()))
            {
                return false;
            }
            return true;
            /*
            if ((sample1.theme != sample2.theme) & (sample1.organization != sample2.organization) & (sample1.id != sample2.id) & (sample1.tf != sample2.tf))
            {
                return true;
            }
            return false;*/
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
