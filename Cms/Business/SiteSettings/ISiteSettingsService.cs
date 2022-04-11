using Cms.Business.MarkerInterfaces;
using EPiServer.Core;

namespace Cms.Business.SiteSettings
{
    public interface ISiteSettingsService
    {
        T GetSetting<T>(IContent currentContent) where T : class, ISettingsBlock, new();
        T GetSettingRecursive<T>(IContent currentContent) where T : class, ISettingsBlock, new();
    }
}
