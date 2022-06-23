namespace Utilities.Extensions
{
    using System;

    public static class NullableExtensions
    {
        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }
    }
}
