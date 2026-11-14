namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record DefectDto(
    int DefectUid,
    short? Code,
    string Comment);
