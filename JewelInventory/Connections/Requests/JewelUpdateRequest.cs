namespace Connections
{
    public class JewelUpdateRequest
    {
        public JewelUpdateRequest(string jewelNumber)
        {
            JewelNumber = jewelNumber;
        }

        public string JewelNumber { get; set; }
        public string CertificateNumber { get; set; }
        public string DesignCode { get; set; }
        public bool IsCancelled { get; set; }
        public string MetalColor { get; set; }
    }
}
