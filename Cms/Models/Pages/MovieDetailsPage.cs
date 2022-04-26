using System.ComponentModel.DataAnnotations;
using Cms.Business.MarkerInterfaces;
using Cms.Models.Blocks;
using Cms.Models.Medias;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.Web;

namespace Cms.Models.Pages
{
    [ContentType(
        GroupName = "Basic pages",
        Order = 1,
        DisplayName = "Movie details page",
        GUID = "2dced292-ec94-45f7-8ecc-6f683e7fa720",
        Description = "A media details page")]
    public class MovieDetailsPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Title for movie",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string MovieTitle { get; set; }


        [AllowedTypes(typeof(ImageMedia))]
        [UIHint(UIHint.Image)]
        [Display(
            Name = "Movie Poster",
            GroupName = SystemTabNames.Content,
            Order = 110
            )]
        public virtual ContentReference MoviePoster { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description for the movie",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 120)]
        public virtual XhtmlString MovieDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Director of the movie",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 150)]
        public virtual string MovieDirector { get; set; }

        [CultureSpecific]
        [Display(
            Name = "The year of release of the movie",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 160)]
        public virtual int MovieYear { get; set; }

        [CultureSpecific]
        [Display(
            Name = "The duration of the movie in minutes",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 170)]
        public virtual int DurationMinutes { get; set; }

        
    }
}
