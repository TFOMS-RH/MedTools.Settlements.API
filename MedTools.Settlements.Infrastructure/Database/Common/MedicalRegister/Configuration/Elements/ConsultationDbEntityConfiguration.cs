using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ConsultationDbEntityConfiguration : IEntityTypeConfiguration<ConsultationDbEntity>
{
    public void Configure(EntityTypeBuilder<ConsultationDbEntity> builder)
    {
        builder.ToTable("cons").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.ConsultationPurposeCode).HasColumnName("pr_cons");
        builder.Property(prop => prop.ConsultationDate).HasColumnName("dt_cons").IsRequired(false);

        builder
            .HasOne(consultation => consultation.MedicalCase)
            .WithMany(medicalCase => medicalCase.Consultations)
            .HasForeignKey(consultation => consultation.MedicalCaseUid);
    }
}