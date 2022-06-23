namespace Utilities.Pager
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides methods for return results paginated and convert source to other class.
    /// </summary>
    /// <typeparam name="TSourceType">The type of the elements of source.</typeparam>
    /// <typeparam name="TResultType">The final type value before convert.</typeparam>
    public class PagerBuilder<TSourceType, TResultType>
    {
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<TResultType> Items { get; private set; }
        private readonly JsonSerializerSettings jsonSerializerSettings =
            new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        private PagerBuilder(IQueryable<TSourceType> source, int pageSize, int skip)
        {
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            Items = ConvertTSourceTypeToTResultType(source, pageSize, skip);
        }

        private PagerBuilder(IQueryable<TSourceType> source, int pageSize, int skip, int totalCount)
        {
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            Items = ConvertTSourceTypeToTResultTypeWithOutPager(source);
        }

        public static IPager<TResultType> GetPager(IQueryable<TSourceType> source, int pageSize, int skip)
        {
            PagerBuilder<TSourceType, TResultType> instance = new PagerBuilder<TSourceType, TResultType>(source, pageSize, skip);
            return new Pager<TResultType>
            {
                PageSize = instance.PageSize,
                TotalCount = instance.TotalCount,
                TotalPages = instance.TotalPages,
                Items = instance.Items
            };
        }

        public static IPager<TResultType> GetPager(IQueryable<TSourceType> source, int pageSize, int skip, int numberElements)
        {
            PagerBuilder<TSourceType, TResultType> instance = new PagerBuilder<TSourceType, TResultType>(source, pageSize, skip, numberElements);
            return new Pager<TResultType>
            {
                PageSize = instance.PageSize,
                TotalCount = instance.TotalCount,
                TotalPages = instance.TotalPages,
                Items = instance.Items
            };
        }

        private IEnumerable<TResultType> ConvertTSourceTypeToTResultType(IQueryable<TSourceType> source, int pageSize, int skip)
        {
            var jsonString = JsonConvert.SerializeObject(source.Skip(skip).Take(pageSize).ToList(), Formatting.Indented, jsonSerializerSettings);
            return JsonConvert.DeserializeObject<IEnumerable<TResultType>>(jsonString);
        }

        private IEnumerable<TResultType> ConvertTSourceTypeToTResultTypeWithOutPager(IQueryable<TSourceType> source)
        {
            var jsonString = JsonConvert.SerializeObject(source.ToList(), Formatting.Indented, jsonSerializerSettings);
            return JsonConvert.DeserializeObject<IEnumerable<TResultType>>(jsonString);
        }
    }
}