using MudBlazor;

namespace _365LicenseMonitor.Components
{
    partial class LicenseCharts
{
        private bool _loading;

        private IEnumerable<Microsoft.Graph.SubscribedSku>? subscribedSkus;
        ChartOptions chartPallette = new() { ChartPalette = new[] { "#f21c0d", "#00a344", "#0000ff" } }; // Colours of the donut chart graphics


        // Create a list of licenses
        List<License> LicenseList = new List<License> { };
        protected override async Task OnInitializedAsync()
        {

            // Make the Graph request
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

