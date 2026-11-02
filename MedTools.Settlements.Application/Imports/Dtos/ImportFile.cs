namespace MedTools.Settlements.Application.Imports.Dtos;

public sealed record ImportFile(
    string Filename,
    Stream Content);
