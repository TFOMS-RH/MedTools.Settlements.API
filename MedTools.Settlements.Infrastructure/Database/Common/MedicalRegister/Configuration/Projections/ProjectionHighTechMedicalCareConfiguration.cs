using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionHighTechMedicalCareConfiguration : IEntityTypeConfiguration<ProjectionHighTechMedicalCare>
{
    public void Configure(EntityTypeBuilder<ProjectionHighTechMedicalCare> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.HighTechCareTypeCode).HasColumnName("high_tech_care_type_code").IsRequired(false);
        builder.Property(prop => prop.HighTechCareTypeName).HasColumnName("HVIDNAME").IsRequired(false);
        builder.Property(prop => prop.HighTechCareMethodCode).HasColumnName("high_tech_care_method_code").IsRequired(false);
        builder.Property(prop => prop.HighTechCareMethodName).HasColumnName("HMNAME").IsRequired(false);
        builder.Property(prop => prop.VoucherIssueDate).HasColumnName("tal_d").IsRequired(false);
        builder.Property(prop => prop.VoucherNumber).HasColumnName("tal_num").IsRequired(false);
        builder.Property(prop => prop.PlannedAdmissionDate).HasColumnName("tal_p").IsRequired(false);
    }
}
