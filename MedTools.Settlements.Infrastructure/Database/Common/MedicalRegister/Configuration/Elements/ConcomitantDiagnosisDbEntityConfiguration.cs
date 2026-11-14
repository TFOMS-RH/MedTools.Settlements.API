using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ConcomitantDiagnosisDbEntityConfiguration : IEntityTypeConfiguration<ConcomitantDiagnosisDbEntity>
{
    public void Configure(EntityTypeBuilder<ConcomitantDiagnosisDbEntity> builder)
    {
        builder.ToTable("ds2").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.DiagnosisName)
            .HasColumnName("ds2")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder
            .HasOne(concomitantDiagnosis => concomitantDiagnosis.MedicalCase)
            .WithMany(medicalCase => medicalCase.ConcomitantDiagnoses)
            .HasForeignKey(concomitantDiagnosis => concomitantDiagnosis.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}