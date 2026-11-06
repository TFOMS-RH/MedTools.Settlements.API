using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class PatientDbEntityConfiguration : IEntityTypeConfiguration<PatientDbEntity>
{
    public void Configure(EntityTypeBuilder<PatientDbEntity> builder)
    {
        builder.ToTable("dbo.pacient").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.PatientRecordCode)
            .HasColumnName("id_pac")
            .HasMaxLength(36)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.InsurancePolicyType)
            .HasColumnName("vpolis")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.InsurancePolicySeries)
            .HasColumnName("spolis")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InsurancePolicyNumber)
            .HasColumnName("npolis")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.InsurancePolicyUnifiedNumber)
            .HasColumnName("enp")
            .HasMaxLength(16)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceRegionCode)
            .HasColumnName("st_okato")
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyCode)
            .HasColumnName("smo")
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceOrganizationOgrn)
            .HasColumnName("smo_ogrn")
            .HasMaxLength(15)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceTerritoryOkato)
            .HasColumnName("smo_ok")
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyName)
            .HasColumnName("smo_nam")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.DisabilityGroup)
            .HasColumnName("inv")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.MedicoSocialExaminationReferral)
            .HasColumnName("mse")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.NewbornIdentifier)
            .HasColumnName("novor")
            .HasMaxLength(9)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.BirthWeight)
            .HasColumnName("vnov_d")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.SocialCategory)
            .HasColumnName("soc")
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.NextScheduledExaminationMonth)
            .HasColumnName("next_d")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.PrimaryCareMedicalOrganizationCode)
            .HasColumnName("mo_pr")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.EmploymentType)
            .HasColumnName("vz")
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.PatientStatus)
            .HasColumnName("pstatus")
            .HasColumnType("int")
            .IsRequired(false);
    }
}