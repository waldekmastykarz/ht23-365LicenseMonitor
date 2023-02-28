namespace _365LicenseMonitor.Components
{
    partial class Licenses
{
        private bool _loading;

        private IEnumerable<Microsoft.Graph.SubscribedSku>? subscribedSkus;
        protected override async Task OnInitializedAsync()
        {
            subscribedSkus = await GraphClient.SubscribedSkus
           .Request()
           .GetAsync();
        }
    }
}
