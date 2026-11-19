using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Proxy;

public sealed class CompletedCasePersonJoin
{
    public required CompletedCaseDbEntity CompletedCase { get; init; }
    public required PersonDbEntity Person { get; init; }
}
