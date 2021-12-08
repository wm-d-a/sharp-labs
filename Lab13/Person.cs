using System;

namespace Lab13
{
    [Serializable]
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

        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            if (p != null)
            {
                if (
                    p.name == this.name &
                    p.surname == this.surname &
                    p.birth == this.birth
                ) return true;
                return false;
            }
            else throw new System.Exception("Невозможно сравнить объекты");
        }
        public override int GetHashCode() => (name.Length + surname.Length + birth.Second) * 0xFFFFFF;
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);
        public virtual object DeepCopy() =>
            new Person(
                this.name, this.surname,
                new DateTime(birth.Year, birth.Month, birth.Day)
            );
    }
}