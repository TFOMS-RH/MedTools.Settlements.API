using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class MedicalDeviceDbEntityConfiguration : IEntityTypeConfiguration<MedicalDeviceDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalDeviceDbEntity> builder)
    {
        builder.ToTable("med_dev").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.ProvidedServiceUid)
            .HasColumnName("usl_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ImplantationDate)
            .HasColumnName("date_med")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.MedicalDeviceTypeCode)
            .HasColumnName("code_meddev")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.SerialNumber)
            .HasColumnName("number_ser")
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired();

        builder
            .HasOne(medicalDevice => medicalDevice.ProvidedService)
            .WithMany(providedService => providedService.MedicalDevices)
            .HasForeignKey(medicalDevice => medicalDevice.ProvidedServiceUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}