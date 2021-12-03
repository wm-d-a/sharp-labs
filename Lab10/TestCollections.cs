using static System.Console;
using System;
using System.Collections.Generic;

namespace Lab10
{
    class TestCollections
    {
        List<Team> listTeams;
        List<string> listStrings;
        Dictionary<Team, ResearchTeam> dictTeamRTs;
        Dictionary<string, ResearchTeam> dictStrRTs;
        static ResearchTeam generateRT(int value) => new ResearchTeam() {Team = new Team("", value)};
        public TestCollections(int count)
        {
            listTeams = new List<Team>();
            listStrings = new List<string>();
            dictTeamRTs = new Dictionary<Team, ResearchTeam>();
            dictStrRTs = new Dictionary<string, ResearchTeam>();

            for (int i = 0; i < count; i++)
            {
                listTeams.Add(new Team("", i + 1));
                listStrings.Add($"{i + 1}");
                dictTeamRTs.Add(new Team("", i + 1), generateRT(i + 1));
                dictStrRTs.Add($"{i + 1}", generateRT(i + 1));
            }
        }
        public void Result(int value)
        {
            WriteLine($"Затраченное время для поиска {value}:");
            int start, end;
            start = Environment.TickCount;
            int id = listTeams.FindIndex(x => x == new Team("", value));
            end = Environment.TickCount;
            WriteLine($"List<Team>: {end - start}");
            WriteLine(id == -1 ? "Элемент не найден" : $"Найденный элемент:\n{listTeams[id]}");

            start = Environment.TickCount;
            id = listStrings.FindIndex(x => x == $"{value}");
            end = Environment.TickCount;
            WriteLine($"List<string>: {end - start}");
            WriteLine(id == -1 ? "Элемент не найден" : $"Найденный элемент:\n{listStrings[id]}");
            
            ResearchTeam exists = null;
            start = Environment.TickCount;
            try
            {
                exists = dictTeamRTs[new Team("", value)];
            }
            catch (System.Exception)
            {
                exists = null;
            }
            end = Environment.TickCount;
            WriteLine($"Dictionary<Team, ResearchTeam>: {end - start}");
            WriteLine(exists is null ? "Элемент не найден" : $"Найденный элемент:\n{exists.ToString()}");
            
            exists = null;
            start = Environment.TickCount;
            try
            {
                exists = dictStrRTs[$"{value}"];
            }
            catch (System.Exception)
            {
                exists = null;
            }
            end = Environment.TickCount;
            WriteLine($"Dictionary<string, ResearchTeam>: {end - start}");
            WriteLine(exists is null ? "Элемент не найден" : $"Найденный элемент:\n{exists.ToString()}");
        }
    }
}