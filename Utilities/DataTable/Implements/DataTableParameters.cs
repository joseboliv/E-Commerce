namespace Utilities.DataTable
{
    using ExpressionBuilder;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Represent a model for gets data paged.
    /// </summary>
    public class DataTableParameters : IDataTableParameters
    {
        private int length = 10;

        /// <summary>
        /// Gets or sets the number of elements to skip before returning the remaining elements.
        /// </summary>
        /// <example>0</example>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets the number of elements to return.
        /// </summary>
        /// <example>10</example>
        public int Length
        {
            get => length; set
            {
                if (value <= 0)
                    length = int.MaxValue;
                else
                    length = value;
            }
        }

        public Search Search { get; set; }

        public List<Column> Columns { get; set; }

        public List<CustomSearch> CustomSearches { get; set; }

        public List<Order> Order { get; set; }

        public ValueTask<IEnumerable<QueryFilter>> BuildQueryFilter()
        {
            if (CustomSearches == null) return new ValueTask<IEnumerable<QueryFilter>>(Enumerable.Empty<QueryFilter>());

            var result = CustomSearches?.Select(x =>
            {
                if (x.Values != null)
                    return new QueryFilter(x.Name, x.Values, (Operator)x.Operator);

                return new QueryFilter(x.Name, x.Value, (Operator)x.Operator);
            });
            return new ValueTask<IEnumerable<QueryFilter>>(result);
        }
    }
}