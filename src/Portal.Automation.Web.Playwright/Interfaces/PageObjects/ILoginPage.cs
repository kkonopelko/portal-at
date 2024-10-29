using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.Interfaces.PageObjects
{
    public interface ILoginPage
    {
        public Task Navigate();
        public Task<ILoginPage> TypeUsername(string userName);
        public Task<ILoginPage> TypePassword(string password);
        public Task<IHomePage> ClickLoginButton();
    }
}
