using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Headings;

public sealed class MedicalRegistryHeadingDbEntityConfiguration : IEntityTypeConfiguration<MedicalRegistryHeadingDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRegistryHeadingDbEntity> builder)
    {
        builder.ToTable("dbo.zglv").HasKey(entity => entity.MedicalRegistryUid);

        builder.Property(prop => prop.MedicalRegistryUid)
            .HasColumnName("zl_list_uid")
            .HasColumnType("int");

        builder.Property(prop => prop.Version)
            .HasColumnName("version")
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.Date)
            .HasColumnName("data")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.Filename)
            .HasColumnName("filename")
            .HasMaxLength(26)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.TotalRecordCount)
            .HasColumnName("sd_z")
            .HasColumnType("int")
            .IsRequired(false);

        builder
            .HasOne(medicalRegistryHeading => medicalRegistryHeading.MedicalRegistry)
            .WithOne(medicalRegistry => medicalRegistry.MedicalRegistryHeading)
            .HasForeignKey<MedicalRegistryHeadingDbEntity>(medicalRegistryHeading => medicalRegistryHeading.MedicalRegistryUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}