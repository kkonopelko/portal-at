using NUnit.Framework;
using Portal.Automation.Tests.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Automation.Tests.UI
{
    [TestFixture]
    public class LoginPlaywrightTestsTests //: PageTest
    {
        private readonly string _baseUrl = "https://www.saucedemo.com/";

        private readonly Dictionary<string, Credentials> _users = new Dictionary<string, Credentials>
        {
            { "standart", new Credentials { UserName = "standard_user", Password = "secret_sauce" } },
            { "locked", new Credentials { UserName = "locked_out_user", Password = "secret_sauce" } },
            { "error", new Credentials { UserName = "error_user", Password = "secret_sauce" } }
        };

        //[Test]
        //[Description(@"
        //Test steps:
        //1. Open login page
        //2. Type valid userName and password
        //3. Click on login button
        //    Check:           
        //    - Product page displayed
        //    - Url contains /inventory.html
        //    - Product cart is displayed in the right corner")]
        //public async Task VerifySuccessLoginFlow()
        //{
        //    var user = _users.Where(x => x.Key == "standart").Select(x => x.Value).FirstOrDefault();

        //    // Initialize playwright
        //    var playwright = await Playwright.CreateAsync();

        //    // Configure browser options
        //    var browserOptions = new BrowserTypeLaunchOptions
        //    {
        //        Headless = false, // Set headless mode to false
        //        // Args = new[] { "--start-maximized" } // Maximize the window - NOT WORKING
        //    };

        //    // Launch the browser with the configured options
        //    var browser = await playwright.Chromium.LaunchAsync(browserOptions);

        //    // Create a new browser context with viewport size set to null
        //    var contextOptions = new BrowserNewContextOptions
        //    {
        //        ViewportSize = null // Disable the viewport size setting to use full screen size -NOT WORKING
        //    };

        //    // Create a new browser context
        //    var context = await browser.NewContextAsync(contextOptions);

        //    // page
        //    var page  = await context.NewPageAsync();
        //    await page.GotoAsync(_baseUrl);
        //    await page.FillAsync("id=user-name", user.UserName);
        //    await page.FillAsync("id=password", user.Password);
        //    await page.ClickAsync("id=login-button");
        //    Thread.Sleep(5000);

        //    //// Expect a title "to contain" a substring.
        //    // await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        //    // screenshot
        //    // await page.ScreenshotAsync();

        //    // Close the browser
        //    await context.CloseAsync();
        //    await browser.CloseAsync();
        //}
    }
}
