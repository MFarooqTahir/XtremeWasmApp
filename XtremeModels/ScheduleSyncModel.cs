using System.Collections.Generic;

namespace XtremeModels
{
    public class ScheduleSyncModel
    {
        public List<DataSchedule> UpdateList { get; set; }
        public List<DataSchedule> InsertList { get; set; }
        public List<DataSchedule> DeleteList { get; set; }
    }
}