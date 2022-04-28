using System;
using Cms.Models.Pages;

namespace Cms.Models.ViewModels
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsPage CurrentPage { get; set; }
        public Uri LikesIncrementEndpoint { get; set; }
    }
}
