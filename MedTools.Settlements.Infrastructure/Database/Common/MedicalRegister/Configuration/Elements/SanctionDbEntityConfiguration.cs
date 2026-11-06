using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class SanctionDbEntityConfiguration : IEntityTypeConfiguration<SanctionDbEntity>
{
    public void Configure(EntityTypeBuilder<SanctionDbEntity> builder)
    {
        builder.ToTable("dbo.sank").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.SanctionDetailsUid)
            .HasColumnName("sank_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.SanctionCode)
            .HasColumnName("s_code")
            .HasMaxLength(36)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.SanctionAmount)
            .HasColumnName("s_sum")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(prop => prop.ControlTypeCode)
            .HasColumnName("s_tip")
            .HasMaxLength(3)
            .IsUnicode(true)
            .IsRequired();

        builder.Property(prop => prop.RefusalReasonCode)
            .HasColumnName("s_osn")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.Comment)
            .HasColumnName("s_com")
            .HasMaxLength(250)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.Source)
            .HasColumnName("s_ist")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(prop => prop.UnitsRemoved)
            .HasColumnName("s_ed_col")
            .HasColumnType("smallmoney")
            .IsRequired();

        builder.Property(prop => prop.ClinicalStatisticalGroupNumber)
            .HasColumnName("s_ksg")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.ExpertiseActNumber)
            .HasColumnName("s_nact")
            .HasMaxLength(30)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.ExpertiseActDate)
            .HasColumnName("s_dact")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.ExpertCode)
            .HasColumnName("s_codex")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder
            .HasOne(sanction => sanction.MedicalCase)
            .WithMany(medicalCase => medicalCase.Sanctions)
            .HasForeignKey(sanction => sanction.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}