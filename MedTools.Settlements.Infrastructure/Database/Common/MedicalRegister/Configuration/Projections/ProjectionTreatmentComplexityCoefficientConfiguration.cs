using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionTreatmentComplexityCoefficientConfiguration : IEntityTypeConfiguration<ProjectionTreatmentComplexityCoefficient>
{
    public void Configure(EntityTypeBuilder<ProjectionTreatmentComplexityCoefficient> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.TreatmentComplexityCoefficientUid).HasColumnName("uid");
        builder.Property(prop => prop.ComplexityCoefficientNumber).HasColumnName("idsl").IsRequired(false);
        builder.Property(prop => prop.ComplexityCoefficientValue).HasColumnName("z_sl");
    }
}
