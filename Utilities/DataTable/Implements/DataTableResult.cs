namespace Utilities.DataTable
{
    using Pager;
    using System.Collections.Generic;

    public class DataTableResult<T>
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<T> Data { get; set; }

        public DataTableResult(IPager<T> pager)
        {
            Data = pager.Items;
            RecordsTotal = pager.TotalCount;
            RecordsFiltered = pager.TotalCount;
        }
    }
}