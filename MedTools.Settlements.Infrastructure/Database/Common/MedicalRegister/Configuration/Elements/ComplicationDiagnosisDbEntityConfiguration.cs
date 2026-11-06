using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ComplicationDiagnosisDbEntityConfiguration : IEntityTypeConfiguration<ComplicationDiagnosisDbEntity>
{
    public void Configure(EntityTypeBuilder<ComplicationDiagnosisDbEntity> builder)
    {
        builder.ToTable("ds3").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.DiagnosisName)
            .HasColumnName("ds3")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder
            .HasOne(complicationDiagnosis => complicationDiagnosis.MedicalCase)
            .WithMany(medicalCase => medicalCase.ComplicationDiagnoses)
            .HasForeignKey(complicationDiagnosis => complicationDiagnosis.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}