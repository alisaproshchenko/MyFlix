using System.Collections.Generic;
using Cms.Models.Pages;

namespace Cms.Models.ViewModels
{
    public class MovieListViewModel
    {
        public MovieListPage CurrentContent { get; set; }
        public IEnumerable<MovieDetailsPage> MoviePages { get; set; }
    }
}
