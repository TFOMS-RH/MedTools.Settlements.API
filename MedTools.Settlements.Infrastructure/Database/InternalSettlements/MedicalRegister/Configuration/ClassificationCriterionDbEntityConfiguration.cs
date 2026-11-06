using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;


namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class ClassificationCriterionDbEntityConfiguration : IEntityTypeConfiguration<ClassificationCriterionDbEntity>
{
    public void Configure(EntityTypeBuilder<ClassificationCriterionDbEntity> builder)
    {
        builder.ToTable("crit").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.ClinicalGroupUid).HasColumnName("ksg_kpg_uid");

        builder.Property(prop => prop.ClassificationCriterionName).HasColumnName("crit").IsRequired(false);

        builder
            .HasOne(classificationCriterion => classificationCriterion.ClinicalGroup)
            .WithMany(clinicalGroup => clinicalGroup.ClassificationCriteria)
            .HasForeignKey(classificationCriterion => classificationCriterion.ClinicalGroupUid);
    }
}
