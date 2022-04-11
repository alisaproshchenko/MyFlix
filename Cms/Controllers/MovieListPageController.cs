using Cms.Models.Pages;
using Cms.Models.ViewModels;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class MovieListPageController : PageController<MovieListPage>
    {
        public IActionResult Index(MovieListPage currentPage)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var movies = loader.GetChildren<MovieDetailsPage>(currentPage.ContentLink);

            var model = new MovieListViewModel(){CurrentContent = currentPage, MoviePages = movies};
            return View(model);
        }
    }
}
