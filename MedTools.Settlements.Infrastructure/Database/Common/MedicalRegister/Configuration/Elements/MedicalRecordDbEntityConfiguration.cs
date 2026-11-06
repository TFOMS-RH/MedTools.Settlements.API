using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class MedicalRecordDbEntityConfiguration : IEntityTypeConfiguration<MedicalRecordDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRecordDbEntity> builder)
    {
        builder.ToTable("zap").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalRegistryUid).HasColumnName("zl_list_uid");
        builder.Property(prop => prop.PatientUid).HasColumnName("pacient");

        builder.Property(prop => prop.RecordSequenceNumber).HasColumnName("n_zap");
        builder.Property(prop => prop.IsRevisedRecord).HasColumnName("pr_nov");

        builder
            .HasOne(medicalRecord => medicalRecord.MedicalRegistry)
            .WithMany(medicalRegistry => medicalRegistry.MedicalRecords)
            .HasForeignKey(medicalRecord => medicalRecord.MedicalRegistryUid);

        builder
            .HasOne(medicalRecord => medicalRecord.Patient)
            .WithOne(patient => patient.MedicalRecord)
            .HasForeignKey<MedicalRecordDbEntity>(medicalRecord => medicalRecord.PatientUid);
    }
}