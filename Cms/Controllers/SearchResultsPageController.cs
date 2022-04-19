using System;
using System.Collections.Generic;
using System.Linq;
using Cms.Models.Pages;
using Cms.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.ServiceLocation;
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
            var filtered = unifiedSearch.Filter(x => x.MatchTypeHierarchy(typeof(MovieDetailsPage)));
            model.Results = filtered.GetResult();
            return View(model);
        }
    }
}
