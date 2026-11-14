using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;


namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ClassificationCriterionDbEntityConfiguration : IEntityTypeConfiguration<ClassificationCriterionDbEntity>
{
    public void Configure(EntityTypeBuilder<ClassificationCriterionDbEntity> builder)
    {
        builder.ToTable("crit").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.ClinicalGroupUid)
            .HasColumnName("ksg_kpg_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ClassificationCriterionName)
            .HasColumnName("crit")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(classificationCriterion => classificationCriterion.ClinicalGroup)
            .WithMany(clinicalGroup => clinicalGroup.ClassificationCriteria)
            .HasForeignKey(classificationCriterion => classificationCriterion.ClinicalGroupUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
