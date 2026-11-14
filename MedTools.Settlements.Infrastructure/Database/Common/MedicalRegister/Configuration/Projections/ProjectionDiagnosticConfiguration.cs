using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionDiagnosticConfiguration : IEntityTypeConfiguration<ProjectionDiagnostic>
{
    public void Configure(EntityTypeBuilder<ProjectionDiagnostic> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.DiagnosticsUid).HasColumnName("uid");
        builder.Property(prop => prop.SpecimenCollectionDate).HasColumnName("diag_date").IsRequired(false);
        builder.Property(prop => prop.DiagnosticTypeCode).HasColumnName("diag_tip").IsRequired(false);
        builder.Property(prop => prop.DiagnosticTypeName).HasColumnName("diag_tip_name").IsRequired(false);
        builder.Property(prop => prop.DiagnosticCode).HasColumnName("diag_code").IsRequired(false);
        builder.Property(prop => prop.DiagnosticName).HasColumnName("diag_code_name").IsRequired(false);
        builder.Property(prop => prop.DiagnosticResultCode).HasColumnName("diag_rslt").IsRequired(false);
        builder.Property(prop => prop.DiagnosticResultName).HasColumnName("diag_rslt_name").IsRequired(false);
        builder.Property(prop => prop.IsResultReceived).HasColumnName("rec_rslt").IsRequired(false);
    }
}
