using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ContraindicationDbEntityConfiguration : IEntityTypeConfiguration<ContraindicationDbEntity>
{
    public void Configure(EntityTypeBuilder<ContraindicationDbEntity> builder)
    {
        builder.ToTable("b_prot").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.OncologyCaseUid).HasColumnName("onk_sl_uid");

        builder.Property(prop => prop.ContraindicationCode).HasColumnName("prot");
        builder.Property(prop => prop.ContraindicationDate).HasColumnName("d_prot");

        builder
            .HasOne(contraindication => contraindication.OncologyCase)
            .WithMany(oncologyCase => oncologyCase.Contraindications)
            .HasForeignKey(contraindication => contraindication.OncologyCaseUid);
    }
}
