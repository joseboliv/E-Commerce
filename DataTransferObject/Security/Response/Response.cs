namespace DataTransferObject.Security
{
    using System;
    using System.Text.Json.Serialization;

    public record Response
    {
        public Response(string Message, object Content, DateTime startTime)
        {
            this.Message = Message;
            this.Content = Content;
            ElapsedMilliseconds = (DateTime.Now - startTime).TotalMilliseconds;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Content { get; set; }
        public double ElapsedMilliseconds { get; set; }
    }
}
