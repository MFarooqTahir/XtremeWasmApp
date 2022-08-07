using System.Data;

namespace XtremeModels
{
    public class DtReturn
    {
        public IList<string> Columns { get; set; }
        public IList<object[]> Row { get; set; }

        public DataTable ToTable()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(Columns.Select(x => new DataColumn(x)).ToArray());
            foreach (var SingleRow in Row)
            {
                dt.Rows.Add(SingleRow);
            }
            return dt;
        }
        public DtReturnString ToStringArrayRows()
        {
            return new DtReturnString()
            { Columns = Columns, Row = Row?.Select(x => x?.Select(y => y?.ToString())?.ToList())?.ToList() };

        }
    }
    public class DtReturnString
    {

        public IList<string> Columns { get; set; }
        public List<List<string?>?>? Row { get; set; }

        public DataTable ToTable()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(Columns.Select(x => new DataColumn(x)).ToArray());
            foreach (var SingleRow in Row)
            {
                dt.Rows.Add(SingleRow);
            }
            return dt;
        }
    }
}