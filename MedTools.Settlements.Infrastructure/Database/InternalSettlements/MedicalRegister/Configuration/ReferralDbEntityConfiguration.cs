using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class ReferralDbEntityConfiguration : IEntityTypeConfiguration<ReferralDbEntity>
{
    public void Configure(EntityTypeBuilder<ReferralDbEntity> builder)
    {
        builder.ToTable("napr").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.ReferralDate).HasColumnName("napr_date");
        builder.Property(prop => prop.ReferralType).HasColumnName("napr_v");
        builder.Property(prop => prop.DiagnosticMethod).HasColumnName("met_issl");
        builder.Property(prop => prop.ReferredServiceCode).HasColumnName("napr_usl");
        builder.Property(prop => prop.ReferredToMoCode).HasColumnName("napr_mo");

        builder
            .HasOne(referral => referral.MedicalCase)
            .WithMany(medicalCase => medicalCase.Referrals)
            .HasForeignKey(referral => referral.MedicalCaseUid);
    }
}
