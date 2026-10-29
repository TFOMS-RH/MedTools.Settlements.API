using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Configuration;

public sealed class ReconciliationActRecordDbEntityConfiguration : IEntityTypeConfiguration<ReconciliationActRecord>
{
    public void Configure(EntityTypeBuilder<ReconciliationActRecord> builder)
    {
        builder.ToTable("sver_in_acts_zap").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.ReconciliationActFileRootUid).HasColumnName("sver_out_acts_zl_list_uid");
        builder.Property(prop => prop.RecordNumber).HasColumnName("n_zap");

        builder.HasOne(reconciliationActRecord => reconciliationActRecord.ReconciliationActFileRoot)
            .WithMany(reconciliationActFileRoot => reconciliationActFileRoot.Records)
            .HasForeignKey(reconciliationActRecord => reconciliationActRecord.ReconciliationActFileRootUid);

    }
}
