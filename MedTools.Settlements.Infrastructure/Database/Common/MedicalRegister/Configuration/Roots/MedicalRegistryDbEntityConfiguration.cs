using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Roots;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Roots;

public sealed class MedicalRegistryDbEntityConfiguration : IEntityTypeConfiguration<MedicalRegistryDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRegistryDbEntity> builder)
    {
        builder.ToTable("dbo.zl_list").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.UploadDate)
            .HasColumnName("uploaddate")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.Uploader)
            .HasColumnName("uploader")
            .HasMaxLength(64)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.Status)
            .HasColumnName("status")
            .HasColumnType("smallint")
            .IsRequired();
    }
}