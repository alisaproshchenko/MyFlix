using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Cms.Models.Pages
{
    [ContentType(
        GroupName = "Basic pages",
        Order = 1,
        DisplayName = "Search results Page",
        GUID = "5a1a6b3f-1473-4965-a434-902bba0581fc",
        Description = "A search results page")]
    public class SearchResultsPage : PageData
    {
    }
}
