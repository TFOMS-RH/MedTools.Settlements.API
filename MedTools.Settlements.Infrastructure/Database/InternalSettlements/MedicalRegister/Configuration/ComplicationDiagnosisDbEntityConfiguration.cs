using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class ComplicationDiagnosisDbEntityConfiguration : IEntityTypeConfiguration<ComplicationDiagnosisDbEntity>
{
    public void Configure(EntityTypeBuilder<ComplicationDiagnosisDbEntity> builder)
    {
        builder.ToTable("ds3").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.DiagnosisName).HasColumnName("ds3");

        builder
            .HasOne(complicationDiagnosis => complicationDiagnosis.MedicalCase)
            .WithMany(medicalCase => medicalCase.ComplicationDiagnoses)
            .HasForeignKey(complicationDiagnosis => complicationDiagnosis.MedicalCaseUid);
    }
}
