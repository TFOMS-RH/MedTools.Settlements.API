using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class MedicalInvoiceDbEntityConfiguration : IEntityTypeConfiguration<MedicalInvoiceDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalInvoiceDbEntity> builder)
    {
        builder.ToTable("schet").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalRegistryUid)
            .HasColumnName("zl_list_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.InvoiceCode)
            .HasColumnName("code")
            .HasColumnType("bigint")
            .IsRequired();

        builder.Property(prop => prop.MedicalOrganizationCode)
            .HasColumnName("code_mo")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.BillingYear)
            .HasColumnName("year")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.BillingMonth)
            .HasColumnName("month")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.InvoiceNumber)
            .HasColumnName("nschet")
            .HasMaxLength(15)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.InvoiceBillingDate)
            .HasColumnName("dschet")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.PayerCode)
            .HasColumnName("plat")
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InvoiceAmount)
            .HasColumnName("summav")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(prop => prop.InternalComment)
            .HasColumnName("coments")
            .HasMaxLength(250)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.ApprovedAmount)
            .HasColumnName("summap")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalEconomicControlPenalty)
            .HasColumnName("sank_mek")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalEconomicExpertisePenalty)
            .HasColumnName("sank_mee")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalCareQualityExpertisePenalty)
            .HasColumnName("sank_ekmp")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyApprovedAmount)
            .HasColumnName("smo_summap")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyMedicalEconomicControlPenalty)
            .HasColumnName("smo_sank_mek")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyMedicalEconomicExpertisePenalty)
            .HasColumnName("smo_sank_mee")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.InsuranceCompanyMedicalCareQualityExpertisePenalty)
            .HasColumnName("smo_sank_ekmp")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.PreventiveExaminationType)
            .HasColumnName("disp")
            .HasMaxLength(3)
            .IsUnicode(true)
            .IsRequired(false);

        builder
            .HasOne(invoice => invoice.MedicalRegistry)
            .WithOne(medicalRegistry => medicalRegistry.Invoice)
            .HasForeignKey<MedicalInvoiceDbEntity>(invoice => invoice.MedicalRegistryUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}