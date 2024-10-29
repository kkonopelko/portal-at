using Microsoft.Playwright;
using Portal.Automation.Web.Playwright1.Interfaces.PageObjects;
using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.PageObjects
{
    public class HomePage : IHomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetUrl()
        {
            return await _page.TitleAsync();
        }

        public async Task<bool> IsShpingCartDisplayed()
        {
            return await _page.GetByTestId("shopping_cart_container").IsVisibleAsync();
        }
    }
}
