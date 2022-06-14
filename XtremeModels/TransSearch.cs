namespace XtremeModels
{
    public class TransSearch
    {
        public string Vid { get; set; }
        public int Vno { get; set; }
        public double prize1 { get; set; }
        public double prize2 { get; set; }
        public PrizeType Type { get; set; }
        public LimDem lb { get; set; }
    }

    public enum LimDem
    {
        L = 0,
        D = 1,
        M = 2,
    }

    public enum PrizeType
    {
        S = 0,
        P = 1,
    }
}