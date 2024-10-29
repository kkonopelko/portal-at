using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.Factories
{
    public class BrowserFactory
    {
        public IBrowser Browser { get; set; }
        public IBrowserContext BrowserContext { get; set; }
        public IPage Page { get; set; }

        public BrowserFactory()
        {
            // initialize driver options? type, mode
        }

        public async Task<IBrowserContext> GetBrowserAsync()
        {
            // Initialize playwright
            var playwright = await Playwright.CreateAsync();

            // Configure browser options
            var browserOptions = new BrowserTypeLaunchOptions
            {
                Headless = false, // Set headless mode to false
                // Args = new[] { "--start-maximized" } // Maximize the window - NOT WORKING
            };

            // Launch the browser with the configured options
            var browser = await playwright.Chromium.LaunchAsync(browserOptions);
            var a = browser.NewContextAsync().Result;
            return await browser.NewContextAsync();
        }

        public async Task Close()
        {
            await BrowserContext.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}
