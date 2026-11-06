using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class MedicalCaseDbEntityConfiguration : IEntityTypeConfiguration<MedicalCaseDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCaseDbEntity> builder)
    {
        builder.ToTable("dbo.sluch").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.CompletedCaseUid)
            .HasColumnName("z_sl_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.MedicalCaseIdentificator)
            .HasColumnName("sl_id")
            .HasMaxLength(36)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.HighTechCareType)
            .HasColumnName("vid_hmp")
            .HasMaxLength(16)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.HighTechCareMethod)
            .HasColumnName("metod_hmp")
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.Division)
            .HasColumnName("lpu_1")
            .HasMaxLength(17)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.DepartmentCode)
            .HasColumnName("podr")
            .HasColumnType("bigint")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalProfile)
            .HasColumnName("profil")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.BedProfile)
            .HasColumnName("profil_k")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.IsPediatric)
            .HasColumnName("det")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(prop => prop.VoucherIssueDate)
            .HasColumnName("tal_d")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.VoucherNumber)
            .HasColumnName("tal_num")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.PlannedAdmissionDate)
            .HasColumnName("tal_p")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.VisitPurpose)
            .HasColumnName("p_cel")
            .HasMaxLength(4)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.MedicalRecordNumber)
            .HasColumnName("history")
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.IsAdmissionTransfer)
            .HasColumnName("p_per")
            .HasColumnType("smallint")
            .IsRequired(false);

        builder.Property(prop => prop.TreatmentStartDate)
            .HasColumnName("date_1")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.TreatmentEndDate)
            .HasColumnName("date_2")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.HospitalizationDuration)
            .HasColumnName("kd")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.InitialDiagnosis)
            .HasColumnName("ds0")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PrimaryDiagnosis)
            .HasColumnName("ds1")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.IsPrimaryDiagnosis)
            .HasColumnName("ds1_pr")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.DispensaryObservation)
            .HasColumnName("pr_d_n")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.ConcomitantDiagnosis)
            .HasColumnName("ds2")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.ComplicationDiagnosis)
            .HasColumnName("ds3")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.AdditionalDispensaryObservation)
            .HasColumnName("dn")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalEconomicStandardCode)
            .HasColumnName("code_mes1")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.ConcomitantMesCode)
            .HasColumnName("code_mes2")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.IsRehabilitation)
            .HasColumnName("reab")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.PhysicianSpecialty)
            .HasColumnName("prvs")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.MedicalSpecialtyCode)
            .HasColumnName("vers_spec")
            .HasMaxLength(4)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PhysicianCode)
            .HasColumnName("iddokt")
            .HasMaxLength(25)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PaidUnits)
            .HasColumnName("ed_col")
            .HasColumnType("smallmoney")
            .IsRequired(false);

        builder.Property(prop => prop.UnitRate)
            .HasColumnName("tarif")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.ClaimedAmount)
            .HasColumnName("sum_m")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(prop => prop.ApprovedAmount)
            .HasColumnName("sump")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyApprovedAmount)
            .HasColumnName("smo_sump")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InternalComment)
            .HasColumnName("comentsl")
            .HasMaxLength(250)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.MedicalEconomicControlPenalty)
            .HasColumnName("sank_mek")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalEconomicExpertisePenalty)
            .HasColumnName("sank_mee")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.QualityMedicalCareExpertisePenalty)
            .HasColumnName("sank_ekmp")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.FacilityLevel)
            .HasColumnName("lpu_level")
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.IsOncologySuspicion)
            .HasColumnName("ds_onk")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.DiseaseCharacter)
            .HasColumnName("c_zab")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.Weight)
            .HasColumnName("wei")
            .HasColumnType("decimal(4,1)")
            .IsRequired(false);

        builder.Property(prop => prop.PreventiveCareMoCode)
            .HasColumnName("prof_m")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.EncounterMoCode)
            .HasColumnName("mop")
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(medicalCase => medicalCase.CompletedCase)
            .WithMany(completedCase => completedCase.MedicalCases)
            .HasForeignKey(medicalCase => medicalCase.CompletedCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}