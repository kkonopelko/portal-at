using Bogus;
using FluentAssertions;
using NUnit.Framework;
using Portal.Automation.Tests.UI.Base;
using Portal.Automation.Web.PageObjects;
using Portal.Automation.Web.Utils;
using System.Collections;

namespace Portal.Automation.Tests.UI
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        [Description(@"
        Test steps:
        1. Open login page
        2. Type valid userName and password
        3. Click on submit button
            Check:           
            - Success login text
            - Logout button is displayed")]
        public void VerifySuccessLoginFlow()
        {
            #region Arrange
            var userData = new { username = "student", password = "Password123" };
            #endregion

            var homePage = GetService<Navigation>()
                 .GoToPage<LoginPage>()
                 .Login(userData.username, userData.password);

            homePage.IsLogoutButtonDisplayed().Should().BeTrue();
            homePage.GetSuccessLoginText().Should().Be($"Congratulations {userData.username}. You successfully logged in!");
        }

        [TestCaseSource(nameof(GetDataForIncorrectLogin))]
        [Description(@"
        Test steps:
        1. Open login page
        2. Type invalid credentials (userName or password)
        3. Click on submit button
            Check:           
            - Validation text message")]
        public void FailedLogin_IncorrectLoginOrPassword(string username, string password, string expectedValidationText)
        {
            var loginPage = GetService<Navigation>()
                 .GoToPage<LoginPage>()
                 .TypeUserName(username)
                 .TypePassword(password)
                 .ClickLoginButtonUnsuccessLogin();

            loginPage.IsErrorMessageLabelDisplayed().Should().BeTrue();
            loginPage.GetErrorMessageLabelText().Should().Be(expectedValidationText);          
        }

        private static IEnumerable GetDataForIncorrectLogin()
        {
            yield return new TestCaseData(
                new Faker().Random.String(),
                "Password123",
                "Your username is invalid!").SetArgDisplayNames("Invalid username");

            yield return new TestCaseData(
                "student",
                new Faker().Random.String(),
                "Your password is invalid!").SetArgDisplayNames("Invalid password");

            yield return new TestCaseData(
                new Faker().Random.String(),
                new Faker().Random.String(),
                "Your username is invalid!").SetArgDisplayNames("Invalid username and password");
        }
    }
}
