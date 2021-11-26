using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
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
        public override string ToString() => $"Name: {name}; Surname: {surname}; Date of birth: {birth.ToShortDateString()}";
        public string ToShortString() => $"Name: {name}; Surname: {surname}";

        // lab 9
        virtual public Person DeepCopy()
        {
            return new Person
            {
                name = this.Name,
                surname = this.Surname,
                birth = this.birth
            };
        }
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
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }

}
