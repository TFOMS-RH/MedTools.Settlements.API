using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionCompletedCaseDetailsConfiguration : IEntityTypeConfiguration<ProjectionCompletedCaseDetails>
{
    public void Configure(EntityTypeBuilder<ProjectionCompletedCaseDetails> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("lpu");
        builder.Property(prop => prop.MedicalOrganizationName).HasColumnName("name_lpu");
        builder.Property(prop => prop.ReferringMedicalOrganizationCode).HasColumnName("npr_mo").IsRequired(false);
        builder.Property(prop => prop.ReferringMedicalOrganizationName).HasColumnName("name_napr_mo").IsRequired(false);
        builder.Property(prop => prop.ReferralDate).HasColumnName("npr_date").IsRequired(false);
        builder.Property(prop => prop.CareConditionCode).HasColumnName("usl_ok");
        builder.Property(prop => prop.CareConditionName).HasColumnName("umpname").IsRequired(false);
        builder.Property(prop => prop.MedicalCareTypeCode).HasColumnName("vidpom");
        builder.Property(prop => prop.MedicalCareTypeName).HasColumnName("vmpname").IsRequired(false);
        builder.Property(prop => prop.PaymentMethodCode).HasColumnName("idsp");
        builder.Property(prop => prop.PaymentMethodName).HasColumnName("spname").IsRequired(false);
        builder.Property(prop => prop.MedicalCareFormCode).HasColumnName("for_pom");
        builder.Property(prop => prop.MedicalCareFormName).HasColumnName("FRMMPNAME").IsRequired(false);
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_z_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_z_2");
        builder.Property(prop => prop.HospitalizationDuration).HasColumnName("kd_z").IsRequired(false);
        builder.Property(prop => prop.HospitalizationOutcomeCode).HasColumnName("rslt");
        builder.Property(prop => prop.HospitalizationOutcomeName).HasColumnName("rmpname").IsRequired(false);
        builder.Property(prop => prop.IsIntrahospitalTransfer).HasColumnName("vb_p").IsRequired(false);
        builder.Property(prop => prop.ScreeningResult).HasColumnName("rslt_d").IsRequired(false);
        builder.Property(prop => prop.IsRefusal).HasColumnName("p_otk").IsRequired(false);
        builder.Property(prop => prop.IsMobileTeam).HasColumnName("vbr").IsRequired(false);
        builder.Property(prop => prop.DiseaseOutcomeCode).HasColumnName("ishod");
        builder.Property(prop => prop.DiseaseOutcomeName).HasColumnName("izname").IsRequired(false);
    }
}
