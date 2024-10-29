using Portal.Automation.Web.Domain.Pages;

namespace Portal.Automation.Web.Domain
{
    public interface IBrowser
    {
        Task<T> NavigateAsync<T>(string url)
            where T: IPage;
        Task CloseAsync();
    }
}
