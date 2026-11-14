using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionInjectionConfiguration : IEntityTypeConfiguration<ProjectionInjection>
{
    public void Configure(EntityTypeBuilder<ProjectionInjection> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InjectionUid).HasColumnName("uid");
        builder.Property(prop => prop.AdministrationDate).HasColumnName("date_inj");
        builder.Property(prop => prop.AdministeredQuantity).HasColumnName("kv_inj").IsRequired(false);
        builder.Property(prop => prop.ConsumedQuantity).HasColumnName("kiz_inj").IsRequired(false);
        builder.Property(prop => prop.UnitCost).HasColumnName("s_inj").IsRequired(false);
        builder.Property(prop => prop.AdministeredCost).HasColumnName("sv_inj").IsRequired(false);
        builder.Property(prop => prop.ConsumedCost).HasColumnName("siz_inj").IsRequired(false);
        builder.Property(prop => prop.IsReductionApplied).HasColumnName("red_inj").IsRequired(false);
    }
}
