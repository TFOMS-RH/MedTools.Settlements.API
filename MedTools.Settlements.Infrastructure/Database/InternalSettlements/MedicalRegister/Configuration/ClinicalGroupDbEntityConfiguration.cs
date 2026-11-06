using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class ClinicalGroupDbEntityConfiguration : IEntityTypeConfiguration<ClinicalGroupDbEntity>
{
    public void Configure(EntityTypeBuilder<ClinicalGroupDbEntity> builder)
    {
        builder.ToTable("ksg_kpg").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd() ;
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.ClinicalStatisticGroupNumber).HasColumnName("n_ksg");
        builder.Property(prop => prop.ClinicalStatisticGroupModelVersion).HasColumnName("ver_ksg");
        builder.Property(prop => prop.IsCsgSubgroupUsed).HasColumnName("ksg_pg");
        builder.Property(prop => prop.ClinicalProfileGroupNumber).HasColumnName("n_kpg").IsRequired(false);
        builder.Property(prop => prop.CostCoefficient).HasColumnName("koef_z");
        builder.Property(prop => prop.ManagementCoefficient).HasColumnName("koef_up");
        builder.Property(prop => prop.BaseRate).HasColumnName("bztsz");
        builder.Property(prop => prop.DifferentiationCoefficient).HasColumnName("koef_d");
        builder.Property(prop => prop.LevelCoefficient).HasColumnName("koef_u");
        builder.Property(prop => prop.AdditionalCriterionFirst).HasColumnName("dkk1").IsRequired(false);
        builder.Property(prop => prop.AdditionalCriterionSecond).HasColumnName("dkk2").IsRequired(false);
        builder.Property(prop => prop.IsClspUsed).HasColumnName("sl_k");
        builder.Property(prop => prop.ComplexityCoefficient).HasColumnName("it_sl").IsRequired(false);
        builder.Property(prop => prop.CalculatedClinicalStatisticalGroupNumber).HasColumnName("ksg").IsRequired(false);
        builder.Property(prop => prop.WageTargetCoefficient).HasColumnName("k_zp").IsRequired(false);
        builder.Property(prop => prop.InterruptedCasePaymentReason).HasColumnName("pr_pr").IsRequired(false);
        builder.Property(prop => prop.InterruptedCasePaymentShare).HasColumnName("koef_pr").IsRequired(false);

        builder
            .HasOne(clinicalGroup => clinicalGroup.MedicalCase)
            .WithOne(medicalCase => medicalCase.ClinicalGroup)
            .HasForeignKey<ClinicalGroupDbEntity>(clinicalGroup => clinicalGroup.MedicalCaseUid);
    }
}
