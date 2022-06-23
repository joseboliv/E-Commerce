namespace Utilities.Extensions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            DisplayAttribute displayAttribute = value.GetType()
                                                 .GetMember(value.ToString())
                                                 .First()
                                                 .GetCustomAttribute<DisplayAttribute>();

            string displayName = displayAttribute?.GetName();

            return displayName ?? string.Empty;
        }
    }
}