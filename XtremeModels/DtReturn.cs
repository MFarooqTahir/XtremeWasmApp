using System.Collections.Generic;

namespace XtremeModels
{
    public class DtReturn
    {
        public IList<string> Columns { get; set; }
        public IList<object[]> Row { get; set; }
    }
}