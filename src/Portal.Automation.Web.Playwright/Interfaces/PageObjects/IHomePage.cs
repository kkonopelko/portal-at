using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.Interfaces.PageObjects
{
    public interface IHomePage
    {
        public Task<string> GetUrl();
        public Task<bool> IsShpingCartDisplayed();
    }
}
