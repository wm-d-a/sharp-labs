using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
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
        public override string ToString() => $"Title: {Title}; Author: {Author}; Publication: {Publication.ToShortDateString()}";

        // lab 9
        virtual public Paper DeepCopy()
        {
            return new Paper
            {
                Title = this.Title,
                Author = this.Author,
                Publication = this.Publication 
            };
        }
        public override bool Equals(object obj)
        {
            Paper other = obj as Paper;
            if ((other.Title == this.Title) & (other.Author == this.Author) & (other.Publication == this.Publication))
            {
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
