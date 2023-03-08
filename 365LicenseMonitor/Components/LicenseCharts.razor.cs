using MudBlazor;

namespace _365LicenseMonitor.Components
{
    partial class LicenseCharts
{
        private bool _loading;

        private IEnumerable<Microsoft.Graph.SubscribedSku>? subscribedSkus;
        ChartOptions chartPallette = new() { ChartPalette = new[] { "#f21c0d", "#00a344", "#0000ff" } }; // Colours of the donut chart graphics

        // Create a list of categories
        List<LicenseCategory> CategoryList = new List<LicenseCategory> { 
        new LicenseCategory("Microsoft 365", true, "#E91E63", "#FCE4EC"),
        new LicenseCategory("Office 365", true, "#F44336", "#FFEBEE"),
        new LicenseCategory("Business apps", false, "#9C27B0", "#F3E5F5"),
        new LicenseCategory("Communication", false, "#673AB7", "#EDE7F6"),
        new LicenseCategory("Dynamics 365", false, "#3F51B5", "#E8EAF6"),
        new LicenseCategory("Security and identity", false, "#FFC107", "#FFF8E1"),
        new LicenseCategory("Power BI", false, "#03A9F4", "#E1F5FE"),
        new LicenseCategory("Windows", false, "#00BCD4", "#E0F7FA"),
        new LicenseCategory("Windows 365", false, "#009688", "#E0F2F1"),
        new LicenseCategory("Other services", false, "#FF5722", "#FBE9E7"),
        new LicenseCategory("Add-ons", false, "#607D8B", "#ECEFF1"),
        new LicenseCategory("Power Platform", false, "#4CAF50", "#E8F5E9"),
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

