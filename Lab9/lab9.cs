using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    // old
    class Paper
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime Publication { get; set; }
        public Paper()
        {
            Title = "NoTitle";
            Author = new Person();
            Publication = new DateTime();
        }
        public Paper(string title, Person author, DateTime publication)
        {
            this.Title = title;
            this.Author = author;
            this.Publication = publication;
        }
        public override string ToString() => $"{Title} {Author} {Publication.ToShortDateString()}";

        // lab 9
        public override bool Equals(object obj)
        {
            Paper other = obj as Paper;
            if ((other.Title == this.Title) & (other.Author == this.Author) & (other.Publication == this.Publication)) {
                return true;
            }
            else return false;
        }
        public static bool operator ==(Paper sample1, Paper sample2)
        {
            if ((sample1.Title.GetHashCode() == sample2.Title.GetHashCode()) & (sample1.Publication.GetHashCode() == sample2.Publication.GetHashCode()) & (sample1.Author.GetHashCode() == sample2.Author.GetHashCode()))
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
            if ((sample1.Title == sample2.Title) & (sample1.Author == sample2.Author) & (sample1.Publication == sample2.Publication))
            {
                return true;
            }
            else return false;
            */
        }
        public static bool operator !=(Paper sample1, Paper sample2)
        {
            if ((sample1.Title.GetHashCode() == sample2.Title.GetHashCode()) & (sample1.Author.GetHashCode() == sample2.Author.GetHashCode()) & (sample1.Publication.GetHashCode() == sample2.Publication.GetHashCode()))
            {
                return false;
            }
            return true;
            /*
            if ((sample1.Title != sample2.Title) & (sample1.Author != sample2.Author) & (sample1.Publication != sample2.Publication))
            {
                return true;
            }
            else return false;
            */
        }
    }
    class Person
    {
        string name;
        string surname;
        DateTime birth;
        public Person()
        {
            name = "NoName";
            surname = "NoSurname";
            birth = new DateTime(2000, 1, 1);
        }
        public Person(string name, string surname, DateTime birth)
        {
            this.name = name;
            this.surname = surname;
            this.birth = birth;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public DateTime Birth
        {
            get { return birth; }
            set { birth = value; }
        }
        public int Year
        {
            get { return Birth.Year; }
            set { Birth = new DateTime(value, Birth.Month, Birth.Day); }
        }
        public override string ToString() => $"{name} {surname} {birth.ToShortDateString()}";
        public string ToShortString() => $"{name} {surname}";
        
        // lab 9
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if ((other.name == this.name) & (other.surname == this.surname) & (other.birth == this.birth))
            {
                return true;
            }
            else return false;
        }
        public static bool operator ==(Person sample1, Person sample2)
        {
            if ((sample1.name.GetHashCode() == sample2.name.GetHashCode()) & (sample1.surname.GetHashCode() == sample2.surname.GetHashCode()) & (sample1.birth.GetHashCode() == sample2.birth.GetHashCode()))
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
            /*if ((sample1.name == sample2.name) & (sample1.surname == sample2.surname) & (sample1.birth == sample2.birth))
            {
                return true;
            }
            else return false;*/
        }
        public static bool operator !=(Person sample1, Person sample2)
        {
            if ((sample1.name.GetHashCode() == sample2.name.GetHashCode()) & (sample1.surname.GetHashCode() == sample2.surname.GetHashCode()) & (sample1.birth.GetHashCode() == sample2.birth.GetHashCode()))
            {
                return false;
            }
            return true;

            /*if ((sample1.name != sample2.name) & (sample1.surname != sample2.surname) & (sample1.birth != sample2.birth))
            {
                return true;
            }
            else return false;*/
        }
        public override int GetHashCode() {
            return this.GetHashCode();
        }
    }

    enum TimeFrame { Year, TwoYear, Long }
    class ResearchTeam : Team
    {
        private string theme;
        private TimeFrame tf;
        private Paper[] papers;
        private Person[] persons;
        public ResearchTeam()
        {
            theme = "NoTheme";
            orgName = "NoOrg";
            regNumber = 75343;
            tf = TimeFrame.Year;
            papers = new Paper[] { };
        }
        public ResearchTeam(string theme, string organization, int id, TimeFrame tf) : base()
        {
            this.theme = theme;
            this.orgName = organization;
            this.regNumber = id;
            this.tf = tf;
        }
        public Paper Paper
        {
            get
            {
                if (papers.Length == 0) return null;
                else return papers[papers.Length - 1];
            }
        }
        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }
        public string Organization
        {
            get { return orgName; }
            set { orgName = value; }
        }
        public int Id
        {
            get { return regNumber; }
            set { regNumber = value; }
        }
        public TimeFrame TF
        {
            get { return tf; }
            set { tf = value; }
        }
        public Paper[] Papers
        {
            get { return papers; }
            set { papers = value; }
        }
        public bool this[TimeFrame tf] { get => this.tf == tf; }
        public void AddPapers(params Paper[] papers)
        {
            List<Paper> list = new List<Paper>(this.papers);
            list.AddRange(papers);
            this.papers = list.ToArray();
        }
        public override string ToString()
        {
            string temp = $"{theme} {orgName} {regNumber} {tf}\n";
            foreach (var item in papers) temp += item + "\n";
            return temp;
        }
        public string ToShortString() => $"{theme} {orgName} {regNumber} {tf}";

        // lab 9
        public override bool Equals(object obj)
        {
            ResearchTeam other = obj as ResearchTeam;
            if ((other.theme == this.theme) & (other.orgName == this.orgName) & (other.regNumber == this.regNumber) & (other.tf == this.tf)) {
                return true;
            }
            return false;
        }

        public static bool operator ==(ResearchTeam sample1, ResearchTeam sample2) {
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
    /*interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }*/

    // new
    class Team {
        protected string orgName;
        protected int regNumber;
        public Team(string orgName, int regNumber) {
            this.orgName = orgName;
            this.regNumber = regNumber;
        }
        public Team() {
            this.orgName = "DefaultOrgName";            
            this.regNumber = 0;            
        }
        // свойства
        string OrgName {
            get { return this.orgName; }
            set { this.orgName = value; }
        }
        int RegNumber {
            get { return this.regNumber;  }
            set { 
                // ДОБАВИТЬ ИСКЛЮЧЕНИЕ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (value > 0) {
                    this.regNumber = value;
                }
            }
        }
        // переопределения
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Team other = obj as Team;
            if ((other.orgName == this.orgName) & (other.regNumber == this.regNumber)) {
                return true;
            }
            return false;
        }
        public static bool operator ==(Team sample1, Team sample2) {
            if ((sample1.orgName.GetHashCode() == sample2.OrgName.GetHashCode()) & (sample1.regNumber.GetHashCode() == sample2.regNumber.GetHashCode()))
            {
                return true;
            }
            else {
                if (sample1.Equals(sample2)) {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Team sample1, Team sample2) {
            if ((sample1.orgName.GetHashCode()== sample2.OrgName.GetHashCode()) & (sample1.regNumber.GetHashCode() == sample2.regNumber.GetHashCode()))
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            string result = "Organization name: " + this.orgName + "Registration number: " + Convert.ToString(this.regNumber); 
            return result;
        }
    }
    class lab9
    {
        static void Main(string[] args)
        {

        }
    }
}
