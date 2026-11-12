using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionContraindicationConfiguration : IEntityTypeConfiguration<ProjectionContraindication>
{
    public void Configure(EntityTypeBuilder<ProjectionContraindication> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ContraindicationUid).HasColumnName("uid");
        builder.Property(prop => prop.ContraindicationCode).HasColumnName("contraindication_code");
        builder.Property(prop => prop.Contraindication).HasColumnName("contraindication");
        builder.Property(prop => prop.ContraindicationDate).HasColumnName("d_prot");
    }
}
