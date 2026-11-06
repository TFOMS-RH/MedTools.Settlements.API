using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class InjectionDateDbEntityConfiguration : IEntityTypeConfiguration<InjectionDateDbEntity>
{
    public void Configure(EntityTypeBuilder<InjectionDateDbEntity> builder)
    {
        builder.ToTable("date_inj").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicationUid).HasColumnName("lek_pr_uid");

        builder.Property(prop => prop.InjectionDate).HasColumnName("date_inj");

        builder
            .HasOne(injectionDate => injectionDate.Medication)
            .WithMany(medication => medication.InjectionDates)
            .HasForeignKey(injectionDate => injectionDate.MedicationUid);
    }
}
