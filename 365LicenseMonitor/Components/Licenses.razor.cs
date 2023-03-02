namespace _365LicenseMonitor.Components
{
    partial class Licenses
{
        private bool _loading;

        private IEnumerable<Microsoft.Graph.SubscribedSku>? subscribedSkus;

        // Create a list
        List<License> LicenseList = new List<License> { };
        protected override async Task OnInitializedAsync()
        {
            subscribedSkus = await GraphClient.SubscribedSkus
           .Request()
           .GetAsync();

            foreach (var sku in subscribedSkus)
            {
                // Create the license object and add to the list
                 var lic = new License(sku.SkuId.ToString(), sku.SkuPartNumber, sku.ConsumedUnits, sku.PrepaidUnits.Enabled);
                LicenseList.Add(lic);
            }
        }
    }
}
