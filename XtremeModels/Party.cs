namespace XtremeModels
{
    public class Party
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Mkey { get; set; }
        public string Code { get; set; }
        public double Op_com { get; set; }
        public double Op_win1 { get; set; }
        public double Op_win2 { get; set; }
        public double Ak_com { get; set; }
        public double Ak_win1 { get; set; }
        public double Ak_win2 { get; set; }
        public double Xak_com { get; set; }
        public double Xak_win1 { get; set; }
        public double Xak_win2 { get; set; }
        public double Td_com { get; set; }
        public double Td_win1 { get; set; }
        public double Td_win2 { get; set; }
        public double Xtd_com { get; set; }
        public double Xtd_win1 { get; set; }
        public double Xtd_win2 { get; set; }
        public double Fc_com { get; set; }
        public double Fc_win1 { get; set; }
        public double Fc_win2 { get; set; }
        public double Dot_com { get; set; }
        public double Dot_win1 { get; set; }
        public double D6_com { get; set; }
        public double D6_win1 { get; set; }
        public double Dop_com { get; set; }
        public double Dop_win1 { get; set; }
        public double Dop_win2 { get; set; }
        public double Sfc1 { get; set; }
        public double Sfc2 { get; set; }
        public double Sfc3 { get; set; }
        public double Sfc4 { get; set; }
        public double Sfc_com { get; set; }
        public double Sfc_own { get; set; }
        public double Std1 { get; set; }
        public double Std2 { get; set; }
        public double Std3 { get; set; }
        public double Std_com { get; set; }
        public double Std_own { get; set; }
        public double S_100 { get; set; }
        public double S_200 { get; set; }
        public double S_750 { get; set; }
        public double S_1500 { get; set; }
        public double S_7500 { get; set; }
        public double S_15000 { get; set; }
        public double S_25000 { get; set; }
        public double S_40000 { get; set; }
        public double S_own { get; set; }
        public List<string> Hset { get; set; }

        public Party ShallowCopy()
        {
            return (Party)MemberwiseClone();
        }
    }
}