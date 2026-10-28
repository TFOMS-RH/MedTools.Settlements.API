namespace MedTools.Settlements.Infrastructure.Common.Options;

public sealed class DatabaseOption
{
    public const string SectionName = "Database";

    public DatabaseDetails MTR = null!;
}

public sealed class DatabaseDetails
{
    public string ConnectionString { get; set; } = string.Empty;
    public int Timeout { get; set; }
}
