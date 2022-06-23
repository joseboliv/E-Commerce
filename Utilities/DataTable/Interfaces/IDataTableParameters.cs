namespace Utilities.DataTable
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ExpressionBuilder;

    public interface IDataTableParameters
    {
        int Start { get; set; }
        int Length { get; set; }
        List<Column> Columns { get; set; }
        List<CustomSearch> CustomSearches { get; set; }
        List<Order> Order { get; set; }
        Search Search { get; set; }

        ValueTask<IEnumerable<QueryFilter>> BuildQueryFilter();
    }
}