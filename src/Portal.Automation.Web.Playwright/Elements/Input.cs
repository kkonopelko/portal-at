using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.Elements
{
    public class Input(ILocator locator)
    {
        public ILocator Locator = locator;

        public async Task FillAsync(string value) => await Locator.FillAsync(value);
    }
}
