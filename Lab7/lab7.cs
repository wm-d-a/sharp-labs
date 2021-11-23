using System;
using static System.Console;
using System.Collections.Generic;

namespace Lab7
{
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
    }

    enum TimeFrame { Year, TwoYear, Long }
    class ResearchTeam
    {
        string theme, organization;
        int id;
        TimeFrame tf;
        Paper[] papers;
        public ResearchTeam()
        {
            theme = "NoTheme";
            organization = "NoOrg";
            id = 75343;
            tf = TimeFrame.Year;
            papers = new Paper[] {};
        }
        public ResearchTeam(string theme, string organization, int id, TimeFrame tf) : base()
        {
            this.theme = theme;
            this.organization = organization;
            this.id = id;
            this.tf = tf;
        }
        public Paper Paper
        {
            get
            {
                DateTime max = new DateTime();
                Paper buf = new Paper();
                if(papers.Length == 0) return null;
                for (int i = 0; i < papers.Length; i++)
                {
                    if (papers[i].Publication > max) {
                        max = papers[i].Publication;
                        buf = papers[i];
                    }
                }   
                return buf;
            }
        }
        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
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
            string temp = $"{theme} {organization} {id} {tf}\n";
            foreach (var item in papers) temp += item + "\n";
            return temp;
        }
        public string ToShortString() => $"{theme} {organization} {id} {tf}";
    }


    class lab7
    {
        static void Main(string[] args)
        {
            ResearchTeam RT = new ResearchTeam();    
            WriteLine($"1. До присвоения значения свойствам (короткая):\n{RT.ToShortString()}\n");
            WriteLine("2. Проверка индексатора:");
            WriteLine($"Year: {RT[TimeFrame.Year]}");
            WriteLine($"TwoYear: {RT[TimeFrame.TwoYear]}");
            WriteLine($"Long: {RT[TimeFrame.Long]}");
            WriteLine();
            RT.Id = 13343;
            RT.Organization = "Leeodl Dosl";
            RT.Theme = "Ice ice ice";
            RT.TF = TimeFrame.Long;
            RT.Papers = new Paper[]
            {
                new Paper("Gg", new Person(), new DateTime(2001, 2, 3)),
                new Paper()
            };
            WriteLine($"3. После присвоения значения свойствам:\n{RT.ToString()}");
            RT.AddPapers(new Paper("Afecs", new Person(), new DateTime(2013, 2, 4)), new Paper());
            WriteLine($"4. После добавления новый статей:\n{RT.ToString()}");
            WriteLine($"5. Последняя статья:\n{RT.Paper}");
            WriteLine();

            int nr, nc;
            char[] separators = ",. ".ToCharArray();
            try
            {
                Write("6. В качестве разделителей можно использовать: ");
                foreach (var i in separators) Write(i);
                WriteLine("\nВведите число строк и число столбцов");
                string[] temp = ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                nr = Convert.ToInt32(temp[0]);
                nc = Convert.ToInt32(temp[1]);
                WriteLine($"Строк: {nr}\nСтолбцов: {nc}");
            }
            catch (System.Exception)
            {
                WriteLine("Введены неверные данные, попробуйте ещё раз.");
                return;
            }

            Paper[] p1 = new Paper[nr * nc];
            Paper[,] p2 = new Paper[nr, nc];
            Paper[][] p3 = new Paper[nr][];
            for (int i = 0; i < p3.Length; i++) p3[i] = new Paper[nc];

            WriteLine("Затраченное время:");
            int start, end;
            start = Environment.TickCount;
            for(int i = 0; i < nr * nc; i++) p1[i] = new Paper();
            end = Environment.TickCount;
            WriteLine($"Одномерный массив = {end - start}");

            start = Environment.TickCount;
            for(int i = 0; i < nr; i++)
                for(int j = 0; j < nc; j++) p2[i, j] = new Paper();
            end = Environment.TickCount;
            WriteLine($"Двумерный массив = {end - start}");
            
            start = Environment.TickCount;
            for(int i = 0; i < nr; i++)
                for(int j = 0; j < nc; j++) p3[i][j] = new Paper();
            end = Environment.TickCount;
            WriteLine($"Зубчатый массив = {end - start}");
        }
    }
}
