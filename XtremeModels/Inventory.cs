namespace XtremeModels
{
    public class Inventory
    {
        public bool lk { get; set; }
        public bool lk2 { get; set; }
        public double op_win1 { get; set; }
        public double op_win2 { get; set; }
        public double ak_win1 { get; set; }
        public double ak_win2 { get; set; }
        public double xak_win1 { get; set; }
        public double xak_win2 { get; set; }
        public double td_win1 { get; set; }
        public double td_win2 { get; set; }
        public double xtd_win1 { get; set; }
        public double xtd_win2 { get; set; }
        public double fc_win1 { get; set; }
        public double fc_win2 { get; set; }
        public double dot_win1 { get; set; }
        public double d6_win1 { get; set; }
        public string vid { get; set; }

        public int dmode { get; set; }

        public double op_com { get; set; }
        public double ak_com { get; set; }
        public double xak_com { get; set; }
        public double td_com { get; set; }
        public double xtd_com { get; set; }
        public double fc_com { get; set; }
        public double dot_com { get; set; }
        public double d6_com { get; set; }
        public int Vno { get; set; } = -1;
        public int propKey { get; set; } = -1;
        public int xres { get; set; } = -1;
        public string Ref { get; set; } = "";
        public int Win1 { get; set; }
        public int Win2 { get; set; }
        public int Win3 { get; set; }
        public double Win_Rate1 { get; set; }
        public double Win_Rate2 { get; set; }
        public double Win_Rate3 { get; set; }
        public double Win_Rate4 { get; set; }
    }
}