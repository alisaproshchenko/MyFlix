using Cms.Models.Pages;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        [HttpGet]
        public IActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }
    }
}
