using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Configuration;

public sealed class ReconciliationActDbEntityConfiguration : IEntityTypeConfiguration<ReconciliationAct>
{
    public void Configure(EntityTypeBuilder<ReconciliationAct> builder)
    {
        builder.ToTable("sver_in_acts_act").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.ReconciliationActFileRootUid).HasColumnName("sver_out_acts_zl_list_uid");
        builder.Property(prop => prop.Year).HasColumnName("year");
        builder.Property(prop => prop.Quarter).HasColumnName("qr");
        builder.Property(prop => prop.ActNumber).HasColumnName("n_act");
        builder.Property(prop => prop.ActDate).HasColumnName("d_act");
        builder.Property(prop => prop.MedicalCareOkatoCode).HasColumnName("c_okato1");
        builder.Property(prop => prop.PolicyIssueOkatoCode).HasColumnName("okato_oms");

        builder.HasOne(reconciliationAct => reconciliationAct.ReconciliationActFileRoot)
            .WithOne(reconciliationActFileRoot => reconciliationActFileRoot.Act)
            .HasForeignKey<ReconciliationAct>(reconciliationAct => reconciliationAct.ReconciliationActFileRootUid);

    }
}
