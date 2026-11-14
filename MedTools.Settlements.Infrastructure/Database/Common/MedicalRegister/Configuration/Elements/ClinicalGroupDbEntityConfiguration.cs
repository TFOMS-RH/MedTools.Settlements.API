using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ClinicalGroupDbEntityConfiguration : IEntityTypeConfiguration<ClinicalGroupDbEntity>
{
    public void Configure(EntityTypeBuilder<ClinicalGroupDbEntity> builder)
    {
        builder.ToTable("ksg_kpg").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnType("int")
            .HasColumnName("sluch_uid")
            .IsRequired();

        builder.Property(prop => prop.ClinicalStatisticGroupNumber)
            .HasColumnName("n_ksg")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.ClinicalStatisticGroupModelVersion)
            .HasColumnName("ver_ksg")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ClinicalProfileGroupNumber)
            .HasColumnName("n_kpg")
            .HasMaxLength(4)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.AdditionalCriterionFirst)
            .HasColumnName("dkk1")
            .HasMaxLength(15)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.AdditionalCriterionSecond)
            .HasColumnName("dkk2")
            .HasMaxLength(15)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.CalculatedClinicalStatisticalGroupNumber)
            .HasColumnName("ksg")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InterruptedCasePaymentReason)
            .HasColumnName("pr_pr")
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.IsCsgSubgroupUsed)
            .HasColumnName("ksg_pg")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.IsClspUsed)
            .HasColumnName("sl_k")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.CostCoefficient)
            .HasColumnName("koef_z")
            .HasColumnType("real")
            .IsRequired();

        builder.Property(prop => prop.ManagementCoefficient)
            .HasColumnName("koef_up")
            .HasColumnType("real")
            .IsRequired();

        builder.Property(prop => prop.DifferentiationCoefficient)
            .HasColumnName("koef_d")
            .HasColumnType("real")
            .IsRequired();

        builder.Property(prop => prop.LevelCoefficient)
            .HasColumnName("koef_u")
            .HasColumnType("real")
            .IsRequired();

        builder.Property(prop => prop.ComplexityCoefficient)
            .HasColumnName("it_sl")
            .HasColumnType("real")
            .IsRequired(false);

        builder.Property(prop => prop.BaseRate)
            .HasColumnName("bztsz")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(prop => prop.WageTargetCoefficient)
            .HasColumnName("k_zp")
            .HasColumnType("decimal(8,5)")
            .IsRequired(false);

        builder.Property(prop => prop.InterruptedCasePaymentShare)
            .HasColumnName("koef_pr")
            .HasColumnType("decimal(6,5)")
            .IsRequired(false);

        builder
            .HasOne(clinicalGroup => clinicalGroup.MedicalCase)
            .WithOne(medicalCase => medicalCase.ClinicalGroup)
            .HasForeignKey<ClinicalGroupDbEntity>(clinicalGroup => clinicalGroup.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}