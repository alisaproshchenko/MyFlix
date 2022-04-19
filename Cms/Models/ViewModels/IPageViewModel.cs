using EPiServer.Core;

namespace Cms.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : PageData
    {
        T CurrentPage { get; }
        IContent Section { get; set; }
    }
}
