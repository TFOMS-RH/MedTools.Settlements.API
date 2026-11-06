using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class PrescriptionDbEntityConfiguration : IEntityTypeConfiguration<PrescriptionDbEntity>
{
    public void Configure(EntityTypeBuilder<PrescriptionDbEntity> builder)
    {
        builder.ToTable("naz").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.SequenceNumber)
            .HasColumnName("naz_n")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.PrescriptionType)
            .HasColumnName("naz_r")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.PhysicianSpecialty)
            .HasColumnName("naz_sp")
            .HasMaxLength(10)
            .IsUnicode(true)
            .IsRequired();

        builder.Property(prop => prop.DiagnosticMethod)
            .HasColumnName("naz_v")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.MedicalCareProfile)
            .HasColumnName("naz_pmp")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.BedProfile)
            .HasColumnName("naz_pk")
            .HasMaxLength(3)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.ServiceCode)
            .HasColumnName("naz_usl")
            .HasMaxLength(15)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.ReferralDate)
            .HasColumnName("napr_date")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.ReferredToMoCode)
            .HasColumnName("napr_mo")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(prescription => prescription.MedicalCase)
            .WithMany(medicalCase => medicalCase.Prescriptions)
            .HasForeignKey(prescription => prescription.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}