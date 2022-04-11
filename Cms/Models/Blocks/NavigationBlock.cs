using System.ComponentModel.DataAnnotations;
using Cms.Business.MarkerInterfaces;
using Cms.Models.Medias;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace Cms.Models.Blocks
{
    [ContentType(DisplayName = "Navigation Block Settings",
        GUID = "7ac2ab80-18e4-4205-a73a-4bc068210732",
        Description = "Header with links")]
    public class NavigationBlock : BlockData, ISettingsBlock
    {
        [Display(
            Name = "Logo",
            Order = 100)]
        [AllowedTypes(typeof(ImageMedia))]
        [UIHint(UIHint.Image)]
        public virtual ContentReference LogoImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Navigation links",
            Description = "",
            Order = 300)]
        public virtual LinkItemCollection Links { get; set; }
    }
}
