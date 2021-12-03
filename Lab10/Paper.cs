using System;

namespace Lab10
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
        public virtual object DeepCopy() =>
            new Paper(
                this.Title, this.Author.DeepCopy() as Person,
                new DateTime(Publication.Year, Publication.Month, Publication.Day)
            );
    }
}