namespace XtremeWasmApp.Models
{
    public class tbl_devices
    {
        public int ID { get; set; }
        public string AppVer { get; set; }
        public string DSerial { get; set; }
        public string Pass { get; set; }
        public string DType { get; set; }
        public string Mbm { get; set; }
        public string Mbn { get; set; }
        public string Mbs { get; set; }
        public string Proc { get; set; }
        public string Proch { get; set; }
        public string Hdd { get; set; }
        public string Hdc { get; set; }
        public string Winver { get; set; }
        public string Ver { get; set; }
        public string OS { get; set; }
        public DateTime cDate { get; set; }
        public bool? Active { get; set; }
        public string SType { get; set; }
        public bool? DeviceBlock { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LoginExpireTime { get; set; }
        public bool? RegFirst { get; set; }
    }
}