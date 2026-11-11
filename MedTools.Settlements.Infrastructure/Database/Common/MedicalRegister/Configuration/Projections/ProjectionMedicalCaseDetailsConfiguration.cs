using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionMedicalCaseDetailsConfiguration : IEntityTypeConfiguration<ProjectionMedicalCaseDetails>
{
    public void Configure(EntityTypeBuilder<ProjectionMedicalCaseDetails> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalProfileCode).HasColumnName("profil");
        builder.Property(prop => prop.MedicalProfileName).HasColumnName("PRNAME").IsRequired(false);
        builder.Property(prop => prop.PhysicianSpecialtyCode).HasColumnName("prvs");
        builder.Property(prop => prop.PhysicianSpecialtyName).HasColumnName("specname").IsRequired(false);
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_2");
        builder.Property(prop => prop.PrimaryDiagnosisCode).HasColumnName("ds1");
        builder.Property(prop => prop.PrimaryDiagnosisName).HasColumnName("NAME_DS1").IsRequired(false);
        builder.Property(prop => prop.PaidUnits).HasColumnName("ed_col").IsRequired(false);
        builder.Property(prop => prop.DivisionNumber).HasColumnName("lpu_1").IsRequired(false);
        builder.Property(prop => prop.DivisionName).HasColumnName("NAM_SPMO").IsRequired(false);
        builder.Property(prop => prop.DepartmentCode).HasColumnName("podr").IsRequired(false);
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.VisitPurposeCode).HasColumnName("p_cel").IsRequired(false);
        builder.Property(prop => prop.VisitPurposeName).HasColumnName("n_pc").IsRequired(false);
        builder.Property(prop => prop.BedProfileCode).HasColumnName("profil_k").IsRequired(false);
        builder.Property(prop => prop.BedProfileName).HasColumnName("k_prname").IsRequired(false);
        builder.Property(prop => prop.MedicalRecordNumber).HasColumnName("history");
        builder.Property(prop => prop.AdmissionTransferCode).HasColumnName("p_per").IsRequired(false);
        builder.Property(prop => prop.AdmissionTransferName).HasColumnName("p_per_name").IsRequired(false);
        builder.Property(prop => prop.IsRehabilitation).HasColumnName("reab").IsRequired(false);
        builder.Property(prop => prop.HospitalizationDuration).HasColumnName("kd").IsRequired(false);
        builder.Property(prop => prop.FacilityLevel).HasColumnName("lpu_level").IsRequired(false);
        builder.Property(prop => prop.InitialDiagnosisCode).HasColumnName("ds0").IsRequired(false);
        builder.Property(prop => prop.InitialDiagnosisName).HasColumnName("NAME_DS0").IsRequired(false);
        builder.Property(prop => prop.IsOncologySuspicion).HasColumnName("ds_onk").IsRequired(false);
        builder.Property(prop => prop.PhysicianCode).HasColumnName("iddokt");
        builder.Property(prop => prop.Weight).HasColumnName("wei").IsRequired(false);
        builder.Property(prop => prop.DiseaseCharacter).HasColumnName("c_zab").IsRequired(false);
        builder.Property(prop => prop.InternalComment).HasColumnName("comentsl").IsRequired(false);
    }
}
