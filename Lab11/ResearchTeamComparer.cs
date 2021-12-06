using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam l_Team, ResearchTeam R_Team)
        {
            return l_Team.ListOfPublication.Count.CompareTo(R_Team.ListOfPublication.Count);
        }
    }
}
