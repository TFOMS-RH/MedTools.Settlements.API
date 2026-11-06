using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ContraindicationDbEntityConfiguration : IEntityTypeConfiguration<ContraindicationDbEntity>
{
    public void Configure(EntityTypeBuilder<ContraindicationDbEntity> builder)
    {
        builder.ToTable("dbo.b_prot").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.OncologyCaseUid)
            .HasColumnName("onk_sl_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ContraindicationCode)
            .HasColumnName("prot")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.ContraindicationDate)
            .HasColumnName("d_prot")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder
            .HasOne(contraindication => contraindication.OncologyCase)
            .WithMany(oncologyCase => oncologyCase.Contraindications)
            .HasForeignKey(contraindication => contraindication.OncologyCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}