using Microsoft.Playwright;
using Portal.Automation.Web.Playwright1.Elements;
using Portal.Automation.Web.Playwright1.Factories;
using Portal.Automation.Web.Playwright1.Interfaces.PageObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Automation.Web.Playwright1.PageObjects
{
    public class LoginPage : ILoginPage
    {
        private Lazy<Button> _loginButton { get; set; }

        private readonly PageFactory _pageFactory;

        private IPage _page;

        public LoginPage(PageFactory pageFactory)
        {
            _pageFactory = pageFactory;
        }

        public async Task Navigate()
        {
            await (await GetPageAsync())
                .GotoAsync("https://www.saucedemo.com/");
        }

        public async Task<ILoginPage> TypeUsername(string userName)
        {
            await (await GetPageAsync()).FillAsync("id=user-name", userName);
            return this;
        }

        public async Task<ILoginPage> TypePassword(string password)
        {
            await (await GetPageAsync()).FillAsync("id=password", password);
            return this;
        }

        public async Task<IHomePage> ClickLoginButton()
        {
            await (await GetPageAsync()).ClickAsync("id=login-button");
            return new HomePage(await GetPageAsync());
        }

        private async Task<IPage> GetPageAsync()
        {
            if (_page is null)
            {
                var slim = new SemaphoreSlim(1, 1);

                try
                {
                    await slim.WaitAsync();

                    if (_page is null)
                    {
                        _page = await _pageFactory.GetPageAsync();
                    }
                }

                finally
                {
                    slim.Release();
                }
            }

            return _page;
        }

        // Locators ?

        // how obtain all - playwrite + browser context + page / then close/ 

        private void InitProperties()
        {
            // _loginButton = new Lazy<Button>(() => new Button());
        }
    }
}
