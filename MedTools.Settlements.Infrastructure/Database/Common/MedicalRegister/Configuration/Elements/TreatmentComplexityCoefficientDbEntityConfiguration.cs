using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class TreatmentComplexityCoefficientDbEntityConfiguration : IEntityTypeConfiguration<TreatmentComplexityCoefficientDbEntity>
{
    public void Configure(EntityTypeBuilder<TreatmentComplexityCoefficientDbEntity> builder)
    {
        builder.ToTable("dbo.sl_koef").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.ClinicalGroupUid)
            .HasColumnName("ksg_kpg_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ComplexityCoefficientNumber)
            .HasColumnName("idsl")
            .HasMaxLength(5)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.ComplexityCoefficientValue)
            .HasColumnName("z_sl")
            .HasColumnType("real")
            .IsRequired();

        builder
            .HasOne(treatmentComplexityCoefficient => treatmentComplexityCoefficient.ClinicalGroup)
            .WithMany(clinicalGroup => clinicalGroup.TreatmentComplexityCoefficients)
            .HasForeignKey(treatmentComplexityCoefficient => treatmentComplexityCoefficient.ClinicalGroupUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}