using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Models;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Configuration;

public sealed class ReconciliationActFileRootDbEntityConfiguration : IEntityTypeConfiguration<ReconciliationActFileRoot>
{
    public void Configure(EntityTypeBuilder<ReconciliationActFileRoot> builder)
    {
        builder.ToTable("sver_in_acts_zl_list").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.UploadDate).HasColumnName("uploaddate").IsRequired(false);
        builder.Property(prop => prop.Uploader).HasColumnName("uploader").IsRequired(false);
        builder.Property(prop => prop.ActStatus).HasColumnName("status").IsRequired(false);
    }
}
