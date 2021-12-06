using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class TeamsJournal
    {
        // List that contains collections changes:
        private List<TeamsJournalEntry> ListOfChanges = new List<TeamsJournalEntry>();
        public void TeamEventHandler(object o, TeamsListEventArgs args)
        {
            ListOfChanges.Add(new TeamsJournalEntry(args.CollectionName, args.Changes, args.NumberOfEnement));
        }
        public override string ToString()
        {
            string str = "";
            foreach (TeamsJournalEntry en in ListOfChanges)
            {
                str += en.ToString() + "\n";
            }
            return str;
        }
    }
}
