namespace XtremeModels
{
    public class EntryData
    {
        public Transaction transaction { get; set; }
        public int xmkey { get; set; }
        public string xid { get; set; }
        public char xpid { get; set; }
        public char xdtype { get; set; }
        public string dbf { get; set; }
        public int xmode { get; set; }
        public double xpamt1 { get; set; }
        public double xpamt2 { get; set; }
        public int lmkey { get; set; }
        public int llmkey { get; set; }
    }
}