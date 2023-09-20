using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Portal.Automation.Web.PageObjects;
using System;
using System.Linq;

namespace Portal.Automation.Web.Utils
{
    public class Navigation
    {
        private const int _waitingTime = 40;

        private readonly IWebDriver _driver;
        private readonly Uri _baseUri;

        protected WebDriverWait Wait { get; }

        public Navigation(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUri = new Uri(baseUrl);
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_waitingTime));
        }

        public T GoToPage<T>(string? relativeUri = default)
           where T : BasePage
        {
            var instance = (T)Activator.CreateInstance(typeof(T), _driver)!;
            Uri uri = new Uri(_baseUri, relativeUri ?? instance?.RelativeUri);

            _driver.Navigate().GoToUrl(uri);

            return instance!;
        }

        public Navigation RefreshPage()
        {
            _driver.Navigate().Refresh();
            return this;
        }

        public Navigation BackToPreviousPage()
        {
            _driver.Navigate().Back();
            return this;
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public Navigation OpenNewTab()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return this;
        }

        public Navigation NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }

        public Navigation SwitchToFirstTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            return this;
        }

        public Navigation SwitchToLastTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return this;
        }

        public Navigation ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            return this;
        }

        public Navigation DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
            return this;
        }

        public Navigation AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
            return this;
        }

        public string GetAlertMessage()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public Navigation CloseCurrentTab()
        {
            _driver.Close();
            return this;
        }
    }
}
