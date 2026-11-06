using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class PrescriptionDbEntityConfiguration : IEntityTypeConfiguration<PrescriptionDbEntity>
{
    public void Configure(EntityTypeBuilder<PrescriptionDbEntity> builder)
    {
        builder.ToTable("naz").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.SequenceNumber).HasColumnName("naz_n");
        builder.Property(prop => prop.PrescriptionType).HasColumnName("naz_r");
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("naz_sp");
        builder.Property(prop => prop.DiagnosticMethod).HasColumnName("naz_v");
        builder.Property(prop => prop.MedicalCareProfile).HasColumnName("naz_pmp");
        builder.Property(prop => prop.BedProfile).HasColumnName("naz_pk");
        builder.Property(prop => prop.ServiceCode).HasColumnName("naz_usl");
        builder.Property(prop => prop.ReferralDate).HasColumnName("napr_date");
        builder.Property(prop => prop.ReferredToMoCode).HasColumnName("napr_mo");

        builder
            .HasOne(prescription => prescription.MedicalCase)
            .WithMany(medicalCase => medicalCase.Prescriptions)
            .HasForeignKey(prescription => prescription.MedicalCaseUid);
    }
}
