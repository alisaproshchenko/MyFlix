using Cms.Models.Pages;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class MediaDetailsPageController : PageController<MovieDetailsPage>
    {
        public IActionResult Index(MovieDetailsPage currentPage)
        {
            return View(currentPage);
        }
    }
}
