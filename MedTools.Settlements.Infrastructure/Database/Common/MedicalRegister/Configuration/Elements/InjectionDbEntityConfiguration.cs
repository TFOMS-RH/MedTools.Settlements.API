using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class InjectionDbEntityConfiguration : IEntityTypeConfiguration<InjectionDbEntity>
{
    public void Configure(EntityTypeBuilder<InjectionDbEntity> builder)
    {
        builder.ToTable("inj").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicationUid)
            .HasColumnName("lek_pr_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.AdministrationDate)
            .HasColumnName("date_inj")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.AdministeredQuantity)
            .HasColumnName("kv_inj")
            .HasColumnType("decimal(8,3)")
            .IsRequired(false);

        builder.Property(prop => prop.ConsumedQuantity)
            .HasColumnName("kiz_inj")
            .HasColumnType("decimal(8,3)")
            .IsRequired(false);

        builder.Property(prop => prop.UnitCost)
            .HasColumnName("s_inj")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.AdministeredCost)
            .HasColumnName("sv_inj")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.ConsumedCost)
            .HasColumnName("siz_inj")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.IsReductionApplied)
            .HasColumnName("red_inj")
            .HasColumnType("bit")
            .IsRequired(false);

        builder
            .HasOne(injection => injection.Medication)
            .WithMany(medication => medication.Injections)
            .HasForeignKey(injection => injection.MedicationUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}