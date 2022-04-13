using EPiServer.Core;

namespace Cms.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public PageViewModel() { }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
        public T CurrentPage { get; private set; }
        public IContent Section { get; set; }
    }
}
