namespace TinyUrl.Identity.External.Persistence.Common.Models.Configuration;

public class DatabaseConfiguration
{
    public enum DatabaseProvider
    {
        InMemory,
        Sqlite,
        Postgres
    }
    
    public DatabaseProvider Provider { get; set; }
    public string ConnectionString { get; set; } = string.Empty;
}