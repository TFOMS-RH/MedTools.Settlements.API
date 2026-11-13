using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionClassificationCriterionConfiguration : IEntityTypeConfiguration<ProjectionClassificationCriterion>
{
    public void Configure(EntityTypeBuilder<ProjectionClassificationCriterion> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ClassificationCriterionUid).HasColumnName("uid");
        builder.Property(prop => prop.ClassificationCriterion).HasColumnName("crit");
    }
}
