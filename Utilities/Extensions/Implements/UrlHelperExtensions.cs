namespace Utilities.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using UrlHelper = Microsoft.AspNetCore.Mvc.UrlHelperExtensions;

    public class UrlHelperExtensions : IUrlHelperExtensions
    {
        public string Action(IUrlHelper urlHelper, string action, string controller)
        {
            return UrlHelper.Action(urlHelper, action, controller);
        }
    }
}
