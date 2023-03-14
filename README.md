# 365 License Monitor

[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)
[![Twitter URL](https://img.shields.io/twitter/url?style=for-the-badge&url=https%3A%2F%2Ftwitter.com%2Fhsclater)](https://twitter.com/hsclater)
![GitHub last commit](https://img.shields.io/github/last-commit/cloudhal/365licensemonitor?style=for-the-badge)


Created for [Microsoft Hack Together](https://github.com/microsoft/hack-together)

## Published app location

[https://365licensemonitor.app.cloudrun.io/](https://365licensemonitor.app.cloudrun.io/)



# 365 License Monitor

Welcome to my hack! This project was created for the Microsoft Graph Hack Together at Microsoft Hack Together.



## Description

365 License Monitor allows you to more easily identify the status of your Microsoft 365 licenses. This can help organisations to:

- Easily see which licenses have run out, or have spare. This can help larger organisations either maintain an adequate pool of spare licenses for new joiners, or smaller organisations save money by avoiding waste.
- Quickly identify the status of licenses which are important, filtering out those that aren't.
- Group and filter licenses by category, or search for licenses by name.
## Features

- Light/dark mode toggle
- Live previews
- Fullscreen mode
- Cross platform


## Tech Stack

The app has been created using:

- Blazor WebAssembly
- .NET 7.0
- Graph SDK
- Azure Static Web Apps

## Screenshots

![App Screenshot](https://cloudrun.co.uk/wp-content/uploads/2023/03/license_monitor.png)

## Installation

No install required, it's a web app!

Either build the app from this repo, or you can just run the published app from https://365licensemonitor.app.cloudrun.io/. No installation is required, however you can install it as a web app, by clicking the install icon in the address bar.

If you have access to multiple tenants, it is suggested that you create a browser profile for each 365 tenant that you have access to, in order to avoid issues with being signed into the wrong account. Then install the app under each profile - it will only show in your list of apps once, but you can switch between tenants in the app.

    
## Testing in a demo tenant

If you are using a Sandbox tenant, there is only one included license (Microsoft 365 E5 Developer) so it won't be very interesting, so if testing in a Sandbox you can add some trial licenses:

- Go to https://admin.microsoft.com/#/catalog
- Click Billing > Purchase Services
- Search for 'trial'
- Click the first one - 'Microsoft Cloud for Sustainability vTrial' and start the trial.
- It will say the billing info is needed, click Edit under the address and add a made up street and city.
Repeat and add a license from each category.


## Permissions

Once installed in your tenant, you can limit who can use the app in your tenant, by clicking:

- Azure AD > Enterprise Applications > 365 License Monitor > Properties
- Enable assignment required.
- Add users to the Users and Groups.
- Also if you didn't consent for the organisation when you first ran it, you can do so on the Permissions page, 'Grant admin consent'.
## Authors

- [@cloudhal](https://www.github.com/cloudhal)


## Contributing

Contributions are always welcome! Here are some ways you can contribute:

- Report bugs: If you encounter any bugs, please let us know. Open up an issue and let us know the problem.
- Contribute code: If you are a developer and want to contribute, follow the instructions below to get started!
- Suggestions: If you don't want to code but have some awesome ideas, open up an issue explaining some updates or imporvements you would like to see!
- Documentation: If you see the need for some additional documentation, feel free to add some!

Instructions

- Fork this repository
- Clone the forked repository
- Add your contributions (code or documentation)
- Commit and push
- Wait for pull request to be merged

    
## Support

For support, raise an issue here, or [@hsclater](https://twitter.com/hsclater)

[![Azure Static Web Apps CI/CD](https://github.com/cloudhal/365LicenseMonitor/actions/workflows/azure-static-web-apps-orange-meadow-0c3e81803.yml/badge.svg)](https://github.com/cloudhal/365LicenseMonitor/actions/workflows/azure-static-web-apps-orange-meadow-0c3e81803.yml)
