using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.Factories
{
    public class PageFactory(BrowserFactory browserFactory)
    {
        public async Task<IPage> GetPageAsync()
        {
            var context = await browserFactory.GetBrowserAsync();
            return await context.NewPageAsync();
        }
    }
}
