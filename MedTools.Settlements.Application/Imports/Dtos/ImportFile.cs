namespace MedTools.Settlements.Application.Imports.Dtos;

public sealed record ImportFile(
    string FileName,
    Stream Content);
