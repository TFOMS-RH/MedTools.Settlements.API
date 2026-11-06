namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class MedicalDeviceDbEntity
{
    public int Uid { get; set; }
    public int ProvidedServiceUid { get; set; }

    public DateTime ImplantationDate { get; set; }
    public int MedicalDeviceTypeCode { get; set; }
    public string SerialNumber { get; set; } = string.Empty;

    public ProvidedServiceDbEntity ProvidedService { get; set; } = null!;
}
