using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.References.Models;

namespace MedTools.Settlements.Infrastructure.Database.References.Configurations;

public sealed class DiseaseReferenceDbEntityConfiguration : IEntityTypeConfiguration<DiseaseReferenceDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseReferenceDbEntity> builder)
    {
        builder.ToTable("DIM_MKB").HasNoKey();

        builder.Property(prop => prop.Code).HasColumnName("DS").IsRequired(false);
        builder.Property(prop => prop.Name).HasColumnName("NAME_DS").IsRequired(false);
        builder.Property(prop => prop.ClassCode).HasColumnName("Class").IsRequired(false);
        builder.Property(prop => prop.SubClassCode).HasColumnName("SubClass").IsRequired(false);
    }
}
