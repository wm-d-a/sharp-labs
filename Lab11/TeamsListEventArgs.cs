namespace Lab11
{
    public class TeamsListEventArgs : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string Changes { get; set; }
        public int NumberOfEnement { get; set; }
        public TeamsListEventArgs(string Colname, string Ch, int numOfEl)
        {
            CollectionName = Colname;
            Changes = Ch;
            NumberOfEnement = numOfEl;
        }
        public TeamsListEventArgs() : this("SomCollection", "Some changes", 0) { }
        public override string ToString()
        {
            return string.Format("Name of collection {0} \n Changes {1} \n Number of new element {2} \n", CollectionName, Changes, NumberOfEnement.ToString());
        }
    }

}

