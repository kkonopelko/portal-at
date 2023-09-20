using OpenQA.Selenium.Chrome;
using Portal.Automation.Web.Drivers.DriverOptions;
using System.IO;

namespace Lhh.Admin.Automation.Web.Driver.DriverOptions
{
    public class ChromeDriverOptions : IDriverOptions<ChromeOptions>
    {
        public ChromeOptions GetDriverOptionsForRegularRun(string downloadDirectory)
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArgument("use-fake-device-for-media-stream");
            options.AddArgument("use-fake-ui-for-media-stream");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArguments("--incognito");
            
            options.AddUserProfilePreference("download.default_directory", downloadDirectory ?? Directory.GetCurrentDirectory());          
            options.AddUserProfilePreference("safebrowsing.enabled", "false");

            return options;
        }

        public ChromeOptions GetDriverOptionsForHeadlessRun(string downloadDirectory)
        {
            var options = new ChromeOptions();
            options.AddArguments("--window-size=1680,1050");
            options.AddArguments("--headless=new"); //for debug add option "--remote-debugging-port=9222" and debug at http://127.0.0.1:9222, in parallel tests will be used same port and stuck
            options.AddArgument("use-fake-ui-for-media-stream");
            options.AddArgument("use-fake-device-for-media-stream");

            options.AddUserProfilePreference("download.default_directory", downloadDirectory ?? Directory.GetCurrentDirectory());
            options.AddUserProfilePreference("safebrowsing.enabled", "false");

            return options;
        }
    }
}