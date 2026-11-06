using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;


namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Headings;

public sealed class PersonRegistryHeadingDbEntityConfiguration : IEntityTypeConfiguration<PersonRegistryHeadingDbEntity>
{
    public void Configure(EntityTypeBuilder<PersonRegistryHeadingDbEntity> builder)
    {
        builder.ToTable("p_zglv").HasKey(entity => entity.PersonRegistryUid);

        builder.Property(prop => prop.PersonRegistryUid).HasColumnName("pers_list_uid");

        builder.Property(prop => prop.Version).HasColumnName("version").IsRequired(false);
        builder.Property(prop => prop.Date).HasColumnName("data").IsRequired(false);
        builder.Property(prop => prop.PersonRegistryFilename).HasColumnName("filename").IsRequired(false);
        builder.Property(prop => prop.MedicalRegistryFilename).HasColumnName("filename1").IsRequired(false);

        builder
            .HasOne(personRegistryHeading => personRegistryHeading.PersonRegistry)
            .WithOne(personRegistry => personRegistry.PersonRegistryHeading)
            .HasForeignKey<PersonRegistryHeadingDbEntity>(personRegistryHeading => personRegistryHeading.PersonRegistryUid);
    }
}
