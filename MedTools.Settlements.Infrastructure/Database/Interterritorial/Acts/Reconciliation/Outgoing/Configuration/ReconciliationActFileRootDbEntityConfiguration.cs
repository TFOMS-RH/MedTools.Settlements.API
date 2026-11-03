using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Models;

namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Configuration;

public sealed class ReconciliationActFileRootDbEntityConfiguration : IEntityTypeConfiguration<ReconciliationActFileRoot>
{
    public void Configure(EntityTypeBuilder<ReconciliationActFileRoot> builder)
    {
        builder.ToTable("sver_out_acts_zl_list").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.UploadDate).HasColumnName("uploaddate").IsRequired(false);
        builder.Property(prop => prop.Uploader).HasColumnName("uploader").IsRequired(false);
        builder.Property(prop => prop.ActStatus).HasColumnName("status").IsRequired(false);
    }
}
