using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Team : INameAndCopy
    {
        protected string orgName;
        protected int regNumber;
        public Team(string orgName, int regNumber)
        {
            this.orgName = orgName;
            this.regNumber = regNumber;
        }
        public Team()
        {
            this.orgName = "DefaultOrgName";
            this.regNumber = 1;
        }
        // свойства
        public string Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public string OrgName
        {
            get { return this.orgName; }
            set { this.orgName = value; }
        }
        public int RegNumber
        {
            get { return this.regNumber; }
            set
            {
                
                if (value > 0)
                {
                    this.regNumber = value;
                }
                else {
                    throw new Exception("RegNumber < 0");
                }
            }
        }
        public virtual object DeepCopy() 
        {
            return new Team
            {
                OrgName = this.orgName,
                RegNumber = this.regNumber
            };
        }
        // переопределения
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Team other = obj as Team;
            if ((other.orgName == this.orgName) & (other.regNumber == this.regNumber))
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(Team sample1, Team sample2)
        {
            if ((sample1.orgName.GetHashCode() == sample2.OrgName.GetHashCode()) & (sample1.regNumber.GetHashCode() == sample2.regNumber.GetHashCode()))
            {
                return true;
            }
            else
            {
                if (sample1.Equals(sample2))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Team sample1, Team sample2)
        {
            if ((sample1.orgName.GetHashCode() == sample2.OrgName.GetHashCode()) & (sample1.regNumber.GetHashCode() == sample2.regNumber.GetHashCode()))
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            string result = "Organization name: " + this.orgName + "; Registration number: " + Convert.ToString(this.regNumber);
            return result;
        }
    }
}
