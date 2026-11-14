using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionMedicationConfiguration : IEntityTypeConfiguration<ProjectionMedication>
{
    public void Configure(EntityTypeBuilder<ProjectionMedication> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicamentUid).HasColumnName("uid");
        builder.Property(prop => prop.DrugIdentifier).HasColumnName("regnum");
        builder.Property(prop => prop.DrugExtendedIdentifier).HasColumnName("regnum_dop").IsRequired(false);
        builder.Property(prop => prop.TherapyRegimenCode).HasColumnName("code_sh").IsRequired(false);
    }
}
