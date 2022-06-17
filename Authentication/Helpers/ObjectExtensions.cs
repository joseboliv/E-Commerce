namespace Authentication.Helpers
{
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
    }
}
