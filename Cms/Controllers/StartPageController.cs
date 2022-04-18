using System.Linq;
using Cms.Models.Pages;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        private readonly IPageRouteHelper _routeHelper;
        public StartPageController(IPageRouteHelper routeHelper)
        {
            _routeHelper = routeHelper;
        }
        [HttpGet]
        public IActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }
        [HttpPost]
        public IActionResult SearchMovie(string query)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var currentPage = _routeHelper.Content;

            var searchPage = loader.GetChildren<SearchResultsPage>(currentPage.ContentLink).FirstOrDefault();
            if (searchPage is null)
                return View("Index");

            return new RedirectResult(searchPage.LinkURL + $"index?query={query}");
        }
    }
}
