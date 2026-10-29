using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Configuration;

public sealed class ReconciliationActFileRootDbEntityConfiguration : IEntityTypeConfiguration<ReconciliationActFileRoot>
{
    public void Configure(EntityTypeBuilder<ReconciliationActFileRoot> builder)
    {
        builder.ToTable("sver_in_acts_zl_list").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.UploadDate).HasColumnName("uploaddate");
        builder.Property(prop => prop.Uploader).HasColumnName("uploader");
        builder.Property(prop => prop.ActStatus).HasColumnName("status");
    }
}
