using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class InjectionDbEntityConfiguration : IEntityTypeConfiguration<InjectionDbEntity>
{
    public void Configure(EntityTypeBuilder<InjectionDbEntity> builder)
    {
        builder.ToTable("inj").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicationUid).HasColumnName("lek_pr_uid");

        builder.Property(prop => prop.AdministrationDate).HasColumnName("date_inj");
        builder.Property(prop => prop.AdministeredQuantity).HasColumnName("kv_inj").IsRequired(false);
        builder.Property(prop => prop.ConsumedQuantity).HasColumnName("kiz_inj").IsRequired(false);
        builder.Property(prop => prop.UnitCost).HasColumnName("s_inj").IsRequired(false);
        builder.Property(prop => prop.AdministeredCost).HasColumnName("sv_inj").IsRequired(false);
        builder.Property(prop => prop.ConsumedCost).HasColumnName("siz_inj").IsRequired(false);
        builder.Property(prop => prop.IsReductionApplied).HasColumnName("red_inj").IsRequired(false);

        builder
            .HasOne(injection => injection.Medication)
            .WithMany(medication => medication.Injections)
            .HasForeignKey(injection => injection.MedicationUid);
    }
}