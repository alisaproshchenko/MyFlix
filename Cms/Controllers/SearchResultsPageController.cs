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
using EPiServer.Find.Framework.Statistics;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class SearchResultsPageController : PageController<SearchResultsPage>
    {
        public IActionResult Index(SearchResultsPage page, string query, int pageCount = 1)
        {
            var model = new SearchViewModel(page, query);
            if (string.IsNullOrEmpty(query))
                return View(model);
            
            var filtered = SearchClient.Instance
                .UnifiedSearchFor(query)
                .Filter(x => x.MatchTypeHierarchy(typeof(MovieDetailsPage)))
                .Track();
            model.Results = filtered.GetResult();
            var loss = (model.Results.Count() % model.PageSize);
            model.PagesQuantity = (model.Results.Count() / model.PageSize);
            if (loss > 0)
                model.PagesQuantity++;

            return View(model);
        }
        public IActionResult NextPage(SearchViewModel model)
        {
            model.Page++;
            return View("Index", model);
        }
        public IActionResult PreviousPage(SearchViewModel model)
        {
            model.Page--;
            return View("Index", model);
        }
    }
}
