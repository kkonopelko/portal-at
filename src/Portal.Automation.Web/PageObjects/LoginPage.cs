using OpenQA.Selenium;
using System;

namespace Portal.Automation.Web.PageObjects
{
    public class LoginPage : BasePage
    {
        #region PageLocators
        private IWebElement _userNameField => Driver.FindElement(By.Id("username"));

        private IWebElement _passwordField => Driver.FindElement(By.Id("password"));

        private IWebElement _submitBtn => Driver.FindElement(By.Id("submit"));

        private IWebElement _errorMsgLabel => Driver.FindElement(By.Id("error"));
        #endregion

        public override string RelativeUri => "practice-test-login";

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage TypeUserName(String userName)
        {
            _userNameField.SendKeys(userName);
            return this;
        }

        public LoginPage TypePassword(string password)
        {
            _passwordField.SendKeys(password);
            return this;
        }

        public HomePage Login(string username, string password)
        {
            return TypeUserName(username)
                   .TypePassword(password)
                   .ClickLoginButtonSuccessLogin();
        }

        public HomePage ClickLoginButtonSuccessLogin()
        {
            _submitBtn.Click();
            return new HomePage(Driver);
        }

        public LoginPage ClickLoginButtonUnsuccessLogin()
        {
            _submitBtn.Click();
            return this;
        }

        public bool IsErrorMessageLabelDisplayed()
        {
            return _errorMsgLabel.Displayed;
        }

        public string GetErrorMessageLabelText()
        {
            return _errorMsgLabel.Text;
        }
    }
}
