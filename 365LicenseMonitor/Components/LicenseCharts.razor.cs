using Microsoft.AspNetCore.Components;
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
            // Load the category list from local storage
            var result1 = await localStorage.GetItemAsync<List<LicenseCategory>>("CategoryList");
            License.CategoryList = result1 != null ? result1 : License.CategoryList;
        }

        // selectedbuttons is used to show which buttons are visible or not
        private IEnumerable<string> selectedCategories { get; set; } = new HashSet<string>() { };

        public void PopulateOptions() // populate the selection with the currently visible categories when the drop down is opened
        {
            selectedCategories = new HashSet<string>() { }; // reset it here so that when the cancel button is pressed, a new list is created and then we can add visible to it. 
            List<string> selectedCategoryList = selectedCategories.ToList(); // can't add to IEnumerable, so create a list from it
            foreach (var category in License.CategoryList)
            {
                if (category.Visible == true)
                {
                    selectedCategoryList.Add(category.CategoryName);
                }
            }
            selectedCategories = selectedCategoryList; // now put the values back into the IEnumerable
        }

        // Save the users app list to local storage when OK button clicked

        [Parameter] public Func<string, bool> FilterFunc { get; set; } = x => x is not null;
        [Parameter] public string Value { get; set; }

        void ChangeFunc(string item)
        {
            Value = item;
            // this will filter out anthing equal to the current Value
            FilterFunc = x => x != Value;
            // Re-render if needed
            InvokeAsync(StateHasChanged);
        }

            public async Task SaveCategoryList()
        {
            // first set them all to false
            foreach (var category in License.CategoryList)
            {
                category.Visible = false;
            }
            foreach (var text in selectedCategories) // loop through the selected buttons
            {
                // this will cause an issue where two buttons have the same name
                var obj = License.CategoryList.FirstOrDefault(x => x.CategoryName == text);
                if (obj != null) obj.Visible = true; // set the matching one to visible
            }
            await localStorage.SetItemAsync("CategoryList", License.CategoryList); // Save the selection
        }
    }
}

