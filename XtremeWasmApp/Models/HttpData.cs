namespace XtremeWasmApp.Models
{
    public class HttpData
    {
        public Uri BaseAddress { get; set; }
        public Uri DataLink { get; set; }
        public Uri InvoiceLink { get; set; }
    }

    public enum RequestType
    {
        Get,
        Post,
        Put,
        Delete,
    }

    public enum LinkType
    {
        Login,
        Data,
        Invoice,
    }
}