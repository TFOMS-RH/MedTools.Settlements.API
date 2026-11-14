using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class OncologyCaseDbEntityConfiguration : IEntityTypeConfiguration<OncologyCaseDbEntity>
{
    public void Configure(EntityTypeBuilder<OncologyCaseDbEntity> builder)
    {
        builder.ToTable("onk_sl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ReferralReasonCode)
            .HasColumnName("ds1_t")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.Stage)
            .HasColumnName("stad")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.TumorValue)
            .HasColumnName("onk_t")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.NodusValue)
            .HasColumnName("onk_n")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.MetastasisValue)
            .HasColumnName("onk_m")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.IsMetastasisDetected)
            .HasColumnName("mtstz")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.TotalFocusDose)
            .HasColumnName("sod")
            .HasColumnType("real")
            .IsRequired(false);

        builder.Property(prop => prop.RadiationFractionsCount)
            .HasColumnName("k_fr")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.Weight)
            .HasColumnName("wei")
            .HasColumnType("real")
            .IsRequired(false);

        builder.Property(prop => prop.Height)
            .HasColumnName("hei")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.BodySurfaceArea)
            .HasColumnName("bsa")
            .HasColumnType("real")
            .IsRequired(false);

        builder
            .HasOne(oncologyCase => oncologyCase.MedicalCase)
            .WithOne(medicalCase => medicalCase.OncologyCase)
            .HasForeignKey<OncologyCaseDbEntity>(oncologyCase => oncologyCase.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}