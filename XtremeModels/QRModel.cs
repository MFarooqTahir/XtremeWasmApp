namespace XtremeModels
{
    public class QRModel
    {
        public string SharedKey { get; set; }

        public string AuthenticatorUri { get; set; }

        public string[] RecoveryCodes { get; set; }

        public string StatusMessage { get; set; }
        public string Code { get; set; }
    }
}