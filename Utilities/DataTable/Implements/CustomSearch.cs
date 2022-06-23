namespace Utilities.DataTable
{
    using System.Collections.Generic;

    public class CustomSearch
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public HashSet<string> Values { get; set; }
        public int Operator { get; set; }
    }
}