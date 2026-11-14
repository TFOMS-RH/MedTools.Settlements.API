using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionInjectionDateConfiguration : IEntityTypeConfiguration<ProjectionInjectionDate>
{
    public void Configure(EntityTypeBuilder<ProjectionInjectionDate> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InjectionDateUid).HasColumnName("uid");
        builder.Property(prop => prop.AdministrationDate).HasColumnName("date_inj");
    }
}
