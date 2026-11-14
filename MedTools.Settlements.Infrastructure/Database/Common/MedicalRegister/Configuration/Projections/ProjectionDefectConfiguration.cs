using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionDefectConfiguration : IEntityTypeConfiguration<ProjectionDefect>
{
    public void Configure(EntityTypeBuilder<ProjectionDefect> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.DefectUid).HasColumnName("uid");
        builder.Property(prop => prop.Code).HasColumnName("kod");
        builder.Property(prop => prop.Comment).HasColumnName("comment");
    }
}
