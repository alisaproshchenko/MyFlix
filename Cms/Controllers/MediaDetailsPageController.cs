using System;
using Cms.Models.Pages;
using Cms.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class MediaDetailsPageController : PageController<MovieDetailsPage>
    {
        public IActionResult Index(MovieDetailsPage currentPage)
        {
            var model = new MovieDetailsViewModel()
            {
                CurrentPage = currentPage,
                LikesIncrementEndpoint =
                    new Uri($"/api/likes/increment/{currentPage.ContentGuid}/{currentPage.Language}", UriKind.Relative)
            };
            return View(model);
        }
    }
}
