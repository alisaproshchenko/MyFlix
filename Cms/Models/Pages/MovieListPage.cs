using System.ComponentModel.DataAnnotations;
using Cms.Business.MarkerInterfaces;
using Cms.Models.Blocks;
using Cms.Models.Medias;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Cms.Models.Pages
{
    [ContentType(
        GroupName = "Basic pages",
        Order = 1,
        DisplayName = "Movie list page",
        GUID = "c269756a-499e-44df-bf5d-b858df270064",
        Description = "A movie list page")]
    public class MovieListPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Title for the list",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual XhtmlString Title { get; set; }
    }
}
