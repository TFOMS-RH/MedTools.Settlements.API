using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionConsultationConfiguration : IEntityTypeConfiguration<ProjectionConsultation>
{
    public void Configure(EntityTypeBuilder<ProjectionConsultation> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ConsultationUid).HasColumnName("uid");
        builder.Property(prop => prop.ConsultationPurposeCode).HasColumnName("consultation_purpose_code");
        builder.Property(prop => prop.ConsultationPurpose).HasColumnName("consultation_purpose").IsRequired(false);
        builder.Property(prop => prop.ConsultationDate).HasColumnName("dt_cons").IsRequired(false);
    }
}
