namespace Portal.Automation.Web.Domain.Pages;

public interface ILoginPage : IPage
{
    public Task<ILoginPage> TypeUsernameAsync(string userName);
    public Task<ILoginPage> TypePasswordAsync(string password);
    public Task<IHomePage> ClickLoginButtonAsync();
}
