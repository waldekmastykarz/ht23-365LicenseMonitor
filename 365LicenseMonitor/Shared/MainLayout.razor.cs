using MudBlazor;

namespace _365LicenseMonitor.Shared
{
    partial class MainLayout
{
        MudTheme MyCustomTheme = new MudTheme() // override default colors
        {
            Palette = new Palette()
            {
                Error = Colors.Yellow.Darken2,
                Warning = Colors.Green.Darken2,
                Dark = Colors.BlueGrey.Default,
            },
            
            PaletteDark = new PaletteDark()
            {
                Error = Colors.Yellow.Darken2,
                Warning = Colors.Green.Darken2,
                Dark = Colors.BlueGrey.Default,
            },
        };

        bool _drawerOpen = true;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        // Dark mode
        private MudTheme _theme = new();
        private bool _isDarkMode;
        string headerStyle = "drawer-image-dark";

        // Method to allow saving of dark mode to local storage
        private async Task EnableDarkMode()
        {
            if (_isDarkMode)
            {
                _isDarkMode = false;
                await localStorage.SetItemAsync("darkmode", false);
                headerStyle = "drawer-image-dark";
            }
            else
            {
                _isDarkMode = true;
                await localStorage.SetItemAsync("darkmode", true);
                headerStyle = "drawer-image-light";
            }
        }

        // Settings message box
        MudMessageBox? settingsmbox { get; set; }
        string settingsmboxstate = "Message box hasn't been opened yet";
        private async void SettingsButtonClicked()
        {
            bool? result = await settingsmbox.Show();
            settingsmboxstate= result==null ? "Cancelled" : "Deleted!";
            StateHasChanged();
        }
        MudForm? settingsForm;

        // Reset the form to defaults (not used)
        private async Task ResetForm()
        {
            settingsForm.Reset(); // this is the built in one which resets all controls
        }

        protected override async Task OnInitializedAsync()
        {
            // Load dark mode setting from localStorage
            var result1 = await localStorage.GetItemAsync<bool>("darkmode");
            _isDarkMode = result1 ? result1 : false;
        }

        // Reset local storage
        private async Task ResetAllSettings()
        {
            await localStorage.ClearAsync(); // Reset localStorage
        }

    }
}
