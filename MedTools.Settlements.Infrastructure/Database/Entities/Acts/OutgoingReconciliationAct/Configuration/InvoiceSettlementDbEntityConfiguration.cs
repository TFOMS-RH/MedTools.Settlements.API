using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Configuration;

public sealed class InvoiceSettlementDbEntityConfiguration : IEntityTypeConfiguration<InvoiceSettlement>
{
    public void Configure(EntityTypeBuilder<InvoiceSettlement> builder)
    {
        builder.ToTable("sver_out_acts_rasschet").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.ReconciliationActRecordUid).HasColumnName("sver_out_acts_zap_uid");
        builder.Property(prop => prop.InvoiceNumber).HasColumnName("nschet");
        builder.Property(prop => prop.InvoiceDate).HasColumnName("dschet");
        builder.Property(prop => prop.OpeningBalance).HasColumnName("schet_ob");
        builder.Property(prop => prop.MedicalCarePaymentAmount).HasColumnName("summap");
        builder.Property(prop => prop.RecoveryNoticeAmount).HasColumnName("summarec");
        builder.Property(prop => prop.RefundNoticeAmount).HasColumnName("summaret");
        builder.Property(prop => prop.TransferFromInsurancePlaceAmount).HasColumnName("summa1");
        builder.Property(prop => prop.TransferFromCarePlaceAmount).HasColumnName("summa2");
        builder.Property(prop => prop.ClosingBalance).HasColumnName("schet_cb");

        builder.HasOne(invoiceSettement => invoiceSettement.ReconciliationActRecord)
            .WithOne(reconciliationActRecord => reconciliationActRecord.InvoiceSettlement)
            .HasForeignKey<InvoiceSettlement>(InvoiceSettlement => InvoiceSettlement.ReconciliationActRecordUid);

    }
}
