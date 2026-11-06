using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class CompletedCaseDbEntityConfiguration : IEntityTypeConfiguration<CompletedCaseDbEntity>
{
    public void Configure(EntityTypeBuilder<CompletedCaseDbEntity> builder)
    {
        builder.ToTable("z_sl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalRecordUid).HasColumnName("zap_uid");

        builder.Property(prop => prop.CaseRecordNumber).HasColumnName("idcase");
        builder.Property(prop => prop.CareCondition).HasColumnName("usl_ok");
        builder.Property(prop => prop.MedicalCareType).HasColumnName("vidpom");
        builder.Property(prop => prop.CareForm).HasColumnName("for_pom");
        builder.Property(prop => prop.ReferringMedicalOrganizationCode).HasColumnName("npr_mo").IsRequired(false);
        builder.Property(prop => prop.ReferralDate).HasColumnName("npr_date").IsRequired(false);
        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("lpu");
        builder.Property(prop => prop.IsMobileTeam).HasColumnName("vbr").IsRequired(false);
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_z_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_z_2");
        builder.Property(prop => prop.IsRefusal).HasColumnName("p_otk").IsRequired(false);
        builder.Property(prop => prop.ScreeningResult).HasColumnName("rslt_d").IsRequired(false);
        builder.Property(prop => prop.HospitalizationDuration).HasColumnName("kd_z").IsRequired(false);
        builder.Property(prop => prop.BirthWeight).HasColumnName("vnov_m").IsRequired(false);
        builder.Property(prop => prop.HospitalizationOutcome).HasColumnName("rslt");
        builder.Property(prop => prop.DiseaseOutcome).HasColumnName("ishod");
        builder.Property(prop => prop.IsSpecialCase).HasColumnName("os_sluch").IsRequired(false);
        builder.Property(prop => prop.IsIntrahospitalTransfer).HasColumnName("vb_p").IsRequired(false);
        builder.Property(prop => prop.PaymentMethodCode).HasColumnName("idsp");
        builder.Property(prop => prop.BilledAmount).HasColumnName("sumv");
        builder.Property(prop => prop.PaymentType).HasColumnName("oplata").IsRequired(false);
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("sump").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_sump").IsRequired(false);
        builder.Property(prop => prop.PenaltyAmount).HasColumnName("sank_it").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyPenaltyAmount).HasColumnName("smo_sank_it").IsRequired(false);
        builder.Property(prop => prop.IsEveningVisit).HasColumnName("evening_time").IsRequired(false);
        builder.Property(prop => prop.ReferralNumber).HasColumnName("npr_num").IsRequired(false);

        builder
            .HasOne(completedCase => completedCase.MedicalRecord)
            .WithOne(medicalRecord => medicalRecord.CompletedCase)
            .HasForeignKey<CompletedCaseDbEntity>(completedCase => completedCase.MedicalRecordUid);
    }
}
