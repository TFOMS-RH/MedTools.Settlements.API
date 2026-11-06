using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class OncologyServiceDbEntityConfiguration : IEntityTypeConfiguration<OncologyServiceDbEntity>
{
    public void Configure(EntityTypeBuilder<OncologyServiceDbEntity> builder)
    {
        builder.ToTable("onk_usl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.OncologyCaseUid).HasColumnName("onk_sl_uid");

        builder.Property(prop => prop.ServiceTypeCode).HasColumnName("usl_tip");
        builder.Property(prop => prop.SurgicalTreatmentTypeCode).HasColumnName("hir_tip").IsRequired(false);
        builder.Property(prop => prop.DrugTherapyLineCode).HasColumnName("lek_tip_l").IsRequired(false);
        builder.Property(prop => prop.DrugTherapyCycleCode).HasColumnName("lek_tip_v").IsRequired(false);
        builder.Property(prop => prop.IsAntiemeticProphylaxis).HasColumnName("pptr").IsRequired(false);
        builder.Property(prop => prop.RadioTherapyTypeCode).HasColumnName("luch_tip").IsRequired(false);

        builder
            .HasOne(oncologyService => oncologyService.OncologyCase)
            .WithMany(oncologyCase => oncologyCase.OncologyServices)
            .HasForeignKey(oncologyService => oncologyService.OncologyCaseUid);
    }
}
