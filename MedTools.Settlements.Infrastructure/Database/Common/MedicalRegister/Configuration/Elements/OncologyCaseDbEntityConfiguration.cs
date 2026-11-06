using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class OncologyCaseDbEntityConfiguration : IEntityTypeConfiguration<OncologyCaseDbEntity>
{
    public void Configure(EntityTypeBuilder<OncologyCaseDbEntity> builder)
    {
        builder.ToTable("onk_sl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.ReferralReasonCode).HasColumnName("ds1_t").IsRequired(false);
        builder.Property(prop => prop.Stage).HasColumnName("stad").IsRequired(false);
        builder.Property(prop => prop.TumorValue).HasColumnName("onk_t").IsRequired(false);
        builder.Property(prop => prop.NodusValue).HasColumnName("onk_n").IsRequired(false);
        builder.Property(prop => prop.MetastasisValue).HasColumnName("onk_m").IsRequired(false);
        builder.Property(prop => prop.IsMetastasisDetected).HasColumnName("mtstz").IsRequired(false);
        builder.Property(prop => prop.TotalFocusDose).HasColumnName("sod").IsRequired(false);
        builder.Property(prop => prop.RadiationFractionsCount).HasColumnName("k_fr").IsRequired(false);
        builder.Property(prop => prop.Weight).HasColumnName("wei").IsRequired(false);
        builder.Property(prop => prop.Height).HasColumnName("hei").IsRequired(false);
        builder.Property(prop => prop.BodySurfaceArea).HasColumnName("bsa").IsRequired(false);

        builder
            .HasOne(oncologyCase => oncologyCase.MedicalCase)
            .WithOne(medicalCase => medicalCase.OncologyCase)
            .HasForeignKey<OncologyCaseDbEntity>(oncologyCase => oncologyCase.MedicalCaseUid);
    }
}
