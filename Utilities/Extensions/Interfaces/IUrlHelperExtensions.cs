namespace Utilities.Extensions
{
    using Microsoft.AspNetCore.Mvc;

    public interface IUrlHelperExtensions
    {
        string Action(IUrlHelper urlHelper, string action, string controller);
    }
}