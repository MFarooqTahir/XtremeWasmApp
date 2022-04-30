namespace XtremeModels
{
    public class ResultSet<TResultType>
    {
        public string Status { get; set; } = "Not Authenticated";
        public TResultType ResultObj { get; set; }

        public ResultSet()
        {
        }

        public ResultSet(TResultType resultObj, string status = "Success")
        {
            ResultObj = resultObj;
            Status = status;
        }
    }
}