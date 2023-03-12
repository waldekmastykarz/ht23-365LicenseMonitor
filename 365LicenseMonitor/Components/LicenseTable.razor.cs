namespace _365LicenseMonitor.Components
{
    partial class LicenseTable
{
        private bool _loading;
        private string searchString1 = "";

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

        private bool FilterFunc1(License element) => FilterFunc(element, searchString1);
        private bool FilterFunc(License element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

    }
}
