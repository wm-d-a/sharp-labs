using System.Collections.Generic;

namespace Lab10
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam rt1, ResearchTeam rt2)
        {
            if (rt1.Papers.Count > rt2.Papers.Count) return 1;
            if (rt1.Papers.Count < rt2.Papers.Count) return -1;
            return 0;
        }
    }
}