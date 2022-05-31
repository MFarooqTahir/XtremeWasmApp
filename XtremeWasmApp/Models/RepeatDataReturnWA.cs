namespace XtremeWasmApp.Models
{
    public class RepeatDataReturnWA
    {
        public bool Uac { get; set; }
        public bool DrawBlocked { get; set; }
        public bool DrawCompleted { get; set; }
        public bool RelationBlocked { get; set; }

        // User can add, edit etc
        public bool RelationActive { get; set; }

        public bool RelationPrint { get; set; }
        public bool RelationBill { get; set; }
        public bool RelationLedger { get; set; }
        public bool RelationPrize { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RepeatDataReturnWA wA &&
                   Uac == wA.Uac &&
                   DrawBlocked == wA.DrawBlocked &&
                   DrawCompleted == wA.DrawCompleted &&
                   RelationBlocked == wA.RelationBlocked &&
                   RelationActive == wA.RelationActive &&
                   RelationPrint == wA.RelationPrint &&
                   RelationBill == wA.RelationBill &&
                   RelationLedger == wA.RelationLedger &&
                   RelationPrize == wA.RelationPrize;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Uac);
            hash.Add(DrawBlocked);
            hash.Add(DrawCompleted);
            hash.Add(RelationBlocked);
            hash.Add(RelationActive);
            hash.Add(RelationPrint);
            hash.Add(RelationBill);
            hash.Add(RelationLedger);
            hash.Add(RelationPrize);
            return hash.ToHashCode();
        }

        public static bool operator ==(RepeatDataReturnWA? left, RepeatDataReturnWA? right)
        {
            return EqualityComparer<RepeatDataReturnWA>.Default.Equals(left, right);
        }

        public static bool operator !=(RepeatDataReturnWA? left, RepeatDataReturnWA? right)
        {
            return !(left == right);
        }
    }
}