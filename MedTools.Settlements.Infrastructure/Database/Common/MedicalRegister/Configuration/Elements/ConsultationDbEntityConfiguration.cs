using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ConsultationDbEntityConfiguration : IEntityTypeConfiguration<ConsultationDbEntity>
{
    public void Configure(EntityTypeBuilder<ConsultationDbEntity> builder)
    {
        builder.ToTable("dbo.cons").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ConsultationPurposeCode)
            .HasColumnName("pr_cons")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.ConsultationDate)
            .HasColumnName("dt_cons")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder
            .HasOne(consultation => consultation.MedicalCase)
            .WithMany(medicalCase => medicalCase.Consultations)
            .HasForeignKey(consultation => consultation.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}