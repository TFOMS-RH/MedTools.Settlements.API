using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class MedicalDeviceDbEntityConfiguration : IEntityTypeConfiguration<MedicalDeviceDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalDeviceDbEntity> builder)
    {
        builder.ToTable("med_dev").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.ProvidedServiceUid).HasColumnName("usl_uid");

        builder.Property(prop => prop.ImplantationDate).HasColumnName("date_med");
        builder.Property(prop => prop.MedicalDeviceTypeCode).HasColumnName("code_meddev");
        builder.Property(prop => prop.SerialNumber).HasColumnName("number_ser");

        builder
            .HasOne(medicalDevice => medicalDevice.ProvidedService)
            .WithMany(providedService => providedService.MedicalDevices)
            .HasForeignKey(medicalDevice => medicalDevice.ProvidedServiceUid);
    }
}
