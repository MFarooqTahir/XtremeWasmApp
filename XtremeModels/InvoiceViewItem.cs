namespace XtremeModels
{
    public class InvoiceViewItem
    {
        public int MKey { get; set; }
        public int InvNo { get; set; }
        public string Category { get; set; }
        public string CatValue { get; set; }
        public LimDem LD { get; set; }
        public string Reference { get; set; }
        public bool Printable { get; set; }
    }
}