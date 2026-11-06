using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class OncologyServiceDbEntityConfiguration : IEntityTypeConfiguration<OncologyServiceDbEntity>
{
    public void Configure(EntityTypeBuilder<OncologyServiceDbEntity> builder)
    {
        builder.ToTable("onk_usl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.OncologyCaseUid)
            .HasColumnName("onk_sl_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ServiceTypeCode)
            .HasColumnName("usl_tip")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.SurgicalTreatmentTypeCode)
            .HasColumnName("hir_tip")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.DrugTherapyLineCode)
            .HasColumnName("lek_tip_l")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.DrugTherapyCycleCode)
            .HasColumnName("lek_tip_v")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.IsAntiemeticProphylaxis)
            .HasColumnName("pptr")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.RadioTherapyTypeCode)
            .HasColumnName("luch_tip")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder
            .HasOne(oncologyService => oncologyService.OncologyCase)
            .WithMany(oncologyCase => oncologyCase.OncologyServices)
            .HasForeignKey(oncologyService => oncologyService.OncologyCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}