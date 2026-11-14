using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class CompletedCaseDbEntityConfiguration : IEntityTypeConfiguration<CompletedCaseDbEntity>
{
    public void Configure(EntityTypeBuilder<CompletedCaseDbEntity> builder)
    {
        builder.ToTable("z_sl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalRecordUid)
            .HasColumnName("zap_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.CaseRecordNumber)
            .HasColumnName("idcase")
            .HasColumnType("bigint")
            .IsRequired();

        builder.Property(prop => prop.CareCondition)
            .HasColumnName("usl_ok")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.MedicalCareType)
            .HasColumnName("vidpom")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.CareForm)
            .HasColumnName("for_pom")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.ReferringMedicalOrganizationCode)
            .HasColumnName("npr_mo")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.ReferralDate)
            .HasColumnName("npr_date")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalOrganizationCode)
            .HasColumnName("lpu")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.IsMobileTeam)
            .HasColumnName("vbr")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.TreatmentStartDate)
            .HasColumnName("date_z_1")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.TreatmentEndDate)
            .HasColumnName("date_z_2")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.IsRefusal)
            .HasColumnName("p_otk")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.ScreeningResult)
            .HasColumnName("rslt_d")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.HospitalizationDuration)
            .HasColumnName("kd_z")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.BirthWeight)
            .HasColumnName("vnov_m")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.HospitalizationOutcome)
            .HasColumnName("rslt")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.DiseaseOutcome)
            .HasColumnName("ishod")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.IsSpecialCase)
            .HasColumnName("os_sluch")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.IsIntrahospitalTransfer)
            .HasColumnName("vb_p")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.PaymentMethodCode)
            .HasColumnName("idsp")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(prop => prop.BilledAmount)
            .HasColumnName("sumv")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(prop => prop.PaymentType)
            .HasColumnName("oplata")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.ApprovedAmount)
            .HasColumnName("sump")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyApprovedAmount)
            .HasColumnName("smo_sump")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.PenaltyAmount)
            .HasColumnName("sank_it")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyPenaltyAmount)
            .HasColumnName("smo_sank_it")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.IsEveningVisit)
            .HasColumnName("evening_time")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.ReferralNumber)
            .HasColumnName("npr_num")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(completedCase => completedCase.MedicalRecord)
            .WithOne(medicalRecord => medicalRecord.CompletedCase)
            .HasForeignKey<CompletedCaseDbEntity>(completedCase => completedCase.MedicalRecordUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}