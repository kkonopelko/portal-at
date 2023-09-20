using OpenQA.Selenium;

namespace Portal.Automation.Web.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver { get; }

        public virtual string RelativeUri { get; } = string.Empty;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
