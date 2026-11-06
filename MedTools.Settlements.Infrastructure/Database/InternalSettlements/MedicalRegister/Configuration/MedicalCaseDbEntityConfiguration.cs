using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class MedicalCaseDbEntityConfiguration : IEntityTypeConfiguration<MedicalCaseDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCaseDbEntity> builder)
    {
        builder.ToTable("sluch").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.CompletedCaseUid).HasColumnName("z_sl_uid");

        builder.Property(prop => prop.MedicalCaseIdentificator).HasColumnName("sl_id");
        builder.Property(prop => prop.HighTechCareType).HasColumnName("vid_hmp").IsRequired(false);
        builder.Property(prop => prop.HighTechCareMethod).HasColumnName("metod_hmp").IsRequired(false);
        builder.Property(prop => prop.Division).HasColumnName("lpu_1").IsRequired(false);
        builder.Property(prop => prop.DepartmentCode).HasColumnName("podr").IsRequired(false);
        builder.Property(prop => prop.MedicalProfile).HasColumnName("profil");
        builder.Property(prop => prop.BedProfile).HasColumnName("profil_k").IsRequired(false);
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.VoucherIssueDate).HasColumnName("tal_d").IsRequired(false);
        builder.Property(prop => prop.VoucherNumber).HasColumnName("tal_num").IsRequired(false);
        builder.Property(prop => prop.PlannedAdmissionDate).HasColumnName("tal_p").IsRequired(false);
        builder.Property(prop => prop.VisitPurpose).HasColumnName("p_cel").IsRequired(false);
        builder.Property(prop => prop.MedicalRecordNumber).HasColumnName("history");
        builder.Property(prop => prop.IsAdmissionTransfer).HasColumnName("p_per").IsRequired(false);
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_2");
        builder.Property(prop => prop.HospitalizationDuration).HasColumnName("kd").IsRequired(false);
        builder.Property(prop => prop.InitialDiagnosis).HasColumnName("ds0");
        builder.Property(prop => prop.PrimaryDiagnosis).HasColumnName("ds1").IsRequired(false);
        builder.Property(prop => prop.IsPrimaryDiagnosis).HasColumnName("ds1_pr").IsRequired(false);
        builder.Property(prop => prop.DispensaryObservation).HasColumnName("pr_d_n").IsRequired(false);
        builder.Property(prop => prop.ConcomitantDiagnosis).HasColumnName("ds2").IsRequired(false);
        builder.Property(prop => prop.ComplicationDiagnosis).HasColumnName("ds3").IsRequired(false);
        builder.Property(prop => prop.AdditionalDispensaryObservation).HasColumnName("dn").IsRequired(false);
        builder.Property(prop => prop.MedicalEconomicStandardCode).HasColumnName("code_mes1").IsRequired(false);
        builder.Property(prop => prop.ConcomitantMesCode).HasColumnName("code_mes2").IsRequired(false);
        builder.Property(prop => prop.IsRehabilitation).HasColumnName("reab").IsRequired(false);
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("prvs");
        builder.Property(prop => prop.MedicalSpecialtyCode).HasColumnName("vers_spec");
        builder.Property(prop => prop.PhysicianCode).HasColumnName("iddokt");
        builder.Property(prop => prop.PaidUnits).HasColumnName("ed_col").IsRequired(false);
        builder.Property(prop => prop.UnitRate).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.ClaimedAmount).HasColumnName("sum_m");
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("sump").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_sump").IsRequired(false);
        builder.Property(prop => prop.InternalComment).HasColumnName("comentsl").IsRequired(false);
        builder.Property(prop => prop.MedicalEconomicControlPenalty).HasColumnName("sank_mek").IsRequired(false);
        builder.Property(prop => prop.MedicalEconomicExpertisePenalty).HasColumnName("sank_mee").IsRequired(false);
        builder.Property(prop => prop.QualityMedicalCareExpertisePenalty).HasColumnName("sank_ekmp").IsRequired(false);
        builder.Property(prop => prop.FacilityLevel).HasColumnName("lpu_level").IsRequired(false);
        builder.Property(prop => prop.IsOncologySuspicion).HasColumnName("ds_onk").IsRequired(false);
        builder.Property(prop => prop.DiseaseCharacter).HasColumnName("c_zab").IsRequired(false);
        builder.Property(prop => prop.Weight).HasColumnName("wei").IsRequired(false);
        builder.Property(prop => prop.PreventiveCareMoCode).HasColumnName("prof_m").IsRequired(false);
        builder.Property(prop => prop.EncounterMoCode).HasColumnName("mop").IsRequired(false);

        builder
            .HasOne(medicalCase => medicalCase.CompletedCase)
            .WithMany(completedCase => completedCase.MedicalCases)
            .HasForeignKey(medicalCase => medicalCase.CompletedCaseUid);
    }
}
