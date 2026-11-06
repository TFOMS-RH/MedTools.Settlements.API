using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class MedicalRegistryDbEntityConfiguration : IEntityTypeConfiguration<MedicalRegistryDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRegistryDbEntity> builder)
    {
        builder.ToTable("zl_list").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();

        builder.Property(prop => prop.UploadDate).HasColumnName("uploaddate").IsRequired(false);
        builder.Property(prop => prop.Uploader).HasColumnName("uploader").IsRequired(false);
        builder.Property(prop => prop.Status).HasColumnName("status");
    }
}
