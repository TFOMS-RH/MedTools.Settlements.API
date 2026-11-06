using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class DiagnosticDbEntityConfiguration : IEntityTypeConfiguration<DiagnosticDbEntity>
{
    public void Configure(EntityTypeBuilder<DiagnosticDbEntity> builder)
    {
        builder.ToTable("b_diag").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.OncologyCaseUid).HasColumnName("onk_sl_uid");

        builder.Property(prop => prop.DiagnosticType).HasColumnName("diag_tip").IsRequired(false);
        builder.Property(prop => prop.DiagnosticCode).HasColumnName("diag_code").IsRequired(false);
        builder.Property(prop => prop.DiagnosticResultCode).HasColumnName("diag_rslt").IsRequired(false);
        builder.Property(prop => prop.SpecimenCollectionDate).HasColumnName("diag_date").IsRequired(false);
        builder.Property(prop => prop.IsResultReceived).HasColumnName("rec_rslt").IsRequired(false);

        builder
            .HasOne(diagnostic => diagnostic.OncologyCase)
            .WithMany(oncologyCase => oncologyCase.Diagnostics)
            .HasForeignKey(diagnostic => diagnostic.OncologyCaseUid);
    }
}
