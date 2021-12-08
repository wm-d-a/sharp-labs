using System;

namespace Lab13
{
    [Serializable]
    class Team : INameAndCopy, IComparable
    {
        protected string organization;
        protected int id;
        public Team()
        {
            organization = "NoOrg";
            id = 75343;
        }
        public Team(string organization, int id)
        {
            this.organization = organization;
            this.id = id;
        }
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }
        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0) throw new System.Exception("Отрицательный ID организации");
                id = value;
            }
        }
        public string Name
        {
            get => organization;
            set { organization = value; }
        }
        public virtual object DeepCopy() => new Team(this.organization, this.id);
        public override bool Equals(object obj)
        {
            Team team = obj as Team;
            if (team != null)
            {
                if (team.id == this.id & team.organization == this.organization) return true;
                return false;
            }
            else throw new System.Exception("Невозможно сравнить объекты");
        }
        public override int GetHashCode() => (id + organization.Length) * 0xFFFFFF;
        public override string ToString() => $"{this.organization} - {this.id}";
        public static bool operator ==(Team t1, Team t2) => t1.Equals(t2);
        public static bool operator !=(Team t1, Team t2) => !(t1 == t2);
        public int CompareTo(object obj)
        {
            Team t = obj as Team;
            if (t != null) return this.id.CompareTo(t.id);
            else throw new System.Exception("Невозможно сравнить объекты");
        }
    }
}