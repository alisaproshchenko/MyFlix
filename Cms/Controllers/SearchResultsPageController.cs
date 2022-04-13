using Cms.Models.Pages;
using Cms.Models.ViewModels;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class SearchResultsPageController : PageController<SearchResultsPage>
    {
        public IActionResult Index(SearchResultsPage page, string query)
        {
            var model = new SearchViewModel(page, query);
            if (string.IsNullOrEmpty(query))
                return View(model);

            var unifiedSearch = SearchClient.Instance.UnifiedSearchFor(query);
            model.Results = unifiedSearch.GetResult();
            return View(model);
        }
    }
}
