namespace Utilities.ExpressionBuilder
{
    using System;
    using System.Collections.Generic;

    public class QueryFilter : IEquatable<QueryFilter>
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public HashSet<string> Values { get; set; }
        public Operator Operator { get; set; }

        public QueryFilter(string propertyName, string value, Operator operatorValue)
            : this (propertyName, value, new HashSet<string>(), operatorValue)
        {
        }

        public QueryFilter(string propertyName, HashSet<string> values, Operator operatorValue)
            : this (propertyName, string.Empty, values, operatorValue)
        {
        }

        private QueryFilter(string propertyName, string value, HashSet<string> values, Operator operatorValue)
        {
            PropertyName = propertyName;
            Value = value;
            Values = values;
            Operator = operatorValue;
        }

        public override bool Equals(object obj) => Equals(obj as QueryFilter);

        public bool Equals(QueryFilter other)
        {
            if (other is QueryFilter filter)
            {
                return 
                    Equals(PropertyName, filter.PropertyName) &&
                    Equals(Value, filter.Value) &&
                    Values.SetEquals(filter.Values) &&
                    Equals(Operator, filter.Operator);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 1070525618;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PropertyName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + Operator.GetHashCode();
            return hashCode;
        }
    }
}
