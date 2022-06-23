namespace Utilities.Extensions
{
    using Newtonsoft.Json;
    using System;

    public static class DumpExtension
    {
        public static void Dump(this object obj)
        {
            string objectString = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            Console.WriteLine(objectString);
        }
    }
}
