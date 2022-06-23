namespace Utilities.DataTable
{
    using System;
    using System.Linq;
    using Extensions;

    public class Order
    {
        public int Column { get; set; }

        public string Dir { get; set; }
        
        private bool OrderAscending => string.Compare("Asc", Dir, StringComparison.OrdinalIgnoreCase) == 0;

        public static IQueryable<T> ApplyOrderBy<T>(IQueryable<T> source, IDataTableParameters parameters)
        {
            if (parameters.Order != null)
            {
                var order = parameters.Order.FirstOrDefault();
                var columnOrder = parameters.Columns[order.Column];
                return source.OrderBy(columnOrder.Name, order.OrderAscending);
            }

            return source;
        }
    }
}