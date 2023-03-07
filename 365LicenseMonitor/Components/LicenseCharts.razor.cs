using MudBlazor;

namespace _365LicenseMonitor.Components
{
    partial class LicenseCharts
{
        private bool _loading;

        private IEnumerable<Microsoft.Graph.SubscribedSku>? subscribedSkus;
        ChartOptions chartPallette = new() { ChartPalette = new[] { "#f21c0d", "#00a344", "#0000ff" } };

        // Create a list of categories
        List<LicenseCategory> CategoryList = new List<LicenseCategory> { 
        new LicenseCategory("Microsoft 365", true),
        new LicenseCategory("Office 365", true),
        new LicenseCategory("Business apps", false),
        new LicenseCategory("Collaboration and communication", false),
        new LicenseCategory("Dynamics 365", false),
        new LicenseCategory("Security and identity", false),
        new LicenseCategory("Power BI", false),
        new LicenseCategory("Windows", false),
        new LicenseCategory("Windows 365", false),
        new LicenseCategory("Other services", false),
        new LicenseCategory("Add-ons", false),
        new LicenseCategory("Power Platform", false),
        };


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

