using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;


namespace Cms.Models.Medias
{
    [ContentType(
        DisplayName = "Image", 
        GUID = "875b3b51-e0a7-412c-8f56-44f59c184440", 
        Description = "Used for images of different file formats.",
        GroupName = "Media")]
    [MediaDescriptor(ExtensionString = "gif,jpg,jpeg,jfif,pjpeg,pjp,png,svg,webp")]
    public class ImageMedia : ImageData
    {
        
    }
}
