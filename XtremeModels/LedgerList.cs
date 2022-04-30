using System.Collections.Generic;

namespace XtremeModels
{
    public class LedgerList
    {
        public double BF { get; set; }

        public List<Ledger> LedgerL { get; set; } = new List<Ledger>();
    }
}