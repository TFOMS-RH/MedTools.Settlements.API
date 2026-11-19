using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.References.Models;

namespace MedTools.Settlements.Infrastructure.Database.References.Configurations;

public sealed class DiseaseStageReferenceDbEntityConfiguration : IEntityTypeConfiguration<DiseaseStageReferenceDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseStageReferenceDbEntity> builder)
    {
        builder.ToTable("N002").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.StageId).HasColumnName("Id_St");
        builder.Property(prop => prop.StageName).HasColumnName("Kod_St").IsRequired(false);
    }
}
