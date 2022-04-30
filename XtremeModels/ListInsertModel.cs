using System.Collections.Generic;

namespace XtremeModels
{
    public class ListInsertModel
    {
        public int Bond { get; set; }
        public List<int> Amount { get; set; }
        public List<List<string>> Values { get; set; }
    }
}