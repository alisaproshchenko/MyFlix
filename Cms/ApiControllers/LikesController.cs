using System;
using System.Globalization;
using Cms.Models.Pages;
using EPiServer;
using EPiServer.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cms.ApiControllers
{
    [ApiController]
    [Route("api/likes")]
    public class LikesApiController : ControllerBase
    {
        private readonly IContentRepository _contentRepository;

        public LikesApiController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("increment/{contentGuid:Guid}/{language}")]
        public IActionResult IncrementLike(Guid contentGuid, string language)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var culture = new CultureInfo(language);
            var movie = _contentRepository.Get<MovieDetailsPage>(contentGuid, culture);

            if (movie is null) return NotFound();

            movie.LikesCount++;

            _contentRepository.Save(movie, SaveAction.ForceCurrentVersion);

            return new ContentResult()
            {
                Content = JsonConvert.SerializeObject(new
                {
                    count = movie.LikesCount
                }),
                ContentType = "application/json"
            };
        }
    }
}
