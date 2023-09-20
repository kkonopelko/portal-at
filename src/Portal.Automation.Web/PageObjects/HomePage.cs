using OpenQA.Selenium;

namespace Portal.Automation.Web.PageObjects
{
    public class HomePage : BasePage
    {
        #region PageLocators
        private IWebElement _successLoginText => Driver.FindElement(By.XPath(".//div[@id='loop-container']//strong"));

        private IWebElement _logoutBtn => Driver.FindElement(By.XPath(".//a[.='Log out']"));
        #endregion

        public override string RelativeUri => "logged-in-successfully";

        public HomePage(IWebDriver driver) : base(driver) { }

        public bool IsLogoutButtonDisplayed()
        {
            return _logoutBtn.Displayed;
        }

        public string GetSuccessLoginText()
        {
            return _successLoginText.Text;
        }
    }
}
