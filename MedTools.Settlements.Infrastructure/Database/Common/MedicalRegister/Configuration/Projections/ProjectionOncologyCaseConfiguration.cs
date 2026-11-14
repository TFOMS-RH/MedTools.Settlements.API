using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionOncologyCaseConfiguration : IEntityTypeConfiguration<ProjectionOncologyCase>
{
    public void Configure(EntityTypeBuilder<ProjectionOncologyCase> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.OncologyCaseUid).HasColumnName("uid");
        builder.Property(prop => prop.ReferralReasonCode).HasColumnName("referral_reason_code").IsRequired(false);
        builder.Property(prop => prop.ReferralReason).HasColumnName("referral_reason").IsRequired(false);
        builder.Property(prop => prop.StageCode).HasColumnName("stage_code").IsRequired(false);
        builder.Property(prop => prop.Stage).HasColumnName("stage").IsRequired(false);
        builder.Property(prop => prop.IcdDiagnosis).HasColumnName("stage_st").IsRequired(false);
        builder.Property(prop => prop.TumorValue).HasColumnName("onk_t").IsRequired(false);
        builder.Property(prop => prop.NodusValue).HasColumnName("onk_n").IsRequired(false);
        builder.Property(prop => prop.MetastasisValue).HasColumnName("onk_m").IsRequired(false);
        builder.Property(prop => prop.IsMetastasisDetected).HasColumnName("is_metastasis_detected").IsRequired(false);
        builder.Property(prop => prop.TotalFocusDose).HasColumnName("sod").IsRequired(false);
        builder.Property(prop => prop.RadiationFractionsCount).HasColumnName("k_fr").IsRequired(false);
        builder.Property(prop => prop.Weight).HasColumnName("wei").IsRequired(false);
        builder.Property(prop => prop.Height).HasColumnName("hei").IsRequired(false);
        builder.Property(prop => prop.BodySurfaceArea).HasColumnName("bsa").IsRequired(false);
    }
}
