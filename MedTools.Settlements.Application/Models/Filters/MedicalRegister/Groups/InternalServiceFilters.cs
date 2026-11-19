namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record InternalServiceFilters(
    string CompletedCaseUid,
    string MedicalCaseUid,
    string PatientUid,
    string InvoiceUid,
    string InvoiceNumber,
    string InvoiceBillingMonth,
    string InvoiceBillingYear);