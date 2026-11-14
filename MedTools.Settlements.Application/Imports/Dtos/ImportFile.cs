namespace MedTools.Settlements.Application.Imports.Dtos;

public sealed record ImportFile(
    string Filename,
    long Length,
    Stream Content);
