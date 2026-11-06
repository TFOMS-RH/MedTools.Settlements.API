using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Headings;

public sealed class PersonRegistryHeadingDbEntityConfiguration : IEntityTypeConfiguration<PersonRegistryHeadingDbEntity>
{
    public void Configure(EntityTypeBuilder<PersonRegistryHeadingDbEntity> builder)
    {
        builder.ToTable("dbo.p_zglv").HasKey(entity => entity.PersonRegistryUid);

        builder.Property(prop => prop.PersonRegistryUid)
            .HasColumnName("pers_list_uid")
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

        builder.Property(prop => prop.PersonRegistryFilename)
            .HasColumnName("filename")
            .HasMaxLength(128)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.MedicalRegistryFilename)
            .HasColumnName("filename1")
            .HasMaxLength(128)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(personRegistryHeading => personRegistryHeading.PersonRegistry)
            .WithOne(personRegistry => personRegistry.PersonRegistryHeading)
            .HasForeignKey<PersonRegistryHeadingDbEntity>(personRegistryHeading => personRegistryHeading.PersonRegistryUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}