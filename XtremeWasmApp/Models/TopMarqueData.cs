namespace XtremeWasmApp.Models
{
    public class TopMarqueData
    {
        public string? PCode { get; set; }
        public string? PName { get; set; }
        // public bool Active { get; set; }
        public string Balance { get; set; }
        public int? DId { get; set; }
        public string? BId { get; set; }
        public string? City { get; set; }
        public string? Date { get; set; }
        public string? Category { get; set; }
        //public bool Uac { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TopMarqueData data &&
                   PCode == data.PCode &&
                   PName == data.PName &&
                   Balance == data.Balance &&
                   DId == data.DId &&
                   BId == data.BId &&
                   City == data.City &&
                   Date == data.Date &&
                   Category == data.Category;
        }

        public static bool operator ==(TopMarqueData? left, TopMarqueData? right)
        {
            return EqualityComparer<TopMarqueData>.Default.Equals(left, right);
        }

        public static bool operator !=(TopMarqueData? left, TopMarqueData? right)
        {
            return !(left == right);
        }
    }
}