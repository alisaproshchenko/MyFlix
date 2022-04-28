using System;
using System.Globalization;
using Cms.Models.Pages;
using EPiServer;
using EPiServer.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Cms.ApiControllers
{
    [ApiController]
    [Route("api/likes")]
    public class LikesController : ControllerBase
    {
        private readonly IContentRepository _contentRepository;

        public LikesController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpPost]
        [Route("/increment/{contentGuid}/{language}")]
        public IActionResult IncrementLike(Guid contentGuid, string language)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var culture = new CultureInfo(language);
            var movie = _contentRepository.Get<MovieDetailsPage>(contentGuid, culture);

            if (movie is null) return NotFound();

            movie.LikesCount++;

            _contentRepository.Save(movie, SaveAction.ForceCurrentVersion);

            return Ok();
        }
    }
}
