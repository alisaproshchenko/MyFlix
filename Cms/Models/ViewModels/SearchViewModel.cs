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

        public string SearchQuery { get; set; }
        public UnifiedSearchResults Results { get; set; }
    }
}
