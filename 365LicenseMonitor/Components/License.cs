namespace _365LicenseMonitor.Components
{
    public class License
{
        private string Description { get; set; }
        private string SkuId { get; set; }
        private int SkuPartNumber { get; set; }
        private int ConsumedUnits { get; set; }
        private int PrepaidUnits { get; set; }
        private int UnusedUnits { get; set; }

        private string ProductName { get; set; }

        public License(string Description, string SkuId, int SkuPartNumber, int ConsumedUnits, int PrepaidUnits, int unusedUnits, string productName)
        {
            this.Description = Description;
            this.SkuId = SkuId;
            this.SkuPartNumber = SkuPartNumber;
            this.ConsumedUnits = ConsumedUnits;
            this.PrepaidUnits = PrepaidUnits;
            this.UnusedUnits = unusedUnits;
            this.ProductName = productName;
        }

    }
}
