using System.Collections.Concurrent;
using System.IO;
using System;
using OpenQA.Selenium;
using Portal.Automation.Web.Drivers.Enums;
using OpenQA.Selenium.Chrome;
using Lhh.Admin.Automation.Web.Driver.DriverOptions;
using Portal.Automation.Web.Drivers.Models.Settings;

namespace Portal.Automation.Web.Drivers
{
    public class DriverFactory
    {
        private static readonly ConcurrentDictionary<string, IWebDriver> _driverDictionary = new ConcurrentDictionary<string, IWebDriver>();

        private readonly DriverSettings _driverSettings;
        private readonly DriverRunType _driverRunType;

        private string _downloadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");

        public DriverFactory(DriverSettings driverSettings)
        {
            _driverSettings = driverSettings;
            _driverRunType = (DriverRunType)Enum.Parse(typeof(DriverRunType), _driverSettings.BrowserRunType);
        }

        public IWebDriver GetDriver(string testContextTestId)
        {
            return _driverDictionary.GetOrAdd(testContextTestId, (webDriver) => GetNewDriverInstance());
        }

        public IWebDriver GetNewDriverInstance()
        {
            var driver = GetChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        public void ShutDownDriver(string testContextTestId)
        {
            _driverDictionary.TryRemove(testContextTestId, out IWebDriver driver);
            driver?.Quit();
        }


        private IWebDriver GetChromeDriver()
            => _driverRunType switch
            {
                DriverRunType.Regular => new ChromeDriver(new ChromeDriverOptions().GetDriverOptionsForRegularRun(GetDownloadDirectoryPath(_downloadDirectory))),
                DriverRunType.Headless or _ => new ChromeDriver(new ChromeDriverOptions().GetDriverOptionsForHeadlessRun(GetDownloadDirectoryPath(_downloadDirectory)))
            };

        private string GetDownloadDirectoryPath(string downloadDirectory)
        {
            if (!Directory.Exists(downloadDirectory))
            {
                Directory.CreateDirectory(downloadDirectory);
            }

            return _downloadDirectory;
        }
    }
}