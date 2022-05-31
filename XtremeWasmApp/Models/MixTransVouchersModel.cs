using XtremeModels;

namespace XtremeWasmApp.Models
{
    public class MixTransVouchersModel
    {
        public IList<Transaction> Transactions { get; set; }
        public double InvoiceTotal { get; set; }
        public int TotalRows { get; set; }
    }
}