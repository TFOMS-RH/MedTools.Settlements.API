using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Headings;


namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class MedicalRegistryHeadingDbEntityConfiguration : IEntityTypeConfiguration<MedicalRegistryHeadingDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRegistryHeadingDbEntity> builder)
    {
        builder.ToTable("zglv").HasKey(entity => entity.MedicalRegistryUid);

        builder.Property(prop => prop.MedicalRegistryUid).HasColumnName("zl_list_uid");

        builder.Property(prop => prop.Version).HasColumnName("version").IsRequired(false);
        builder.Property(prop => prop.Date).HasColumnName("data").IsRequired(false);
        builder.Property(prop => prop.Filename).HasColumnName("filename").IsRequired(false);
        builder.Property(prop => prop.TotalRecordCount).HasColumnName("sd_z").IsRequired(false);

        builder
            .HasOne(medicalRegistryHeading => medicalRegistryHeading.MedicalRegistry)
            .WithOne(medicalRegistry => medicalRegistry.MedicalRegistryHeading)
            .HasForeignKey<MedicalRegistryHeadingDbEntity>(medicalRegistryHeading => medicalRegistryHeading.MedicalRegistryUid);
    }
}