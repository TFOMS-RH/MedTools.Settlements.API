using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionClinicalGroupConfiguration : IEntityTypeConfiguration<ProjectionClinicalGroup>
{
    public void Configure(EntityTypeBuilder<ProjectionClinicalGroup> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ClinicalGroupUid).HasColumnName("uid");
        builder.Property(prop => prop.ClinicalStatisticalGroupNumber).HasColumnName("n_ksg");
        builder.Property(prop => prop.CalculatedClinicalStatisticalGroupNumber).HasColumnName("ksg").IsRequired(false);
        builder.Property(prop => prop.ClinicalStatisticalGroupModelVersion).HasColumnName("ver_ksg");
        builder.Property(prop => prop.IsCsgSubgroupUsed).HasColumnName("ksg_pg");
        builder.Property(prop => prop.ClinicalProfileGroupNumber).HasColumnName("n_kpg").IsRequired(false);
        builder.Property(prop => prop.CostCoefficient).HasColumnName("koef_z");
        builder.Property(prop => prop.ManagementCoefficient).HasColumnName("koef_up");
        builder.Property(prop => prop.BaseRate).HasColumnName("bztsz");
        builder.Property(prop => prop.DifferentiationCoefficient).HasColumnName("koef_d");
        builder.Property(prop => prop.LevelCoefficient).HasColumnName("koef_u");
        builder.Property(prop => prop.WageTargetCoefficient).HasColumnName("k_zp").IsRequired(false);
        builder.Property(prop => prop.IsClspUsed).HasColumnName("sl_k");
        builder.Property(prop => prop.ComplexityCoefficient).HasColumnName("it_sl").IsRequired(false);
    }
}
