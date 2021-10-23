using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    enum Frequency
    {
        Weekly,
        Monthly,
        Yearly,
    }
    class Article {
        private Person human;
        private string articleName;
        private double rating;

        //Конструкторы
        public Article(Person human, string articleName, double rating) {
            this.human = human;
            this.articleName = articleName;
            this.rating = rating;
        }
        public Article() {
            this.human = new Person("Name", "Surname", new DateTime());
            this.articleName = "Article Name";
            this.rating = 0.0;
        }
        //------------------
        public override string ToString()
        {
            string buf = string.Format("Author: {0}; Article name: {1}; Rating: {2};", this.human.ToString(), this.articleName, this.rating);
            return buf;
        }
        //Свойства 
        public Person Human {
            get { return this.human; }
            set { this.human = value; }
        }
        public string ArticleName {
            get { return this.articleName; }
            set { this.articleName = value; }
        } 
        public double Rating {
            get { return this.rating; }
            set { this.rating = value; }
        }

    }
    class Magazine
    {
        private string magazineName;
        private Frequency magazineOut;  // периодичность выхода
        private System.DateTime dateOut;
        private int circulation; // тираж
        private Article[] articles;
        //Конструкторы
        public Magazine(string magazineName, Frequency magazineOut, System.DateTime dateOut, int circulation)
        {
            this.magazineName = magazineName;
            this.magazineOut = magazineOut;
            this.dateOut = dateOut;
            this.circulation = circulation;
        }
        public Magazine()
        {
            this.magazineName = "MagazineName";
            this.magazineOut = Frequency.Monthly;
            this.dateOut = new DateTime();
            this.circulation = 0;
        }
        // Свойства
        public string MagazineName
        {
            get { return this.magazineName; }
            set { this.magazineName = value; }
        }
        public Frequency MagazineOut
        {
            get { return this.magazineOut; }
            set { this.magazineOut = value; }
        }
        public DateTime DateOut
        {
            get { return this.dateOut; }
            set { this.dateOut = value; }
        }
        public int Circulation
        {
            get { return this.circulation; }
            set { this.circulation = value; }
        }
        public Article[] Articles {
            get {
                return this.articles;
            }
            set { this.articles = value; }
        }
        public double Avg {
            get {
                double sum = 0;
                for (int i = 0; i < this.articles.Length; i++) {
                    sum += articles[i].Rating;
                }
                double avg = sum / articles.Length;
                return avg;
            }
        }
        public bool this[Frequency index] {
            get { 
                if (magazineOut == Frequency) 
            }
        }
        // Метод
        public void AddArticles(Article article) {
            this.articles.Append(article);
        }
        public override string ToString() {
            string info = "";
            info += "Magazine Name: " + this.magazineName + '\n';
            info += "Output frequency: " + this.magazineOut + '\n';
            info += "Release date" + this.dateOut.Year + " " + this.dateOut.Month + " " + this.dateOut.Day + " " + '\n';
            info += "Circulation: " + this.circulation + '\n';
            info += "\nArticles\n";
            for (int i = 0; i < this.articles.Length; i++) {
                info += "Article " + i + '\n';
                info += this.articles[i].ToString();
            }
            return info;
        }
        public virtual string ToShortString() {
            string info = "";
            info += "Magazine Name: " + this.magazineName + '\n';
            info += "Output frequency: " + this.magazineOut + '\n';
            info += "Release date: " + this.dateOut.Year + " " + this.dateOut.Month + " " + this.dateOut.Day + " " + '\n';
            info += "Circulation: " + this.circulation + '\n';
            info += "Avg rating" + Avg;
            return info;
        }
    }
    class lab7
    {
        static void Main(string[] args)
        {
            Magazine sample = new Magazine("Top Posters", Frequency.Weekly, new DateTime(2021, 10, 22), 500);
            //sample.Articles = new Article[5];
            Article[] articles = { 
                new Article(new Person(), "First Article", 4.6),
                new Article(new Person(), "Second Article", 4.1),
                new Article(new Person(), "Thirthy Article", 4.9),
            };
            sample.Articles = articles;
            Console.WriteLine(sample.ToShortString());
            Console.ReadLine();
        }
    }
    class Person
    {
        private string name;
        private string surname;
        private DateTime date;
        public Person(string name, string surname, DateTime date)
        {
            this.name = name;
            this.surname = surname;
            this.date = date;
        }
        public Person()
        {
            this.name = "SomeName";
            this.surname = "SomeSurname";
            this.date = new DateTime();
        }
        public string GetName
        { 
            get { return this.name; }
            set { this.name = value; }
        }
        public string GetSurname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
            public System.DateTime GetDate
            {
                get { return this.date; }
                set { this.date = value; }
            }
            public int Nothing
            {
                get { return this.date.Year; }
                set { this.date = new DateTime(value, date.Month, date.Day); }
            }

            public override string ToString()
            {
                string buf = string.Format("Person {0}, {1}, {2}", name, surname, date);
                return buf;
            }
            public virtual string ToShortString()
            {
                string buf = string.Format("Person {0}, {1}", name, surname);
                return buf;
            }
    }
}
