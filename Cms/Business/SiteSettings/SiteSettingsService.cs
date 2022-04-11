using System.Linq;
using Cms.Business.MarkerInterfaces;
using Cms.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace Cms.Business.SiteSettings
{
    public class SiteSettingsService : ISiteSettingsService
    {
        private readonly ISiteDefinitionResolver _definitionResolver;
        private readonly IContentLoader _contentLoader;
        public SiteSettingsService(ISiteDefinitionResolver definitionResolver, IContentLoader contentLoader)
        {
            _definitionResolver = definitionResolver;
            _contentLoader = contentLoader;
        }
        public T GetSettingRecursive<T>(IContent currentContent) where T : class, ISettingsBlock, new()
        {
            T setting = null;
            var currentContentLink = currentContent.ContentLink;
            var currentPage = _contentLoader.Get<IContent>(currentContentLink);
            if (currentPage is not StartPage)
            {
                var parentPage = _contentLoader.GetAncestors(currentContentLink).FirstOrDefault();
                setting = GetSettingRecursive<T>(parentPage);
            }

            if (setting is not null)
                return setting;

            var startPage = (StartPage)currentPage;

            if(startPage.SiteSettings == null)
                return CreateDefaultInstance<T>();

            setting = startPage.SiteSettings.FilteredItems.Select(item =>
            {
                _contentLoader.TryGet(item.ContentLink, out T content);
                return content;
            }).SingleOrDefault(x => x != null);
            return setting;
        }
        public T GetSetting<T>(IContent currentContent) where T : class, ISettingsBlock, new()
        {
            T setting = null;
            var startContentLink = _definitionResolver.GetByContent(currentContent.ContentLink, true)?.StartPage;

            if (ContentReference.IsNullOrEmpty(startContentLink)) return CreateDefaultInstance<T>();

            var loaderOptions = new LoaderOptions();
            if (currentContent is ILocalizable localizableContent)
            {
                loaderOptions.Add(LanguageLoaderOption.Fallback(localizableContent.Language));
            }

            _contentLoader.TryGet(startContentLink, loaderOptions, out StartPage startPage);
            if (startPage != null && startPage.SiteSettings != null)
            {
                setting = startPage.SiteSettings.FilteredItems.Select(item =>
                {
                    _contentLoader.TryGet(item.ContentLink, out T content);
                    return content;
                }).SingleOrDefault(x => x != null);
            }

            return setting ?? CreateDefaultInstance<T>();
        }

        private T CreateDefaultInstance<T>() where T : class, ISettingsBlock, new()
        {
            var setting = new T();

            var propertyInfos = setting.GetOriginalType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var propType = propertyInfo.PropertyType;
                if (propType == typeof(LinkItemCollection))
                {
                    propertyInfo.SetValue(setting, new LinkItemCollection());
                }
                else if (propType == typeof(ContentArea))
                {
                    propertyInfo.SetValue(setting, new ContentArea());
                }
            }

            return setting;
        }
    }
}
