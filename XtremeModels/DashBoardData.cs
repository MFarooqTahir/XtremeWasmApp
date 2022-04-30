using System.Collections.Generic;

namespace XtremeModels
{
    public class DashBoardData
    {
        public Party party { get; set; }
        public PartySch partySch { get; set; }
        public IList<Schedule> sch { get; set; }
    }
}