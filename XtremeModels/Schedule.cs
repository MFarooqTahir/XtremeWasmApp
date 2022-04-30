using System;

namespace XtremeModels
{
    public class Schedule
    {
        public int mkey { get; set; }

        public int DId { get; set; }
        public string BId { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Cat { get; set; }
        public string db { get; set; }
        public DateTime Period { get; set; }
        public int Prz2 { get; set; }
        public string WebApiI { get; set; }
        public bool Uac { get; set; }
    }
}