using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using Portal.Automation.Web.Domain;
using IBrowser = Portal.Automation.Web.Domain.IBrowser;
using IPwBroser = Microsoft.Playwright.IBrowser;

namespace Portal.Automation.Web.Playwright2;

internal class PwBrowser(
    PageFactory pageFactory,
    ITestContextProvider testContextProvider,
    IServiceProvider serviceProvider) : IBrowser
{
    private IPwBroser browser;
    private IBrowserContext browserContext;
    public async Task CloseAsync()
    {
        if (browserContext is not null)
        {
            await browserContext.CloseAsync();
        }

        if (browser is not null)
        {
            await browser.CloseAsync();
        }
    }

    public async Task<T> NavigateAsync<T>(string url)
        where T : Domain.Pages.IPage
    {
        await InitializeBrowserAsync();
        var page = await pageFactory.InitializePageAsync(browserContext);
        await page.GotoAsync(url);

        return serviceProvider.GetRequiredService<T>();
    }

    private async Task InitializeBrowserAsync()
    {
        var playwright = await Playwright.CreateAsync();

        // Configure browser options
        var browserOptions = new BrowserTypeLaunchOptions
        {
            Headless = false, // Set headless mode to false
                              // Args = new[] { "--start-maximized" } // Maximize the window - NOT WORKING
        };

        // Launch the browser with the configured options
        browser = await playwright.Chromium.LaunchAsync(browserOptions);
        browserContext = await browser.NewContextAsync();
    }
}
