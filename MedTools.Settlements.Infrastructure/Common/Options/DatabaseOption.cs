namespace MedTools.Settlements.Infrastructure.Common.Options;

public sealed class DatabaseOption
{
    public const string SectionName = "Database";

    public DatabaseDetails MTR { get; set; } = new();
    public DatabaseDetails SMODB18 { get; set; } = new();
    public DatabaseDetails INOGOROD18 { get; set; } = new();
}

public sealed class DatabaseDetails
{
    public string ConnectionString { get; set; } = string.Empty;
    public int Timeout { get; set; }
}
