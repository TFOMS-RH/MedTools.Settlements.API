using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class MedicationDbEntityConfiguration : IEntityTypeConfiguration<MedicationDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicationDbEntity> builder)
    {
        builder.ToTable("dbo.lek_pr").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.OncologyServiceUid)
            .HasColumnName("onk_usl_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.DrugIdentifier)
            .HasColumnName("regnum")
            .HasMaxLength(40)
            .IsUnicode(true)
            .IsRequired();

        builder.Property(prop => prop.DrugExtendedIdentifier)
            .HasColumnName("regnum_dop")
            .HasMaxLength(45)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.TherapyRegimenCode)
            .HasColumnName("code_sh")
            .HasMaxLength(10)
            .IsUnicode(true)
            .IsRequired(false);

        builder
            .HasOne(medication => medication.OncologyService)
            .WithMany(oncologyService => oncologyService.Medications)
            .HasForeignKey(medication => medication.OncologyServiceUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}