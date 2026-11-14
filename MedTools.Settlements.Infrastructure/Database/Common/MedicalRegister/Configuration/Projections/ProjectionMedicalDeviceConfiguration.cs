using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionMedicalDeviceConfiguration : IEntityTypeConfiguration<ProjectionMedicalDevice>
{
    public void Configure(EntityTypeBuilder<ProjectionMedicalDevice> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalDeviceUid).HasColumnName("uid");
        builder.Property(prop => prop.ImplantationDate).HasColumnName("date_med");
        builder.Property(prop => prop.MedicalDeviceTypeCode).HasColumnName("code_meddev");
        builder.Property(prop => prop.SerialNumber).HasColumnName("number_ser");
    }
}
