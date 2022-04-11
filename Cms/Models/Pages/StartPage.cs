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
        DisplayName = "Start Page",
        GUID = "49985d9f-59c0-44ff-8058-b174edd57aac",
        Description = "A start page")]
    public class StartPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Site Navigation Settings",
            Order = 10,
            GroupName = SystemTabNames.Settings)]
        [AllowedTypes(typeof(NavigationBlock))]
        public virtual ContentArea SiteSettings { get; set; }

        [CultureSpecific]
        [Display(
               Name = "Title for start page",
               Description = "",
               GroupName = SystemTabNames.Content,
               Order = 100)]
        public virtual XhtmlString Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Subtitle for start page",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 120)]
        public virtual string Subtitle { get; set; }

        [AllowedTypes(typeof(ImageMedia))]
        [UIHint(UIHint.Image)]
        public virtual ContentReference HeroImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Title for start page cross-platform site feature",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string CrossPlatformFeatureTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description for start page cross-platform site feature",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string CrossPlatformFeatureDescription { get; set; }

        [AllowedTypes(typeof(ImageMedia))]
        [UIHint(UIHint.Image)]
        public virtual ContentReference CrossPlatformFeatureImage { get; set; }
    }
}
