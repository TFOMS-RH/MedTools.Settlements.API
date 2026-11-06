namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record InvoiceDto(
    int Uid,
    string Number,
    DateTime BillingDate,
    decimal Amount,
    int MedicalCasesCount,
    short Status);
