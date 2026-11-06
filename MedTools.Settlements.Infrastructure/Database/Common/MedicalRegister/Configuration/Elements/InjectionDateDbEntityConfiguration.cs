using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class InjectionDateDbEntityConfiguration : IEntityTypeConfiguration<InjectionDateDbEntity>
{
    public void Configure(EntityTypeBuilder<InjectionDateDbEntity> builder)
    {
        builder.ToTable("dbo.date_inj").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicationUid)
            .HasColumnName("lek_pr_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.InjectionDate)
            .HasColumnName("date_inj")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder
            .HasOne(injectionDate => injectionDate.Medication)
            .WithMany(medication => medication.InjectionDates)
            .HasForeignKey(injectionDate => injectionDate.MedicationUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}