namespace Utilities.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string FormatDateTime(DateTime? dateTime, StringExtensionsFormats enumFormat)
        {
            if (!dateTime.HasValue || dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            var stringFormat = EnumExtensions.GetDisplayName(enumFormat);

            return dateTime.Value.ToString(stringFormat);
        }

        public static bool NotEquals(this string @this, string @string) => !@this.Equals(@string);
    }
}