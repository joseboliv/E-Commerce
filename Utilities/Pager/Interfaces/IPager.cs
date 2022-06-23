namespace Utilities.Pager
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of items type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPager<T>
    {
        /// <summary>
        /// Gets or sets collection of items paged <typeparamref name="T"/>
        /// </summary>
        IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the quantity of records displayed per page.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the quantity total of records available.
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the quantity total of pages available.
        /// </summary>
        int TotalPages { get; set; }
    }
}