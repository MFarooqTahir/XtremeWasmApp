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
string.Equals(PCode, data.PCode, StringComparison.Ordinal) &&
string.Equals(PName, data.PName, StringComparison.Ordinal) &&
string.Equals(Balance, data.Balance, StringComparison.Ordinal) &&
                   DId == data.DId &&
string.Equals(BId, data.BId, StringComparison.Ordinal) &&
string.Equals(City, data.City, StringComparison.Ordinal) &&
string.Equals(Date, data.Date, StringComparison.Ordinal) &&
string.Equals(Category, data.Category, StringComparison.Ordinal);
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