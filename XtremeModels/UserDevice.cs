using System;

namespace XtremeModels
{
    public class UserDevice
    {
        public int ID { get; set; } = -1;
        public string AppVer { get; set; } = "";
        public string DSerial { get; set; } = "";
        public string Pass { get; set; } = "";
        public string DType { get; set; } = "";
        public string Mbm { get; set; } = "";
        public string Mbn { get; set; } = "";
        public string Mbs { get; set; } = "";
        public string Proc { get; set; } = "";
        public string Proch { get; set; } = "";
        public string Hdd { get; set; } = "";
        public string Hdc { get; set; } = "";
        public string Winver { get; set; } = "";
        public string Ver { get; set; } = "";
        public string OS { get; set; } = "";
        public DateTime cDate { get; set; } = new DateTime();
        public bool Active { get; set; } = false;
        public bool RegFirst { get; set; } = false;
        public string SType { get; set; }
    }
}