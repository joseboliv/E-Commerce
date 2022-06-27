namespace Infrastructure.Dapper
{
    public class DapperConnectionString
    {
        private DapperConnectionString() { }
        public static string ConnectionString { get; set; }
        public static string GetConnection() => ConnectionString;
        public static string SetConnection(string value)
        {
            if (ConnectionString == null)
            {
                ConnectionString = value;
            }
            return ConnectionString;
        }
    }
}
