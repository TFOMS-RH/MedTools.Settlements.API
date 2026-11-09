using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.StoredProcedures;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.StoredProcedures;

public sealed class ProjectionMedicalCasedDbEntityConfiguration : IEntityTypeConfiguration<ProjectionMedicalCase>
{
    public void Configure(EntityTypeBuilder<ProjectionMedicalCase> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("uid");
        builder.Property(prop => prop.MedicalProfileCode).HasColumnName("profil");
        builder.Property(prop => prop.MedicalProfileName).HasColumnName("PRNAME");
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.PhysicianSpecialtyCode).HasColumnName("prvs");
        builder.Property(prop => prop.PhysicianSpecialtyName).HasColumnName("specname");
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_2");
        builder.Property(prop => prop.PrimaryDiagnosisCode).HasColumnName("ds1");
        builder.Property(prop => prop.PrimaryDiagnosisName).HasColumnName("NAME_DS").IsRequired(false);
        builder.Property(prop => prop.PaidUnits).HasColumnName("ed_col").IsRequired(false);
        builder.Property(prop => prop.UnitRate).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.AmountBilled).HasColumnName("sum_m");
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("sump").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_sump").IsRequired(false);
    }
}