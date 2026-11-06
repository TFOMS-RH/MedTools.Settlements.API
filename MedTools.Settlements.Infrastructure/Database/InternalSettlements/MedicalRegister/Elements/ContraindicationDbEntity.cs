namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class ContraindicationDbEntity
{
    public int Uid { get; set; }
    public int OncologyCaseUid { get; set; }

    public byte ContraindicationCode { get; set; }
    public DateTime ContraindicationDate { get; set; }

    public OncologyCaseDbEntity OncologyCase{ get; set; } = null!;
}
