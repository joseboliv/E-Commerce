namespace Utilities.ExpressionBuilder
{
    using System.Collections.Generic;

    public class OperatorRelations
    {
        public string Type { get; set; }

        public ICollection<Operator> Operators { get; set; }
    }
}
