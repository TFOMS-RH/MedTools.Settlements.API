using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ReferralDbEntityConfiguration : IEntityTypeConfiguration<ReferralDbEntity>
{
    public void Configure(EntityTypeBuilder<ReferralDbEntity> builder)
    {
        builder.ToTable("dbo.napr").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ReferralDate)
            .HasColumnName("napr_date")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.ReferralType)
            .HasColumnName("napr_v")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.DiagnosticMethod)
            .HasColumnName("met_issl")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.ReferredServiceCode)
            .HasColumnName("napr_usl")
            .HasMaxLength(15)
            .IsUnicode(true)
            .IsRequired(false);

        builder.Property(prop => prop.ReferredToMoCode)
            .HasColumnName("napr_mo")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(referral => referral.MedicalCase)
            .WithMany(medicalCase => medicalCase.Referrals)
            .HasForeignKey(referral => referral.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}