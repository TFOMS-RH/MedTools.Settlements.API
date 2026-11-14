using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionReferralConfiguration : IEntityTypeConfiguration<ProjectionReferral>
{
    public void Configure(EntityTypeBuilder<ProjectionReferral> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ReferralUid).HasColumnName("uid");
        builder.Property(prop => prop.ReferralDate).HasColumnName("napr_date");
        builder.Property(prop => prop.ReferredToMoCode).HasColumnName("napr_mo").IsRequired(false);
        builder.Property(prop => prop.ReferralTypeCode).HasColumnName("referral_type_code");
        builder.Property(prop => prop.ReferralType).HasColumnName("referral_type");
        builder.Property(prop => prop.DiagnosticMethodCode).HasColumnName("diagnostic_method_code").IsRequired(false);
        builder.Property(prop => prop.DiagnosticMethod).HasColumnName("diagnostic_method").IsRequired(false);
        builder.Property(prop => prop.ReferredServiceCode).HasColumnName("referred_service_code").IsRequired(false);
        builder.Property(prop => prop.ReferredService).HasColumnName("referred_service").IsRequired(false);
    }
}
