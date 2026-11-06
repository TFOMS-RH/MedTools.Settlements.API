using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class PatientDbEntityConfiguration : IEntityTypeConfiguration<PatientDbEntity>
{
    public void Configure(EntityTypeBuilder<PatientDbEntity> builder)
    {
        builder.ToTable("pacient").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();

        builder.Property(prop => prop.PatientRecordCode).HasColumnName("id_pac");
        builder.Property(prop => prop.InsurancePolicyType).HasColumnName("vpolis");
        builder.Property(prop => prop.InsurancePolicySeries).HasColumnName("spolis").IsRequired(false);
        builder.Property(prop => prop.InsurancePolicyNumber).HasColumnName("npolis");
        builder.Property(prop => prop.InsurancePolicyUnifiedNumber).HasColumnName("enp").IsRequired(false);
        builder.Property(prop => prop.InsuranceRegionCode).HasColumnName("st_okato").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyCode).HasColumnName("smo").IsRequired(false);
        builder.Property(prop => prop.InsuranceOrganizationOgrn).HasColumnName("smo_ogrn").IsRequired(false);
        builder.Property(prop => prop.InsuranceTerritoryOkato).HasColumnName("smo_ok").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyName).HasColumnName("smo_nam").IsRequired(false);
        builder.Property(prop => prop.DisabilityGroup).HasColumnName("inv").IsRequired(false);
        builder.Property(prop => prop.MedicoSocialExaminationReferral).HasColumnName("mse").IsRequired(false);
        builder.Property(prop => prop.NewbornIdentifier).HasColumnName("novor");
        builder.Property(prop => prop.BirthWeight).HasColumnName("vnov_d").IsRequired(false);
        builder.Property(prop => prop.SocialCategory).HasColumnName("soc").IsRequired(false);
        builder.Property(prop => prop.NextScheduledExaminationMonth).HasColumnName("next_d").IsRequired(false);
        builder.Property(prop => prop.PrimaryCareMedicalOrganizationCode).HasColumnName("mo_pr").IsRequired(false);
        builder.Property(prop => prop.EmploymentType).HasColumnName("vz").IsRequired(false);
        builder.Property(prop => prop.PatientStatus).HasColumnName("pstatus").IsRequired(false);
    }
}