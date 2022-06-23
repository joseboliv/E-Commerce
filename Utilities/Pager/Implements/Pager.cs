namespace Utilities.Pager
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of items type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pager<T> : IPager<T>
    {
        /// <summary>
        /// Gets or sets the quantity of records displayed per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the quantity total of records available.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the quantity total of pages available.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets collection of items paged <typeparamref name="T"/>
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}