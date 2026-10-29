using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Configuration;

public sealed class ReconciliationActFileHeaderDbEntityConfiguration : IEntityTypeConfiguration<ReconciliationActFileHeader>
{
    public void Configure(EntityTypeBuilder<ReconciliationActFileHeader> builder)
    {
        builder.ToTable("sver_in_acts_zglv").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.ReconciliationActFileRootUid).HasColumnName("sver_out_acts_zl_list_uid");
        builder.Property(prop => prop.Version).HasColumnName("version");
        builder.Property(prop => prop.ActDate).HasColumnName("data");
        builder.Property(prop => prop.Filename).HasColumnName("filename");

        builder.HasOne(reconciliationActFileHeader => reconciliationActFileHeader.ReconciliationActFileRoot)
            .WithOne(reconciliationActFileRoot => reconciliationActFileRoot.Header)
            .HasForeignKey<ReconciliationActFileHeader>(reconciliationActFileHeader => reconciliationActFileHeader.ReconciliationActFileRootUid);
    }
}
