namespace Utilities.ExpressionBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Utilities.Extensions;

    public class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> GetExpression<T>(IEnumerable<QueryFilter> filters)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression value = Expression.Constant(true);

            foreach (QueryFilter filter in filters)
                if (string.IsNullOrEmpty(filter.Value))
                    value = Expression.AndAlso(value, GetComplexExpression<T>(parameter, filter));
                else
                    value = Expression.AndAlso(value, GetSimpleExpression<T>(parameter, filter));

            return Expression.Lambda<Func<T, bool>>(value, parameter);
        }

        private static Expression GetSimpleExpression<T>(ParameterExpression parameter, QueryFilter queryFilter)
        {
            MemberExpression property = Expression.PropertyOrField(parameter, queryFilter.PropertyName);
            Expression searchValue = GetSearchValue(property.Type, queryFilter.Value);

            property = AppendValuePropertyOnBooleanType(property);

            switch (queryFilter.Operator)
            {
                case Operator.Equals:
                    return Expression.Equal(property, searchValue);
                case Operator.NotEqual:
                    return Expression.NotEqual(property, searchValue);
                case Operator.Contains:
                case Operator.StartsWith:
                case Operator.EndsWith:
                    {
                        searchValue = GetSearchValue(property.Type, queryFilter.Value.ToUpper());
                        MethodCallExpression expressionUpper = Expression.Call(property, nameof(string.ToUpper), null);
                        MethodCallExpression expressionUpperAndOperator = Expression.Call(expressionUpper, queryFilter.Operator.ToString(), null, searchValue);
                        return expressionUpperAndOperator;
                    }
                case Operator.GreaterThan:
                    return Expression.GreaterThan(property, searchValue);
                case Operator.GreaterOrEqualThan:
                    return Expression.GreaterThanOrEqual(property, searchValue);
                case Operator.LessThan:
                    return Expression.LessThan(property, searchValue);
                case Operator.LessOrEqualThan:
                    return Expression.LessThanOrEqual(property, searchValue);
                default:
                    throw new Exception($"The type {queryFilter.Operator} not is a type selector valid.");
            }
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static MemberExpression AppendValuePropertyOnBooleanType(MemberExpression property)
        {
            var type = property.Type;

            if (Nullable.GetUnderlyingType(type)?.Name != "Boolean")
                return property;

            return Expression.Property(property, "Value");
        }

        private static Expression GetComplexExpression<T>(ParameterExpression parameter, QueryFilter queryFilter)
        {
            //if (queryFilter.PropertyName.Contains("."))
            //{
            //    NewMethod<T>(parameter, queryFilter);
            //}

            MemberExpression value = Expression.PropertyOrField(parameter, queryFilter.PropertyName);

            MethodCallExpression valueString = Expression.Call(value, nameof(string.ToString), null);

            MethodInfo method = typeof(HashSet<string>)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Single(x => x.Name == nameof(Enumerable.Contains) && x.IsFinal && x.GetParameters().Length == 1);

            ConstantExpression listContains = Expression.Constant(queryFilter.Values);

            Expression body = Expression.Call(listContains, method, valueString);

            if (queryFilter.Operator == Operator.NotEqual)
                body = Expression.Not(body);

            return body;
        }

        private static Expression GetSearchValue(Type type, string searchValue)
        {
            Expression value = null;
            if (type == typeof(byte))
            {
                byte.TryParse(searchValue, out byte num);
                value = Expression.Constant(num);
            }
            else if (type == typeof(int))
            {
                int.TryParse(searchValue, out int num);
                value = Expression.Constant(num);
            }
            else if (type == typeof(long))
            {
                long.TryParse(searchValue, out long num);
                value = Expression.Constant(num);
            }
            else if (type == typeof(decimal))
            {
                decimal.TryParse(searchValue, out decimal num);
                value = Expression.Constant(num);
            }
            else if (type == typeof(string))
            {
                value = Expression.Constant(searchValue);
            }
            else if (type == typeof(DateTime))
            {
                DateTime.TryParse(searchValue, out DateTime date);
                value = Expression.Constant(date);
            }
            else if (type == typeof(DateTime?))
            {
                DateTime? date = NullableExtensions.TryParse(searchValue);
                value = Expression.Constant(date);
                value = Expression.Convert(value, type);
            }
            else if (type == typeof(bool) || type == typeof(bool?))
            {
                bool.TryParse(searchValue, out bool flag);
                value = Expression.Constant(flag);
            }

            return value;
        }
    }
}
