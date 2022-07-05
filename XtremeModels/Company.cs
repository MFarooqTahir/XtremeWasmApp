namespace XtremeModels
{
    public class Company
    {
        public int ID { get; set; } = -1;
        public string PName { get; set; } = "";
        public string City { get; set; } = "";
        public byte[] Pic { get; set; } = Array.Empty<byte>();
        public string Pcode { get; set; } = "";
        public bool IsDealer { get; set; }
        public string DCode { get; set; }
        public int DealerCode { get; set; }
        public bool Qtyuser { get; set; }
        public string WebApiD { get; set; } = "";
        public double Sfc1 { get; set; }
        public double Sfc2 { get; set; }
        public double Std1 { get; set; }
        public double Std2 { get; set; }
        public bool punjab { get; set; }
        public int FCode { get; set; }
        public char Stype { get; set; }
    }
}