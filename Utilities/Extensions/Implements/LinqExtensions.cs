namespace Utilities.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class LinqExtensions
    {
        private static string GetMethodName(bool asc) => asc ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending);

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName, bool asc = true)
        {
            Expression orderByProperty;
            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "x");
            if (propertyName.Contains("."))
            {
                var properties = propertyName.Split('.');
                orderByProperty = Expression.Property(parameter, typeof(TSource).GetProperty(properties[0]));
                var typeCompositeProperty = orderByProperty as MemberExpression;
                orderByProperty = Expression.Property(orderByProperty, typeCompositeProperty.Type.GetProperty(properties[1]));
            }
            else
                orderByProperty = Expression.Property(parameter, propertyName);

            LambdaExpression lambda = Expression.Lambda(orderByProperty, new[] { parameter });
            MethodInfo genericMethod = OrderByMethod(asc).MakeGenericMethod(new[] { typeof(TSource), orderByProperty.Type });

            object ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return (IQueryable<TSource>)ret;
        }

        private static MethodInfo OrderByMethod(bool asc)
        {
            return typeof(Queryable).GetMethods()
                    .Where(method => method.Name == GetMethodName(asc))
                    .Where(method => method.GetParameters().Length == 2)
                    .Single();
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            ParameterExpression param = expr1.Parameters[0];

            if (ReferenceEquals(param, expr2.Parameters[0]))
                return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), param);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, Expression.Invoke(expr2, param)), param);
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> range)
        {
            foreach (T t in range)
            {
                collection.Add(t);
            }
        }

        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> range)
        {
            foreach (T t in range)
            {
                collection.Remove(t);
            }
        }
    }
}
