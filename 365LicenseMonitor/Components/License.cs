using System.Collections;

namespace _365LicenseMonitor.Components
{

    // licenseCategory class used to for showing or hiding licenses in a category
    public class LicenseCategory
    {
        public string CategoryName { get; set; }
        public bool Visible { get; set; }
        public string Colour { get; set; }
        public string Background { get; set; }

        public LicenseCategory(string CategoryName, bool Visible, string Colour, string Background)
        {
            this.CategoryName = CategoryName;
            this.Visible = Visible;
            this.Colour = Colour;
            this.Background=Background;
        }
    }

    // LicenseProperty class is used as the value in LicenseDictionary, to look up both ProductName and Category together, which avoids having 2 dictionaries
    public class LicenseProperty
    {
        public string ProductName { get; set; }
        public string Category { get; set; }

        public LicenseProperty(string ProductName, string Category)
        {
            this.ProductName = ProductName;
            this.Category = Category;
        }
    }

    public class License
    {
        public string SkuId { get; }
        public string SkuPartNumber { get; }
        public int? ConsumedUnits { get; }
        public int? PrepaidUnits { get; }
        public int? UnusedUnits { get; }
        public string? ProductName { get; set; } // Friendly name
        public string? Category { get; set; } // Visible can be set on or of

        // Constructor, ProductName and Category are set using the dictionary
        public License(string SkuId, string SkuPartNumber, int? ConsumedUnits, int? PrepaidUnits)
        {
            this.SkuId = SkuId;
            this.SkuPartNumber = SkuPartNumber;
            this.ConsumedUnits = ConsumedUnits;
            this.PrepaidUnits = PrepaidUnits;
            UnusedUnits = PrepaidUnits - ConsumedUnits;
            try // try catch both dictionary lookups, otherwise there will be unhandled exception error if the SKUID is not in the dictionary
            {
                ProductName = (string?)LicenseDictionary[SkuId].ProductName;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Could not find Product Name for key {SkuId}");
            }
            try
            {
                Category = (string?)LicenseDictionary[SkuId].Category;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Could not find Product Name for key {SkuId}");
            }
        }

        // Method to print out the license details

        public override string ToString()
        {
            return "SkuId: " + SkuId +
                " | " + "SkuPartNumber: " + SkuPartNumber +
                " | " + "ConsumedUnits: " + ConsumedUnits +
                " | " + "PrepaidUnits: " + PrepaidUnits +
                " | " + "PrepaidUnits: " + PrepaidUnits +
                " | " + "UnusedUnits: " + UnusedUnits +
                " | " + "ProductName: " + ProductName +
                " | " + "Category: " + Category;
        }

        // Create a dictionary which maps SkuIds to Product Names as per https://learn.microsoft.com/en-us/azure/active-directory/enterprise-users/licensing-service-plan-reference

        Dictionary<string, LicenseProperty> LicenseDictionary = new Dictionary<string, LicenseProperty>()
        {
            ["e4654015-5daf-4a48-9b37-4f309dddd88b"] = new LicenseProperty("Advanced Communications", "Add-ons"),
            ["d2dea78b-507c-4e56-b400-39447f4738f8"] = new LicenseProperty("AI Builder Capacity add-on", "Business apps"),
            ["8f0c5670-4e56-4892-b06d-91c085d7004f"] = new LicenseProperty("App Connect IW", "Add-ons"),
            ["2b9c8e7c-319c-43a2-a2a0-48c5c6161de7"] = new LicenseProperty("Azure Active Directory Basic", "Security and identity"),
            ["078d2b04-f1bd-4111-bbd4-b4b1b354cef4"] = new LicenseProperty("Azure Active Directory Premium P1", "Security and identity"),
            ["30fc3c36-5a95-4956-ba57-c09c2a600bb9"] = new LicenseProperty("Azure Active Directory Premium P1 for faculty", "Security and identity"),
            ["84a661c4-e949-4bd2-a560-ed7766fcaf2b"] = new LicenseProperty("Azure Active Directory Premium P2", "Security and identity"),
            ["c52ea49f-fe5d-4e95-93ba-1de91d380f89"] = new LicenseProperty("Azure Information Protection Plan 1", "Security and identity"),
            ["78362de1-6942-4bb8-83a1-a32aa67e6e2c"] = new LicenseProperty("Azure Information Protection Premium P1 for Government", "Security and identity"),
            ["90d8b3f8-712e-4f7b-aa1e-62e7ae6cbe96"] = new LicenseProperty("Business Apps (free)", "Add-ons"),
            ["e612d426-6bc3-4181-9658-91aa906b0ac0"] = new LicenseProperty("Common Data Service Database Capacity", "Dynamics 365"),
            ["eddf428b-da0e-4115-accf-b29eb0b83965"] = new LicenseProperty("Common Data Service Database Capacity for Government", "Dynamics 365"),
            ["448b063f-9cc6-42fc-a0e6-40e08724a395"] = new LicenseProperty("Common Data Service Log Capacity", "Dynamics 365"),
            ["47794cd0-f0e5-45c5-9033-2eb6b5fc84e0"] = new LicenseProperty("Communications Credits", "Add-ons"),
            ["a9d7ef53-9bea-4a2a-9650-fa7df58fe094"] = new LicenseProperty("Compliance Manager Premium Assessment Add-On for GCC", "Microsoft 365"),
            ["328dc228-00bc-48c6-8b09-1fbc8bc3435d"] = new LicenseProperty("Dynamics 365 - Additional Database Storage (Qualified Offer)", "Dynamics 365"),
            ["e06abcc2-7ec5-4a79-b08b-d9c282376f72"] = new LicenseProperty("Dynamics 365 - Additional Non-Production Instance (Qualified Offer)", "Dynamics 365"),
            ["9d776713-14cb-4697-a21d-9a52455c738a"] = new LicenseProperty("Dynamics 365 - Additional Production Instance (Qualified Offer)", "Dynamics 365"),
            ["c6df1e30-1c9f-427f-907c-3d913474a1c7"] = new LicenseProperty("Dynamics 365 AI for Market Insights (Preview)", "Dynamics 365"),
            ["673afb9d-d85b-40c2-914e-7bf46cd5cd75"] = new LicenseProperty("Dynamics 365 Asset Management Addl Assets", "Dynamics 365"),
            ["a58f5506-b382-44d4-bfab-225b2fbf8390"] = new LicenseProperty("Dynamics 365 Business Central Additional Environment Addon", "Dynamics 365"),
            ["7d0d4f9a-2686-4cb8-814c-eff3fdab6d74"] = new LicenseProperty("Dynamics 365 Business Central Database Capacity", "Dynamics 365"),
            ["2880026b-2b0c-4251-8656-5d41ff11e3aa"] = new LicenseProperty("Dynamics 365 Business Central Essentials", "Dynamics 365"),
            ["9a1e33ed-9697-43f3-b84c-1b0959dbb1d4"] = new LicenseProperty("Dynamics 365 Business Central External Accountant", "Dynamics 365"),
            ["6a4a1628-9b9a-424d-bed5-4118f0ede3fd"] = new LicenseProperty("Dynamics 365 Business Central for IWs", "Dynamics 365"),
            ["f991cecc-3f91-4cd0-a9a8-bf1c8167e029"] = new LicenseProperty("Dynamics 365 Business Central Premium", "Dynamics 365"),
            ["2e3c4023-80f6-4711-aa5d-29e0ecb46835"] = new LicenseProperty("Dynamics 365 Business Central Team Members", "Dynamics 365"),
            ["ea126fc5-a19e-42e2-a731-da9d437bffcf"] = new LicenseProperty("Dynamics 365 Customer Engagement Plan", "Dynamics 365"),
            ["036c2481-aa8a-47cd-ab43-324f0c157c2d"] = new LicenseProperty("Dynamics 365 Customer Insights vTrial", "Dynamics 365"),
            ["1e615a51-59db-4807-9957-aa83c3657351"] = new LicenseProperty("Dynamics 365 Customer Service Enterprise Viral Trial", "Dynamics 365"),
            ["61e6bd70-fbdb-4deb-82ea-912842f39431"] = new LicenseProperty("Dynamics 365 Customer Service Insights Trial", "Dynamics 365"),
            ["1439b6e2-5d59-4873-8c59-d60e2a196e92"] = new LicenseProperty("Dynamics 365 Customer Service Professional", "Dynamics 365"),
            ["359ea3e6-8130-4a57-9f8f-ad897a0342f1"] = new LicenseProperty("Dynamics 365 Customer Voice", "Dynamics 365"),
            ["446a86f8-a0cb-4095-83b3-d100eb050e3d"] = new LicenseProperty("Dynamics 365 Customer Voice Additional Responses", "Dynamics 365"),
            ["65f71586-ade3-4ce1-afc0-1b452eaf3782"] = new LicenseProperty("Dynamics 365 Customer Voice Additional Responses", "Dynamics 365"),
            ["bc946dac-7877-4271-b2f7-99d2db13cd2c"] = new LicenseProperty("Dynamics 365 Customer Voice Trial", "Dynamics 365"),
            ["e2ae107b-a571-426f-9367-6d4c8f1390ba"] = new LicenseProperty("Dynamics 365 Customer Voice USL", "Dynamics 365"),
            ["a4bfb28e-becc-41b0-a454-ac680dc258d3"] = new LicenseProperty("Dynamics 365 Enterprise Edition - Additional Portal (Qualified Offer)", "Dynamics 365"),
            ["29fcd665-d8d1-4f34-8eed-3811e3fca7b3"] = new LicenseProperty("Dynamics 365 Field Service Viral Trial", "Dynamics 365"),
            ["55c9eb4e-c746-45b4-b255-9ab6b19d5c62"] = new LicenseProperty("Dynamics 365 Finance", "Dynamics 365"),
            ["d39fb075-21ae-42d0-af80-22a2599749e0"] = new LicenseProperty("Dynamics 365 for Case Management Enterprise Edition", "Dynamics 365"),
            ["749742bf-0d37-4158-a120-33567104deeb"] = new LicenseProperty("Dynamics 365 for Customer Service Enterprise Edition", "Dynamics 365"),
            ["a36cdaa2-a806-4b6e-9ae0-28dbd993c20e"] = new LicenseProperty("Dynamics 365 for Field Service Attach to Qualifying Dynamics 365 Base Offer", "Dynamics 365"),
            ["c7d15985-e746-4f01-b113-20b575898250"] = new LicenseProperty("Dynamics 365 for Field Service Enterprise Edition", "Dynamics 365"),
            ["cc13a803-544e-4464-b4e4-6d6169a138fa"] = new LicenseProperty("Dynamics 365 for Financials Business Edition", "Dynamics 365"),
            ["238e2f8d-e429-4035-94db-6926be4ffe7b"] = new LicenseProperty("Dynamics 365 for Marketing Business Edition", "Dynamics 365"),
            ["4b32a493-9a67-4649-8eb9-9fc5a5f75c12"] = new LicenseProperty("Dynamics 365 for Marketing USL", "Dynamics 365"),
            ["8edc2cf8-6438-4fa9-b6e3-aa1660c640cc"] = new LicenseProperty("Dynamics 365 for Sales and Customer Service Enterprise Edition", "Dynamics 365"),
            ["1e1a282c-9c54-43a2-9310-98ef728faace"] = new LicenseProperty("Dynamics 365 for Sales Enterprise Edition", "Dynamics 365"),
            ["be9f9771-1c64-4618-9907-244325141096"] = new LicenseProperty("Dynamics 365 for Sales Professional", "Dynamics 365"),
            ["245e6bf9-411e-481e-8611-5c08595e2988"] = new LicenseProperty("Dynamics 365 for Sales Professional Attach to Qualifying Dynamics 365 Base Offer", "Dynamics 365"),
            ["9c7bff7a-3715-4da7-88d3-07f57f8d0fb6"] = new LicenseProperty("Dynamics 365 for Sales Professional Trial", "Dynamics 365"),
            ["f2e48cb3-9da0-42cd-8464-4a54ce198ad0"] = new LicenseProperty("Dynamics 365 for Supply Chain Management", "Dynamics 365"),
            ["3a256e9a-15b6-4092-b0dc-82993f4debc6"] = new LicenseProperty("Dynamics 365 for Talent", "Dynamics 365"),
            ["8e7a3d30-d97d-43ab-837c-d7701cef83dc"] = new LicenseProperty("DYNAMICS 365 for Team Members Enterprise Edition", "Dynamics 365"),
            ["0a389a77-9850-4dc4-b600-bc66fdfefc60"] = new LicenseProperty("Dynamics 365 Guides", "Dynamics 365"),
            ["3bbd44ed-8a70-4c07-9088-6232ddbd5ddd"] = new LicenseProperty("Dynamics 365 Operations - Device", "Dynamics 365"),
            ["e485d696-4c87-4aac-bf4a-91b2fb6f0fa7"] = new LicenseProperty("Dynamics 365 Operations - Sandbox Tier 2:Standard Acceptance Testing", "Dynamics 365"),
            ["f7ad4bca-7221-452c-bdb6-3e6089f25e06"] = new LicenseProperty("Dynamics 365 Operations - Sandbox Tier 4:Standard Performance Testing", "Dynamics 365"),
            ["338148b6-1b11-4102-afb9-f92b6cdc0f8d"] = new LicenseProperty("Dynamics 365 P1 Trial for Information Workers", "Dynamics 365"),
            ["7ed4877c-0863-4f69-9187-245487128d4f"] = new LicenseProperty("Dynamics 365 Regulatory Service - Enterprise Edition Trial", "Dynamics 365"),
            ["7a551360-26c4-4f61-84e6-ef715673e083"] = new LicenseProperty("Dynamics 365 Remote Assist", "Dynamics 365"),
            ["e48328a2-8e98-4484-a70f-a99f8ac9ec89"] = new LicenseProperty("Dynamics 365 Remote Assist HoloLens", "Dynamics 365"),
            ["5b22585d-1b71-4c6b-b6ec-160b1a9c2323"] = new LicenseProperty("Dynamics 365 Sales Enterprise Attach to Qualifying Dynamics 365 Base Offer", "Dynamics 365"),
            ["6ec92958-3cc1-49db-95bd-bc6b3798df71"] = new LicenseProperty("Dynamics 365 Sales Premium Viral Trial", "Dynamics 365"),
            ["e561871f-74fa-4f02-abee-5b0ef54dd36d"] = new LicenseProperty("Dynamics 365 Talent: Attract", "Dynamics 365"),
            ["b56e7ccc-d5c7-421f-a23b-5c18bdbad7c0"] = new LicenseProperty("Dynamics 365 Talent: Onboard", "Dynamics 365"),
            ["7ac9fe77-66b7-4e5e-9e46-10eed1cff547"] = new LicenseProperty("Dynamics 365 Team Members", "Dynamics 365"),
            ["ccba3cfe-71ef-423a-bd87-b6df3dce59a9"] = new LicenseProperty("Dynamics 365 UNF OPS Plan ENT Edition", "Dynamics 365"),
            ["aedfac18-56b8-45e3-969b-53edb4ba4952"] = new LicenseProperty("Enterprise Mobility + Security A3 for Faculty", "Security and identity"),
            ["efccb6f7-5641-4e0e-bd10-b4976e1bf68e"] = new LicenseProperty("Enterprise Mobility + Security E3", "Security and identity"),
            ["b05e124f-c7cc-45a0-a6aa-8cf78c946968"] = new LicenseProperty("Enterprise Mobility + Security E5", "Security and identity"),
            ["c793db86-5237-494e-9b11-dcd4877c2c8c"] = new LicenseProperty("Enterprise Mobility + Security G3 GCC", "Security and identity"),
            ["8a180c2b-f4cf-4d44-897c-3d32acc4a60b"] = new LicenseProperty("Enterprise Mobility + Security G5 GCC", "Security and identity"),
            ["e8ecdf70-47a8-4d39-9d15-093624b7f640"] = new LicenseProperty("Exchange Enterprise CAL Services (EOP, DLP)", "Add-ons"),
            ["4b9405b0-7788-4568-add1-99614e613b69"] = new LicenseProperty("Exchange Online (Plan 1)", "Communication"),
            ["aa0f9eb7-eff2-4943-8424-226fb137fcad"] = new LicenseProperty("Exchange Online (Plan 1) for Alumni with Yammer", "Communication"),
            ["f37d5ebf-4bf1-4aa2-8fa3-50c51059e983"] = new LicenseProperty("Exchange Online (Plan 1) for GCC", "Communication"),
            ["ad2fe44a-915d-4e2b-ade1-6766d50a9d9c"] = new LicenseProperty("Exchange Online (Plan 1) for Students", "Communication"),
            ["19ec0d23-8335-4cbd-94ac-6050e30712fa"] = new LicenseProperty("Exchange Online (PLAN 2)", "Communication"),
            ["7be8dc28-4da4-4e6d-b9b9-c60f2806df8a"] = new LicenseProperty("Exchange Online (Plan 2) for GCC", "Communication"),
            ["ee02fd1b-340e-4a4b-b355-4a514e4c8943"] = new LicenseProperty("Exchange Online Archiving for Exchange Online", "Communication"),
            ["90b5e015-709a-4b8b-b08e-3200f994494c"] = new LicenseProperty("Exchange Online Archiving for Exchange Server", "Communication"),
            ["e8f81a67-bd96-4074-b108-cf193eb9433b"] = new LicenseProperty("Exchange Online Essentials", "Communication"),
            ["7fc0182e-d107-4556-8329-7caaa511197b"] = new LicenseProperty("Exchange Online Essentials (ExO P1 Based)", "Communication"),
            ["80b2d799-d2ba-4d2a-8842-fb0d0f3a4b82"] = new LicenseProperty("Exchange Online Kiosk", "Communication"),
            ["cb0a98a8-11bc-494c-83d9-c1b1ac65327e"] = new LicenseProperty("Exchange Online POP", "Add-ons"),
            ["45a2423b-e884-448d-a831-d9e139c52d2f"] = new LicenseProperty("Exchange Online Protection", "Security and identity"),
            ["061f9ace-7d42-4136-88ac-31dc755f143f"] = new LicenseProperty("Intune", "Security and identity"),
            ["d9d89b70-a645-4c24-b041-8d3cb1884ec7"] = new LicenseProperty("Intune for Education", "Security and identity"),
            ["b17653a4-2443-4e8c-a550-18249dda78bb"] = new LicenseProperty("Microsoft 365 A1", "Microsoft 365"),
            ["1aa94593-ca12-4254-a738-81a5972958e8"] = new LicenseProperty("Microsoft 365 A3 - Unattended License for students use benefit", "Microsoft 365"),
            ["4b590615-0888-425a-a965-b3bf7789848d"] = new LicenseProperty("Microsoft 365 A3 for faculty", "Microsoft 365"),
            ["7cfd9a2b-e110-4c39-bf20-c6a3f36a3121"] = new LicenseProperty("Microsoft 365 A3 for students", "Microsoft 365"),
            ["18250162-5d87-4436-a834-d795c15c80f3"] = new LicenseProperty("Microsoft 365 A3 student use benefits", "Microsoft 365"),
            ["e97c048c-37a4-45fb-ab50-922fbf07a370"] = new LicenseProperty("Microsoft 365 A5 for Faculty", "Microsoft 365"),
            ["46c119d4-0379-4a9d-85e4-97c66d3f909e"] = new LicenseProperty("Microsoft 365 A5 for students", "Microsoft 365"),
            ["31d57bc7-3a05-4867-ab53-97a17835a411"] = new LicenseProperty("Microsoft 365 A5 student use benefits", "Microsoft 365"),
            ["81441ae1-0b31-4185-a6c0-32b6b84d419f"] = new LicenseProperty("Microsoft 365 A5 without Audio Conferencing for students use benefit", "Microsoft 365"),
            ["cdd28e44-67e3-425e-be4c-737fab2899d3"] = new LicenseProperty("Microsoft 365 Apps for Business", "Microsoft 365"),
            ["b214fe43-f5a3-4703-beeb-fa97188220fc"] = new LicenseProperty("Microsoft 365 Apps for Business", "Microsoft 365"),
            ["c2273bd0-dff7-4215-9ef5-2c7bcfb06425"] = new LicenseProperty("Microsoft 365 Apps for enterprise", "Microsoft 365"),
            ["ea4c5ec8-50e3-4193-89b9-50da5bd4cdc7"] = new LicenseProperty("Microsoft 365 Apps for enterprise (device)", "Microsoft 365"),
            ["12b8c807-2e20-48fc-b453-542b6ee9d171"] = new LicenseProperty("Microsoft 365 Apps for Faculty", "Microsoft 365"),
            ["c32f9321-a627-406d-a114-1f9c81aaafac"] = new LicenseProperty("Microsoft 365 Apps for Students", "Microsoft 365"),
            ["0c266dff-15dd-4b49-8397-2bb16070ed52"] = new LicenseProperty("Microsoft 365 Audio Conferencing", "Communication"),
            ["2d3091c7-0712-488b-b3d8-6b97bde6a1f5"] = new LicenseProperty("Microsoft 365 Audio Conferencing for GCC", "Communication"),
            ["df9561a4-4969-4e6a-8e73-c601b68ec077"] = new LicenseProperty("Microsoft 365 Audio Conferencing Pay-Per-Minute - EA", "Communication"),
            ["3b555118-da6a-4418-894f-7df1e2096870"] = new LicenseProperty("Microsoft 365 Business Basic", "Microsoft 365"),
            ["dab7782a-93b1-4074-8bb1-0e61318bea0b"] = new LicenseProperty("Microsoft 365 Business Basic", "Microsoft 365"),
            ["cbdc14ab-d96c-4c30-b9f4-6ada7cdc1d46"] = new LicenseProperty("Microsoft 365 Business Premium", "Microsoft 365"),
            ["f245ecc8-75af-4f8e-b61f-27d8114de5f3"] = new LicenseProperty("Microsoft 365 Business Standard", "Microsoft 365"),
            ["ac5cef5d-921b-4f97-9ef3-c99076e5470f"] = new LicenseProperty("Microsoft 365 Business Standard - Prepaid Legacy", "Microsoft 365"),
            ["a6051f20-9cbc-47d2-930d-419183bf6cf1"] = new LicenseProperty("Microsoft 365 Business Voice", "Microsoft 365"),
            ["08d7bce8-6e16-490e-89db-1d508e5e9609"] = new LicenseProperty("Microsoft 365 Business Voice (US)", "Microsoft 365"),
            ["d52db95a-5ecb-46b6-beb0-190ab5cda4a8"] = new LicenseProperty("Microsoft 365 Business Voice (without calling plan)", "Microsoft 365"),
            ["8330dae3-d349-44f7-9cad-1b23c64baabe"] = new LicenseProperty("Microsoft 365 Business Voice (without Calling Plan) for US", "Microsoft 365"),
            ["11dee6af-eca8-419f-8061-6864517c1875"] = new LicenseProperty("Microsoft 365 Domestic Calling Plan (120 Minutes)", "Microsoft 365"),
            ["923f58ab-fca1-46a1-92f9-89fda21238a8"] = new LicenseProperty("Microsoft 365 Domestic Calling Plan for GCC", "Microsoft 365"),
            ["05e9a617-0261-4cee-bb44-138d3ef5d965"] = new LicenseProperty("Microsoft 365 E3", "Microsoft 365"),
            ["c2ac2ee4-9bb1-47e4-8541-d689c7e83371"] = new LicenseProperty("Microsoft 365 E3 - Unattended License", "Microsoft 365"),
            ["0c21030a-7e60-4ec7-9a0f-0042e0e0211a"] = new LicenseProperty("Microsoft 365 E3 (500 seats min) HUB", "Microsoft 365"),
            ["d61d61cc-f992-433f-a577-5bd016037eeb"] = new LicenseProperty("Microsoft 365 E3_USGOV_DOD", "Microsoft 365"),
            ["ca9d1dd9-dfe9-4fef-b97c-9bc1ea3c3658"] = new LicenseProperty("Microsoft 365 E3_USGOV_GCCHIGH", "Microsoft 365"),
            ["06ebc4ee-1bb5-47dd-8120-11324bc54e06"] = new LicenseProperty("Microsoft 365 E5", "Microsoft 365"),
            ["db684ac5-c0e7-4f92-8284-ef9ebde75d33"] = new LicenseProperty("Microsoft 365 E5 (500 seats min) HUB", "Microsoft 365"),
            ["184efa21-98c3-4e5d-95ab-d07053a96e67"] = new LicenseProperty("Microsoft 365 E5 Compliance", "Microsoft 365"),
            ["c42b9cae-ea4f-4ab7-9717-81576235ccac"] = new LicenseProperty("Microsoft 365 E5 Developer (without Windows and Audio Conferencing)", "Microsoft 365"),
            ["26124093-3d78-432b-b5dc-48bf992543d5"] = new LicenseProperty("Microsoft 365 E5 Security", "Microsoft 365"),
            ["44ac31e7-2999-4304-ad94-c948886741d4"] = new LicenseProperty("Microsoft 365 E5 Security for EMS E5", "Microsoft 365"),
            ["99cc8282-2f74-4954-83b7-c6a9a1999067"] = new LicenseProperty("Microsoft 365 E5 Suite Features", "Microsoft 365"),
            ["a91fc4e0-65e5-4266-aa76-4037509c1626"] = new LicenseProperty("Microsoft 365 E5 with Calling Minutes", "Microsoft 365"),
            ["cd2925a3-5076-4233-8931-638a8c94f773"] = new LicenseProperty("Microsoft 365 E5 without Audio Conferencing", "Microsoft 365"),
            ["2113661c-6509-4034-98bb-9c47bd28d63c"] = new LicenseProperty("Microsoft 365 E5 without Audio Conferencing (500 seats min) HUB", "Microsoft 365"),
            ["44575883-256e-4a79-9da4-ebe9acabe2b2"] = new LicenseProperty("Microsoft 365 F1", "Microsoft 365"),
            ["50f60901-3181-4b75-8a2c-4c8e4c1d5a72"] = new LicenseProperty("Microsoft 365 F1", "Microsoft 365"),
            ["66b55226-6b4f-492c-910c-a3b7a3c9d993"] = new LicenseProperty("Microsoft 365 F3", "Microsoft 365"),
            ["2a914830-d700-444a-b73c-e3f31980d833"] = new LicenseProperty("Microsoft 365 F3 GCC", "Microsoft 365"),
            ["91de26be-adfa-4a3d-989e-9131cc23dda7"] = new LicenseProperty("Microsoft 365 F5 Compliance Add-on", "Microsoft 365"),
            ["9cfd6bc3-84cd-4274-8a21-8c7c41d6c350"] = new LicenseProperty("Microsoft 365 F5 Compliance Add-on AR DOD_USGOV_DOD", "Microsoft 365"),
            ["9f436c0e-fb32-424b-90be-6a9f2919d506"] = new LicenseProperty("Microsoft 365 F5 Compliance Add-on AR_USGOV_GCCHIGH", "Microsoft 365"),
            ["3f17cf90-67a2-4fdb-8587-37c1539507e1"] = new LicenseProperty("Microsoft 365 F5 Compliance Add-on GCC", "Microsoft 365"),
            ["32b47245-eb31-44fc-b945-a8b1576c439f"] = new LicenseProperty("Microsoft 365 F5 Security + Compliance Add-on", "Microsoft 365"),
            ["67ffe999-d9ca-49e1-9d2c-03fb28aa7a48"] = new LicenseProperty("Microsoft 365 F5 Security Add-on", "Microsoft 365"),
            ["e823ca47-49c4-46b3-b38d-ca11d5abe3d2"] = new LicenseProperty("MICROSOFT 365 G3 GCC", "Microsoft 365"),
            ["e2be619b-b125-455f-8660-fb503e431a5d"] = new LicenseProperty("Microsoft 365 GCC G5", "Microsoft 365"),
            ["2347355b-4e81-41a4-9c22-55057a399791"] = new LicenseProperty("Microsoft 365 Security and Compliance for Firstline Workers", "Microsoft 365"),
            ["cb2020b1-d8f6-41c0-9acd-8ff3d6d7831b"] = new LicenseProperty("Microsoft Azure Multi-Factor Authentication", "Security and identity"),
            ["726a0894-2c77-4d65-99da-9775ef05aad1"] = new LicenseProperty("Microsoft Business Center", "Add-ons"),
            ["df845ce7-05f9-4894-b5f2-11bbfbcfd2b6"] = new LicenseProperty("Microsoft Cloud App Security", "Security and identity"),
            ["111046dd-295b-4d6d-9724-d52ac90bd1f2"] = new LicenseProperty("Microsoft Defender for Endpoint", "Security and identity"),
            ["16a55f2f-ff35-4cd5-9146-fb784e3761a5"] = new LicenseProperty("Microsoft Defender for Endpoint P1", "Security and identity"),
            ["b126b073-72db-4a9d-87a4-b17afe41d4ab"] = new LicenseProperty("Microsoft Defender for Endpoint P2_XPLAT", "Security and identity"),
            ["509e8ab6-0274-4cda-bcbd-bd164fd562c4"] = new LicenseProperty("Microsoft Defender for Endpoint Server", "Security and identity"),
            ["98defdf7-f6c1-44f5-a1f6-943b6764e7a5"] = new LicenseProperty("Microsoft Defender for Identity", "Security and identity"),
            ["4ef96642-f096-40de-a3e9-d83fb2f90211"] = new LicenseProperty("Microsoft Defender for Office 365 (Plan 1)", "Add-ons"),
            ["26ad4b5c-b686-462e-84b9-d7c22b46837f"] = new LicenseProperty("Microsoft Defender for Office 365 (Plan 1) Faculty", "Add-ons"),
            ["d0d1ca43-b81a-4f51-81e5-a5b1ad7bb005"] = new LicenseProperty("Microsoft Defender for Office 365 (Plan 1) GCC", "Add-ons"),
            ["3dd6cf57-d688-4eed-ba52-9e40b5468c3e"] = new LicenseProperty("Microsoft Defender for Office 365 (Plan 2)", "Add-ons"),
            ["56a59ffb-9df1-421b-9e61-8b568583474d"] = new LicenseProperty("Microsoft Defender for Office 365 (Plan 2) GCC", "Add-ons"),
            ["fcecd1f9-a91e-488d-a918-a96cdb6ce2b0"] = new LicenseProperty("Microsoft Dynamics AX7 User Trial", "Dynamics 365"),
            ["d17b27af-3f49-4822-99f9-56a661538792"] = new LicenseProperty("Microsoft Dynamics CRM Online", "Dynamics 365"),
            ["906af65a-2970-46d5-9b58-4e9aa50f0657"] = new LicenseProperty("Microsoft Dynamics CRM Online Basic", "Dynamics 365"),
            ["f30db892-07e9-47e9-837c-80727f46fd3d"] = new LicenseProperty("Microsoft Flow Free", "Add-ons"),
            ["ba9a34de-4489-469d-879c-0f0f145321cd"] = new LicenseProperty("Microsoft Imagine Academy", "Security and identity"),
            ["2b317a4a-77a6-4188-9437-b68a77b4e2c6"] = new LicenseProperty("Microsoft Intune Device", "Security and identity"),
            ["2c21e77a-e0d6-4570-b38a-7ff2dc17d2ca"] = new LicenseProperty("Microsoft Intune Device for Government", "Security and identity"),
            ["e6025b08-2fa5-4313-bd0a-7e5ffca32958"] = new LicenseProperty("Microsoft Intune SMB", "Security and identity"),
            ["ddfae3e3-fcb2-4174-8ebd-3023cb213c8b"] = new LicenseProperty("Microsoft Power Apps Plan 2 (Qualified Offer)", "Power Platform"),
            ["dcb1a3ae-b33f-4487-846a-a640262fadf4"] = new LicenseProperty("Microsoft Power Apps Plan 2 Trial", "Power Platform"),
            ["4755df59-3f73-41ab-a249-596ad72b5504"] = new LicenseProperty("Microsoft Power Automate Plan 2", "Power Platform"),
            ["5b631642-bd26-49fe-bd20-1daaa972ef80"] = new LicenseProperty("Microsoft PowerApps for Developer", "Power Platform"),
            ["1f2f344a-700d-42c9-9427-5cea1d5d7ba6"] = new LicenseProperty("Microsoft Stream", "Business apps"),
            ["ec156933-b85b-4c50-84ec-c9e5603709ef"] = new LicenseProperty("Microsoft Stream Plan 2", "Business apps"),
            ["9bd7c846-9556-4453-a542-191d527209e8"] = new LicenseProperty("Microsoft Stream Storage Add-On (500 GB)", "Business apps"),
            ["16ddbbfc-09ea-4de2-b1d7-312db6112d70"] = new LicenseProperty("Microsoft Teams (Free)", "Communication"),
            ["1c27243e-fb4d-42b1-ae8c-fe25c9616588"] = new LicenseProperty("Microsoft Teams Audio Conferencing select dial-out", "Communication"),
            ["29a2f828-8f39-4837-b8ff-c957e86abe3c"] = new LicenseProperty("Microsoft Teams Commercial Cloud", "Communication"),
            ["fde42873-30b6-436b-b361-21af5a6b84ae"] = new LicenseProperty("Microsoft Teams Essentials", "Communication"),
            ["710779e8-3d4a-4c88-adb9-386c958d1fdf"] = new LicenseProperty("Microsoft Teams Exploratory", "Communication"),
            ["2cf22bcb-0c9e-4bc6-8daf-7e7654c0f285"] = new LicenseProperty("Microsoft Teams Phone Resource Account for GCC", "Communication"),
            ["440eaaa8-b3e0-484b-a8be-62870b9ba70a"] = new LicenseProperty("Microsoft Teams Phone Resoure Account", "Communication"),
            ["e43b5b99-8dfb-405f-9987-dc307f34bcbd"] = new LicenseProperty("Microsoft Teams Phone Standard", "Communication"),
            ["d01d9287-694b-44f3-bcc5-ada78c8d953e"] = new LicenseProperty("Microsoft Teams Phone Standard for DOD", "Communication"),
            ["d979703c-028d-4de5-acbf-7955566b69b9"] = new LicenseProperty("Microsoft Teams Phone Standard for Faculty", "Communication"),
            ["a460366a-ade7-4791-b581-9fbff1bdaa85"] = new LicenseProperty("Microsoft Teams Phone Standard for GCC", "Communication"),
            ["7035277a-5e49-4abc-a24f-0ec49c501bb5"] = new LicenseProperty("Microsoft Teams Phone Standard for GCCHIGH", "Communication"),
            ["aa6791d3-bb09-4bc2-afed-c30c3fe26032"] = new LicenseProperty("Microsoft Teams Phone Standard for Small and Medium Business", "Communication"),
            ["1f338bbc-767e-4a1e-a2d4-b73207cc5b93"] = new LicenseProperty("Microsoft Teams Phone Standard for Student", "Communication"),
            ["ffaf2d68-1c95-4eb3-9ddd-59b81fba0f61"] = new LicenseProperty("Microsoft Teams Phone Standard for TELSTRA", "Communication"),
            ["b0e7de67-e503-4934-b729-53d595ba5cd1"] = new LicenseProperty("Microsoft Teams Phone Standard_System_USGOV_DOD", "Communication"),
            ["985fcb26-7b94-475b-b512-89356697be71"] = new LicenseProperty("Microsoft Teams Phone Standard_USGOV_GCCHIGH", "Communication"),
            ["989a1621-93bc-4be0-835c-fe30171d6463"] = new LicenseProperty("Microsoft Teams Premium", "Communication"),
            ["6af4b3d6-14bb-4a2a-960c-6c902aad34f3"] = new LicenseProperty("Microsoft Teams Rooms Basic", "Communication"),
            ["50509a35-f0bd-4c5e-89ac-22f0e16a00f8"] = new LicenseProperty("Microsoft Teams Rooms Basic without Audio Conferencing", "Communication"),
            ["4cde982a-ede4-4409-9ae6-b003453c8ea6"] = new LicenseProperty("Microsoft Teams Rooms Pro", "Communication"),
            ["21943e3a-2429-4f83-84c1-02735cd49e78"] = new LicenseProperty("Microsoft Teams Rooms Pro without Audio Conferencing", "Communication"),
            ["295a8eb0-f78d-45c7-8b5b-1eed5ed02dff"] = new LicenseProperty("Microsoft Teams Shared Devices", "Communication"),
            ["b1511558-69bd-4e1b-8270-59ca96dba0f3"] = new LicenseProperty("Microsoft Teams Shared Devices for GCC", "Communication"),
            ["74fbf1bb-47c6-4796-9623-77dc7371723b"] = new LicenseProperty("Microsoft Teams Trial", "Communication"),
            ["9fa2f157-c8e4-4351-a3f2-ffa506da1406"] = new LicenseProperty("Microsoft Threat Experts - Experts on Demand", "Security and identity"),
            ["3d957427-ecdc-4df2-aacd-01cc9d519da8"] = new LicenseProperty("Microsoft Workplace Analytics", "Add-ons"),
            ["84951599-62b7-46f3-9c9d-30551b2ad607"] = new LicenseProperty("Multi-Geo Capabilities in Office 365", "Add-ons"),
            ["aa2695c9-8d59-4800-9dc8-12e01f1735af"] = new LicenseProperty("Nonprofit Portal", "Add-ons"),
            ["94763226-9b3c-4e75-a931-5c89701abe66"] = new LicenseProperty("Office 365 A1 for Faculty", "Office 365"),
            ["314c4481-f395-4525-be8b-2ec4bb1e9d91"] = new LicenseProperty("Office 365 A1 for Students", "Office 365"),
            ["78e66a63-337a-4a9a-8959-41c6654dfb56"] = new LicenseProperty("Office 365 A1 Plus for Faculty", "Office 365"),
            ["e82ae690-a2d5-4d76-8d30-7c6e01e6022e"] = new LicenseProperty("Office 365 A1 Plus for Students", "Office 365"),
            ["e578b273-6db4-4691-bba0-8d691f4da603"] = new LicenseProperty("Office 365 A3 for Faculty", "Office 365"),
            ["98b6e773-24d4-4c0d-a968-6e787a1f8204"] = new LicenseProperty("Office 365 A3 for Students", "Office 365"),
            ["a4585165-0533-458a-97e3-c400570268c4"] = new LicenseProperty("Office 365 A5 for faculty", "Office 365"),
            ["ee656612-49fa-43e5-b67e-cb1fdf7699df"] = new LicenseProperty("Office 365 A5 for students", "Office 365"),
            ["1b1b1f7a-8355-43b6-829f-336cfccb744c"] = new LicenseProperty("Office 365 Advanced Compliance", "Office 365"),
            ["1a585bba-1ce3-416e-b1d6-9c482b52fcf6"] = new LicenseProperty("Office 365 Advanced Compliance for GCC", "Office 365"),
            ["84d5f90f-cd0d-4864-b90b-1c7ba63b4808"] = new LicenseProperty("Office 365 Cloud App Security", "Office 365"),
            ["18181a46-0d4e-45cd-891e-60aabd171b4e"] = new LicenseProperty("Office 365 E1", "Office 365"),
            ["6634e0ce-1a9f-428c-a498-f84ec7b8aa2e"] = new LicenseProperty("Office 365 E2", "Office 365"),
            ["6fd2c87f-b296-42f0-b197-1e91e994b900"] = new LicenseProperty("Office 365 E3", "Office 365"),
            ["189a915c-fe4f-4ffa-bde4-85b9628d07a0"] = new LicenseProperty("Office 365 E3 Developer", "Office 365"),
            ["b107e5a3-3e60-4c0d-a184-a7e4395eb44c"] = new LicenseProperty("Office 365 E3_USGOV_DOD", "Office 365"),
            ["aea38a85-9bd5-4981-aa00-616b411205bf"] = new LicenseProperty("Office 365 E3_USGOV_GCCHIGH", "Office 365"),
            ["1392051d-0cb9-4b7a-88d5-621fee5e8711"] = new LicenseProperty("Office 365 E4", "Office 365"),
            ["c7df2760-2c81-4ef7-b578-5b5392b571df"] = new LicenseProperty("Office 365 E5", "Office 365"),
            ["26d45bd9-adf1-46cd-a9e1-51e9a5524128"] = new LicenseProperty("Office 365 E5 without Audio Conferencing", "Office 365"),
            ["99049c9c-6011-4908-bf17-15f496e6519d"] = new LicenseProperty("Office 365 Extra File Storage", "Office 365"),
            ["e5788282-6381-469f-84f0-3d7d4021d34d"] = new LicenseProperty("Office 365 Extra File Storage for GCC", "Office 365"),
            ["4b585984-651b-448a-9e53-3b10f069cf7f"] = new LicenseProperty("Office 365 F3", "Office 365"),
            ["3f4babde-90ec-47c6-995d-d223749065d1"] = new LicenseProperty("Office 365 G1 GCC", "Office 365"),
            ["535a3a29-c5f0-42fe-8215-d3b9e1f38c4a"] = new LicenseProperty("Office 365 G3 GCC", "Office 365"),
            ["8900a2c0-edba-4079-bdf3-b276e293b6a8"] = new LicenseProperty("Office 365 G5 GCC", "Office 365"),
            ["04a7fb0d-32e0-4241-b4f5-3f7618cd1162"] = new LicenseProperty("Office 365 Midsize Business", "Office 365"),
            ["bd09678e-b83c-4d3f-aaba-3dad4abd128b"] = new LicenseProperty("Office 365 Small Business", "Office 365"),
            ["fc14ec4a-4169-49a4-a51e-2c852931814b"] = new LicenseProperty("Office 365 Small Business Premium", "Office 365"),
            ["e6778190-713e-4e4f-9119-8b8238de25df"] = new LicenseProperty("OneDrive for Business (Plan 1)", "Communication"),
            ["ed01faf2-1d88-4947-ae91-45ca18703a96"] = new LicenseProperty("OneDrive for Business (Plan 2)", "Communication"),
            ["87bbbc60-4754-4998-8c88-227dca264858"] = new LicenseProperty("Power Apps and Logic Flows", "Power Platform"),
            ["bf666882-9c9b-4b2e-aa2f-4789b0a52ba2"] = new LicenseProperty("Power Apps per app baseline access", "Power Platform"),
            ["a8ad7d2b-b8cf-49d6-b25a-69094a0be206"] = new LicenseProperty("Power Apps per app Plan", "Power Platform"),
            ["b4d7b828-e8dc-4518-91f9-e123ae48440d"] = new LicenseProperty("Power Apps per app Plan (1 app or portal)", "Power Platform"),
            ["b30411f5-fea1-4a59-9ad9-3db7c7ead579"] = new LicenseProperty("Power Apps per user Plan", "Power Platform"),
            ["8e4c6baa-f2ff-4884-9c38-93785d0d7ba1"] = new LicenseProperty("Power Apps per user Plan for Government", "Power Platform"),
            ["eca22b68-b31f-4e9c-a20c-4d40287bc5dd"] = new LicenseProperty("Power Apps Plan 1 for Government", "Power Platform"),
            ["57f3babd-73ce-40de-bcb2-dadbfbfff9f7"] = new LicenseProperty("Power Apps Portals login capacity add-on Tier 2 (10 unit min)", "Power Platform"),
            ["26c903d5-d385-4cb1-b650-8d81a643b3c4"] = new LicenseProperty("Power Apps Portals login capacity add-on Tier 2 (10 unit min) for Government", "Power Platform"),
            ["15a64d3e-5b99-4c4b-ae8f-aa6da264bfe7"] = new LicenseProperty("Power Apps Portals page view capacity add-on for Government", "Power Platform"),
            ["b3a42176-0a8c-4c3f-ba4e-f2b37fe5be6b"] = new LicenseProperty("Power Automate per flow plan", "Power Platform"),
            ["4a51bf65-409c-4a91-b845-1121b571cc9d"] = new LicenseProperty("Power Automate per user plan", "Power Platform"),
            ["d80a4c5d-8f05-4b64-9926-6574b9e6aee4"] = new LicenseProperty("Power Automate per user plan dept", "Power Platform"),
            ["c8803586-c136-479a-8ff3-f5f32d23a68e"] = new LicenseProperty("Power Automate per user plan for Government", "Power Platform"),
            ["eda1941c-3c4f-4995-b5eb-e85a42175ab9"] = new LicenseProperty("Power Automate per user with attended RPA plan", "Power Platform"),
            ["2b3b0c87-36af-4d15-8124-04a691cc2546"] = new LicenseProperty("Power Automate Plan 1 for Government (Qualified Offer)", "Power Platform"),
            ["3539d28c-6e35-4a30-b3a9-cd43d5d3e0e2"] = new LicenseProperty("Power Automate unattended RPA add-on", "Power Platform"),
            ["e2767865-c3c9-4f09-9f99-6eee6eef861a"] = new LicenseProperty("Power BI", "Power BI"),
            ["a403ebcc-fae0-4ca2-8c8c-7a907fd6c235"] = new LicenseProperty("Power BI (free)", "Power BI"),
            ["45bc2c81-6072-436a-9b0b-3b12eefbc402"] = new LicenseProperty("Power BI for Office 365 Add-On", "Power BI"),
            ["7b26f5ab-a763-4c00-a1ac-f6c4b5506945"] = new LicenseProperty("Power BI Premium P1", "Power BI"),
            ["c1d032e0-5619-4761-9b5c-75b6831e1711"] = new LicenseProperty("Power BI Premium Per User", "Power BI"),
            ["de376a03-6e5b-42ec-855f-093fb50b8ca5"] = new LicenseProperty("Power BI Premium Per User Add-On", "Power BI"),
            ["f168a3fb-7bcf-4a27-98c3-c235ea4b78b4"] = new LicenseProperty("Power BI Premium Per User Dept", "Power BI"),
            ["f8a1db68-be16-40ed-86d5-cb42ce701560"] = new LicenseProperty("Power BI Pro", "Power BI"),
            ["420af87e-8177-4146-a780-3786adaffbca"] = new LicenseProperty("Power BI Pro CE", "Power BI"),
            ["3a6a908c-09c5-406a-8170-8ebb63c42882"] = new LicenseProperty("Power BI Pro Dept", "Power BI"),
            ["de5f128b-46d7-4cfc-b915-a89ba060ea56"] = new LicenseProperty("Power BI Pro for Faculty", "Power BI"),
            ["f0612879-44ea-47fb-baf0-3d76d9235576"] = new LicenseProperty("Power BI Pro for GCC", "Power BI"),
            ["e4e55366-9635-46f4-a907-fc8c3b5ec81f"] = new LicenseProperty("Power Virtual Agent", "Power Platform"),
            ["606b54a9-78d8-4298-ad8b-df6ef4481c80"] = new LicenseProperty("Power Virtual Agents Viral Trial", "Power Platform"),
            ["a10d5e58-74da-4312-95c8-76be4e5b75a0"] = new LicenseProperty("Project for Office 365", "Business apps"),
            ["776df282-9fc0-4862-99e2-70e561b9909e"] = new LicenseProperty("Project Online Essentials", "Business apps"),
            ["e433b246-63e7-4d0b-9efa-7940fa3264d6"] = new LicenseProperty("Project Online Essentials for Faculty", "Business apps"),
            ["ca1a159a-f09e-42b8-bb82-cb6420f54c8e"] = new LicenseProperty("Project Online Essentials for GCC", "Business apps"),
            ["09015f9f-377f-4538-bbb5-f75ceb09358a"] = new LicenseProperty("Project Online Premium", "Business apps"),
            ["2db84718-652c-47a7-860c-f10d8abbdae3"] = new LicenseProperty("Project Online Premium without Project Client", "Business apps"),
            ["f82a60b8-1ee3-4cfb-a4fe-1c6a53c2656c"] = new LicenseProperty("Project Online with Project for Office 365", "Business apps"),
            ["beb6439c-caad-48d3-bf46-0c82871e12be"] = new LicenseProperty("Project Plan 1", "Business apps"),
            ["84cd610f-a3f8-4beb-84ab-d9d2c902c6c9"] = new LicenseProperty("Project Plan 1 (for Department)", "Business apps"),
            ["53818b1b-4a27-454b-8896-0dba576410e6"] = new LicenseProperty("Project Plan 3", "Business apps"),
            ["46102f44-d912-47e7-b0ca-1bd7b70ada3b"] = new LicenseProperty("Project Plan 3 (for Department)", "Business apps"),
            ["46974aed-363e-423c-9e6a-951037cec495"] = new LicenseProperty("Project Plan 3 for Faculty", "Business apps"),
            ["074c6829-b3a0-430a-ba3d-aca365e57065"] = new LicenseProperty("Project Plan 3 for GCC", "Business apps"),
            ["f2230877-72be-4fec-b1ba-7156d6f75bd6"] = new LicenseProperty("Project Plan 5 for GCC", "Business apps"),
            ["8c4ce438-32a7-4ac5-91a6-e22ae08d9c8b"] = new LicenseProperty("Rights Management Adhoc", "Add-ons"),
            ["093e8d14-a334-43d9-93e3-30589a8b47d0"] = new LicenseProperty("Rights Management Service Basic Content Protection", "Add-ons"),
            ["08e18479-4483-4f70-8f17-6f92156d8ea9"] = new LicenseProperty("Sensor Data Intelligence Additional Machines Add-in for Dynamics 365 Supply Chain Management", "Dynamics 365"),
            ["9ea4bdef-a20b-4668-b4a7-73e1f7696e0a"] = new LicenseProperty("Sensor Data Intelligence Scenario Add-in for Dynamics 365 Supply Chain Management", "Dynamics 365"),
            ["1fc08a02-8b3d-43b9-831e-f76859e04e1a"] = new LicenseProperty("SharePoint Online (Plan 1)", "Communication"),
            ["a9732ec9-17d9-494c-a51c-d6b45b384dcb"] = new LicenseProperty("SharePoint Online (Plan 2)", "Communication"),
            ["f61d4aba-134f-44e9-a2a0-f81a5adb26e4"] = new LicenseProperty("SharePoint Syntex", "Add-ons"),
            ["b8b749f8-a4ef-4887-9539-c95b1eaa5db7"] = new LicenseProperty("Skype for Business Online (Plan 1)", "Communication"),
            ["d42c793f-6c78-4f43-92ca-e8f6a02b035f"] = new LicenseProperty("Skype for Business Online (Plan 2)", "Communication"),
            ["d3b4fe1f-9992-4930-8acb-ca6ec609365e"] = new LicenseProperty("Skype for Business PSTN Domestic and International Calling", "Communication"),
            ["0dab259f-bf13-4952-b7f8-7db8f131b28d"] = new LicenseProperty("Skype for Business PSTN Domestic Calling", "Communication"),
            ["54a152dc-90de-4996-93d2-bc47e670fc06"] = new LicenseProperty("Skype for Business PSTN Domestic Calling (120 Minutes)", "Communication"),
            ["06b48c5f-01d9-4b18-9015-03b52040f51a"] = new LicenseProperty("Skype for Business PSTN Usage Calling Plan", "Communication"),
            ["ae2343d1-0999-43f6-ae18-d816516f6e78"] = new LicenseProperty("Teams Phone with Calling Plan", "Communication"),
            ["de3312e1-c7b0-46e6-a7c3-a515ff90bc86"] = new LicenseProperty("TELSTRA Calling for O365", "Communication"),
            ["9f3d9c1d-25a5-4aaa-8e59-23a1e6450a67"] = new LicenseProperty("Universal Print", "Microsoft 365"),
            ["4b244418-9658-4451-a2b8-b5e2b364e9bd"] = new LicenseProperty("Visio Online Plan 1", "Business apps"),
            ["c5928f49-12ba-48f7-ada3-0d743a3601d5"] = new LicenseProperty("Visio Online Plan 2", "Business apps"),
            ["ca7f3140-d88c-455b-9a1c-7f0679e31a76"] = new LicenseProperty("Visio Plan 1", "Business apps"),
            ["38b434d2-a15e-4cde-9a98-e737c75623e1"] = new LicenseProperty("Visio Plan 2", "Business apps"),
            ["4ae99959-6b0f-43b0-b1ce-68146001bdba"] = new LicenseProperty("Visio Plan 2 for GCC", "Business apps"),
            ["4016f256-b063-4864-816e-d818aad600c9"] = new LicenseProperty("Viva Topics", "Add-ons"),
            ["8efbe2f6-106e-442f-97d4-a59aa6037e06"] = new LicenseProperty("Windows 10 Enterprise A3 for faculty", "Windows"),
            ["d4ef921e-840b-4b48-9a90-ab6698bc7b31"] = new LicenseProperty("Windows 10 Enterprise A3 for students", "Windows"),
            ["cb10e6cd-9da4-4992-867b-67546b1db821"] = new LicenseProperty("WINDOWS 10 ENTERPRISE E3", "Windows"),
            ["6a0f6da5-0b87-4190-a6ae-9bb5a2b9546a"] = new LicenseProperty("WINDOWS 10 ENTERPRISE E3", "Windows"),
            ["488ba24a-39a9-4473-8ee5-19291e71b002"] = new LicenseProperty("Windows 10 Enterprise E5", "Windows"),
            ["938fd547-d794-42a4-996c-1cc206619580"] = new LicenseProperty("Windows 10 Enterprise E5 Commercial (GCC Compatible)", "Windows"),
            ["1e7e1070-8ccb-4aca-b470-d7cb538cb07e"] = new LicenseProperty("Windows 10/11 Enterprise E5 (Original)", "Windows"),
            ["d13ef257-988a-46f3-8fce-f47484dd4550"] = new LicenseProperty("Windows 10/11 Enterprise VDA", "Windows"),
            ["816eacd3-e1e3-46b3-83c8-1ffd37e053d9"] = new LicenseProperty("Windows 365 Business 1 vCPU 2 GB 64 GB", "Windows 365"),
            ["135bee78-485b-4181-ad6e-40286e311850"] = new LicenseProperty("Windows 365 Business 2 vCPU 4 GB 128 GB", "Windows 365"),
            ["805d57c3-a97d-4c12-a1d0-858ffe5015d0"] = new LicenseProperty("Windows 365 Business 2 vCPU 4 GB 256 GB", "Windows 365"),
            ["42e6818f-8966-444b-b7ac-0027c83fa8b5"] = new LicenseProperty("Windows 365 Business 2 vCPU 4 GB 64 GB", "Windows 365"),
            ["71f21848-f89b-4aaa-a2dc-780c8e8aac5b"] = new LicenseProperty("Windows 365 Business 2 vCPU 8 GB 128 GB", "Windows 365"),
            ["750d9542-a2f8-41c7-8c81-311352173432"] = new LicenseProperty("Windows 365 Business 2 vCPU 8 GB 256 GB", "Windows 365"),
            ["ad83ac17-4a5a-4ebb-adb2-079fb277e8b9"] = new LicenseProperty("Windows 365 Business 4 vCPU 16 GB 128 GB", "Windows 365"),
            ["439ac253-bfbc-49c7-acc0-6b951407b5ef"] = new LicenseProperty("Windows 365 Business 4 vCPU 16 GB 128 GB (with Windows Hybrid Benefit)", "Windows 365"),
            ["b3891a9f-c7d9-463c-a2ec-0b2321bda6f9"] = new LicenseProperty("Windows 365 Business 4 vCPU 16 GB 256 GB", "Windows 365"),
            ["1b3043ad-dfc6-427e-a2c0-5ca7a6c94a2b"] = new LicenseProperty("Windows 365 Business 4 vCPU 16 GB 512 GB", "Windows 365"),
            ["3cb45fab-ae53-4ff6-af40-24c1915ca07b"] = new LicenseProperty("Windows 365 Business 8 vCPU 32 GB 128 GB", "Windows 365"),
            ["fbc79df2-da01-4c17-8d88-17f8c9493d8f"] = new LicenseProperty("Windows 365 Business 8 vCPU 32 GB 256 GB", "Windows 365"),
            ["8ee402cd-e6a8-4b67-a411-54d1f37a2049"] = new LicenseProperty("Windows 365 Business 8 vCPU 32 GB 512 GB", "Windows 365"),
            ["0c278af4-c9c1-45de-9f4b-cd929e747a2c"] = new LicenseProperty("Windows 365 Enterprise 1 vCPU 2 GB 64 GB", "Windows 365"),
            ["226ca751-f0a4-4232-9be5-73c02a92555e"] = new LicenseProperty("Windows 365 Enterprise 2 vCPU 4 GB 128 GB", "Windows 365"),
            ["bce09f38-1800-4a51-8d50-5486380ba84a"] = new LicenseProperty("Windows 365 Enterprise 2 vCPU 4 GB 128 GB (Preview)", "Windows 365"),
            ["5265a84e-8def-4fa2-ab4b-5dc278df5025"] = new LicenseProperty("Windows 365 Enterprise 2 vCPU 4 GB 256 GB", "Windows 365"),
            ["7bb14422-3b90-4389-a7be-f1b745fc037f"] = new LicenseProperty("Windows 365 Enterprise 2 vCPU 4 GB 64 GB", "Windows 365"),
            ["e2aebe6c-897d-480f-9d62-fff1381581f7"] = new LicenseProperty("Windows 365 Enterprise 2 vCPU 8 GB 128 GB", "Windows 365"),
            ["1c79494f-e170-431f-a409-428f6053fa35"] = new LicenseProperty("Windows 365 Enterprise 2 vCPU 8 GB 256 GB", "Windows 365"),
            ["d201f153-d3b2-4057-be2f-fe25c8983e6f"] = new LicenseProperty("Windows 365 Enterprise 4 vCPU 16 GB 128 GB", "Windows 365"),
            ["96d2951e-cb42-4481-9d6d-cad3baac177e"] = new LicenseProperty("Windows 365 Enterprise 4 vCPU 16 GB 256 GB", "Windows 365"),
            ["0da63026-e422-4390-89e8-b14520d7e699"] = new LicenseProperty("Windows 365 Enterprise 4 vCPU 16 GB 512 GB", "Windows 365"),
            ["c97d00e4-0c4c-4ec2-a016-9448c65de986"] = new LicenseProperty("Windows 365 Enterprise 8 vCPU 32 GB 128 GB", "Windows 365"),
            ["7818ca3e-73c8-4e49-bc34-1276a2d27918"] = new LicenseProperty("Windows 365 Enterprise 8 vCPU 32 GB 256 GB", "Windows 365"),
            ["9fb0ba5f-4825-4e84-b239-5167a3a5d4dc"] = new LicenseProperty("Windows 365 Enterprise 8 vCPU 32 GB 512 GB", "Windows 365"),
            ["90369797-7141-4e75-8f5e-d13f4b6092c1"] = new LicenseProperty("Windows 365 Shared Use 2 vCPU 4 GB 128 GB", "Windows 365"),
            ["8fe96593-34d3-49bb-aeee-fb794fed0800"] = new LicenseProperty("Windows 365 Shared Use 2 vCPU 4 GB 256 GB", "Windows 365"),
            ["1f9990ca-45d9-4c8d-8d04-a79241924ce1"] = new LicenseProperty("Windows 365 Shared Use 2 vCPU 4 GB 64 GB", "Windows 365"),
            ["2d21fc84-b918-491e-ad84-e24d61ccec94"] = new LicenseProperty("Windows 365 Shared Use 2 vCPU 8 GB 128 GB", "Windows 365"),
            ["2eaa4058-403e-4434-9da9-ea693f5d96dc"] = new LicenseProperty("Windows 365 Shared Use 2 vCPU 8 GB 256 GB", "Windows 365"),
            ["1bf40e76-4065-4530-ac37-f1513f362f50"] = new LicenseProperty("Windows 365 Shared Use 4 vCPU 16 GB 128 GB", "Windows 365"),
            ["a9d1e0df-df6f-48df-9386-76a832119cca"] = new LicenseProperty("Windows 365 Shared Use 4 vCPU 16 GB 256 GB", "Windows 365"),
            ["469af4da-121c-4529-8c85-9467bbebaa4b"] = new LicenseProperty("Windows 365 Shared Use 4 vCPU 16 GB 512 GB", "Windows 365"),
            ["f319c63a-61a9-42b7-b786-5695bc7edbaf"] = new LicenseProperty("Windows 365 Shared Use 8 vCPU 32 GB 128 GB", "Windows 365"),
            ["fb019e88-26a0-4218-bd61-7767d109ac26"] = new LicenseProperty("Windows 365 Shared Use 8 vCPU 32 GB 256 GB", "Windows 365"),
            ["f4dc1de8-8c94-4d37-af8a-1fca6675590a"] = new LicenseProperty("Windows 365 Shared Use 8 vCPU 32 GB 512 GB", "Windows 365"),
            ["6470687e-a428-4b7a-bef2-8a291ad947c9"] = new LicenseProperty("Windows Store for Business", "Add-ons"),
            ["c7e9d9e6-1981-4bf3-bb50-a5bdfaa06fb2"] = new LicenseProperty("Windows Store for Business EDU Faculty", "Add-ons")

        };

    }
}


