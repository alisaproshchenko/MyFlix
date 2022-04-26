using System;
using EPiServer;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Cms.ApiControllers
{
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPageRouteHelper _routeHelper;

        public LikesController(IContentLoader contentLoader, IPageRouteHelper routeHelper)
        {
            _contentLoader = contentLoader;
            _routeHelper = routeHelper;
        }
        public IActionResult IncrementLike(Guid contentGuid, string language)
        {
            
            if(!ModelState.IsValid) return BadRequest();

            return Ok();
        }
    }
}
