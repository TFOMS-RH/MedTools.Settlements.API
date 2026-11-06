using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class InvoiceDbEntityConfiguration : IEntityTypeConfiguration<InvoiceDbEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceDbEntity> builder)
    {
        builder.ToTable("schet").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalRegistryUid).HasColumnName("zl_list_uid");

        builder.Property(prop => prop.InvoiceCode).HasColumnName("code");
        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("code_mo");
        builder.Property(prop => prop.BillingYear).HasColumnName("year");
        builder.Property(prop => prop.BillingMonth).HasColumnName("month");
        builder.Property(prop => prop.InvoiceNumber).HasColumnName("nschet");
        builder.Property(prop => prop.InvoiceBillingDate).HasColumnName("dschet");
        builder.Property(prop => prop.PayerCode).HasColumnName("plat").IsRequired(false);
        builder.Property(prop => prop.InvoiceAmount).HasColumnName("summav");
        builder.Property(prop => prop.InternalComment).HasColumnName("coments").IsRequired(false);
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("summap").IsRequired(false);
        builder.Property(prop => prop.MedicalEconomicControlPenalty).HasColumnName("sank_mek").IsRequired(false);
        builder.Property(prop => prop.MedicalEconomicExpertisePenalty).HasColumnName("sank_mee").IsRequired(false);
        builder.Property(prop => prop.MedicalCareQualityExpertisePenalty).HasColumnName("sank_ekmp").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_summap").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyMedicalEconomicControlPenalty).HasColumnName("smo_sank_mek").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyMedicalEconomicExpertisePenalty).HasColumnName("smo_sank_mee").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyMedicalCareQualityExpertisePenalty).HasColumnName("smo_sank_ekmp").IsRequired(false);
        builder.Property(prop => prop.PreventiveExaminationType).HasColumnName("disp").IsRequired(false);

        builder
            .HasOne(invoice => invoice.MedicalRegistry)
            .WithOne(medicalRegistry => medicalRegistry.Invoice)
            .HasForeignKey<InvoiceDbEntity>(invoice => invoice.MedicalRegistryUid);
    }
}
