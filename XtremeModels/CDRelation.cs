namespace XtremeModels
{
    public class CDRelation
    {
        public int ID { get; set; }
        public int CompanyID { get; set; } = -1;
        public int DeviceID { get; set; } = -1;
        public int Limit { get; set; } = -1;
        public string UName { get; set; } = "";
        public string rCode { get; set; } = "";
        public bool Active { get; set; } = false;
        public string PName { get; set; } = "";
        public string City { get; set; } = "";
        public byte[] Pic { get; set; } = Array.Empty<byte>();
        public string Pcode { get; set; } = "";
        public bool Enabled { get; set; } = false;
        public bool rBlocked { get; set; } = false;
        public bool Block { get; set; }

        public CDRelation(CDRelation other)
        {
            CompanyID = other.CompanyID;
            DeviceID = other.DeviceID;
            Limit = other.Limit;
            Active = other.Active;
            Enabled = other.Enabled;
            UName = other.UName;
        }

        public CDRelation()
        {
        }
    }
}