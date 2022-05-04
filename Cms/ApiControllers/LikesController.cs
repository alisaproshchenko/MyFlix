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
            
            var writableCone = (MovieDetailsPage) movie.CreateWritableClone();

            writableCone.LikesCount++;

            _contentRepository.Save(writableCone, SaveAction.ForceCurrentVersion);

            return new ContentResult()
            {
                Content = JsonConvert.SerializeObject(new
                {
                    count = writableCone.LikesCount
                }),
                ContentType = "application/json"
            };
        }
        [HttpGet]
        [Route("test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult TestMethod()
        {
            return Ok();
        }

        [HttpGet]
        [Route("testvalues/{contentGuid:guid}/{language}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult TestValuesMethod(Guid contentGuid, string language)
        {
            var json = JsonConvert.SerializeObject(new
            {
                culture = language,
                guid = contentGuid
            });

            return new ContentResult()
            {
                Content = json,
                ContentType = "application/json"
            };
        }
    }
}
