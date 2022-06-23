namespace Utilities.Helpers
{
    using Newtonsoft.Json;
    using System.Linq;
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static T ToConvertObjects<T>(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T ToConvertObjects<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T Map<T>(this object objfrom, T objto)
        {
            PropertyInfo[] ToProperties = objto.GetType().GetProperties();
            PropertyInfo[] FromProperties = objfrom.GetType().GetProperties();

            ToProperties.ToList().ForEach(o =>
            {
                PropertyInfo fromp = FromProperties.FirstOrDefault(x => x.Name == o.Name && x.PropertyType == o.PropertyType);
                if (fromp != null)
                {
                    o.SetValue(objto, fromp.GetValue(objfrom));
                }
            });

            return objto;
        }
    }
}
