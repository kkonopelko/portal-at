using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.Elements
{
    public class Button(ILocator locator)
    {
        public ILocator Locator = locator;

        public async Task ClickAsync() => await Locator.ClickAsync();

        public async Task<bool> IsVisibleAsync() => await Locator.IsVisibleAsync();

        public async Task<bool> IsDisabledAsync() => await Locator.IsDisabledAsync();
    }
}
