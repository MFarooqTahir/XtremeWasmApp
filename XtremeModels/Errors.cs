using System;

namespace XtremeModels
{
    public class Errors
    {
        public int ID { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string method { get; set; }
        public string page { get; set; }
        public int user_id { get; set; }
        public string origin { get; set; }
        public DateTime localdatetime { get; set; }
        public DateTime utcdatetime { get; set; }
    }
}