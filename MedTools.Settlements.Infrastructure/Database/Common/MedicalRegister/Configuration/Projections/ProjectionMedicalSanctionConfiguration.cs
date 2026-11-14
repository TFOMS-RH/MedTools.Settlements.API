using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionMedicalSanctionConfiguration : IEntityTypeConfiguration<ProjectionMedicalSanction>
{
    public void Configure(EntityTypeBuilder<ProjectionMedicalSanction> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalSanctionUid).HasColumnName("uid");
        builder.Property(prop => prop.SanctionCode).HasColumnName("s_code");
        builder.Property(prop => prop.SanctionAmount).HasColumnName("s_sum");
        builder.Property(prop => prop.ControlTypeCode).HasColumnName("s_tip");
        builder.Property(prop => prop.ControlTypeName).HasColumnName("vidname");
        builder.Property(prop => prop.RefusalReasonCode).HasColumnName("s_osn");
        builder.Property(prop => prop.RefusalReasonName).HasColumnName("Naim");
        builder.Property(prop => prop.Comment).HasColumnName("s_com").IsRequired(false);
        builder.Property(prop => prop.Source).HasColumnName("s_ist");
        builder.Property(prop => prop.UnitsRemoved).HasColumnName("s_ed_col");
        builder.Property(prop => prop.ExpertiseActDate).HasColumnName("s_dact");
        builder.Property(prop => prop.ExpertiseActNumber).HasColumnName("s_nact");
        builder.Property(prop => prop.ExpertCode).HasColumnName("s_codex");
        builder.Property(prop => prop.Filename).HasColumnName("filename");
        builder.Property(prop => prop.Year).HasColumnName("year").IsRequired(false);
        builder.Property(prop => prop.Month).HasColumnName("month").IsRequired(false);
        builder.Property(prop => prop.UploadDate).HasColumnName("uploaddate").IsRequired(false);
    }
}
