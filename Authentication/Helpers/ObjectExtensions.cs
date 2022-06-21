namespace Authentication.Helpers
{
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;

    public static class ObjectExtensions
    {
        public static T ToConvertObjects<T>(this object obj)
        {
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var json = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static T ToConvertObjects<T>(this string json)
        {
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(json, options);
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
