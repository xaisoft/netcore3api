namespace CaseWebsites.Data
{
    public interface IWebsiteProvider
    {
        dynamic GetWebsiteById(string id);
    }
}