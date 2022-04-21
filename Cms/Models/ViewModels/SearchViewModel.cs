using Cms.Models.Pages;
using EPiServer.Find.UnifiedSearch;

namespace Cms.Models.ViewModels
{
    public class SearchViewModel : PageViewModel<SearchResultsPage>
    {
        public SearchViewModel(SearchResultsPage currentPage, string searchQuery) : base(currentPage)
        {
            SearchQuery = searchQuery;
        }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int PagesQuantity { get; set; }
        public string SearchQuery { get; set; }
        public UnifiedSearchResults Results { get; set; }
    }
}
