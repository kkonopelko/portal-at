using Microsoft.Playwright;
using Portal.Automation.Web.Domain;
using System.Collections.Concurrent;

namespace Portal.Automation.Web.Playwright2;

internal class PageFactory(ITestContextProvider testContextProvider)
{
    ConcurrentDictionary<string, IPage> _pages = new ConcurrentDictionary<string, IPage>();

    internal async Task<IPage> InitializePageAsync(IBrowserContext context)

    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        var testId = testContextProvider.TestId;

        IPage page = await context.NewPageAsync();

        _pages.TryAdd(testId, page);

        return page;
    }

    internal IPage GetPage()
    {
        var testId = testContextProvider.TestId;

        if (!_pages.TryGetValue(testId, out IPage? page) || page is null)
        {
            throw new ArgumentNullException($"There is no such page for testid: {testId}");
        }

        return page;
    }
}
