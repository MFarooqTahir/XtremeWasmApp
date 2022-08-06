namespace XtremeWasmApp.Models
{
    public class WinPrizeResponse
    {
        //Vno, Pkt, Win_qty, Vid, (s_prize1 + p_prize1) as Prize1, (s_prize2 + p_prize2) as prize2
        public int Vno { get; set; }
        public string Pkt { get; set; }
        public string Vid { get; set; }
        public int Win_qty { get; set; }
        public double Prize1 { get; set; }
        public double Prize2 { get; set; }
        public double Win_Amt { get; set; }


        //if vid starts with 1, then sale, else purchase
    }
}
