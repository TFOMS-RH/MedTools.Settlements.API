using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionMedicalOrganizationConfiguration : IEntityTypeConfiguration<ProjectionMedicalOrganization>
{
    public void Configure(EntityTypeBuilder<ProjectionMedicalOrganization> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Code).HasColumnName("organization_code");
        builder.Property(prop => prop.Name).HasColumnName("organization_name");
    }
}
