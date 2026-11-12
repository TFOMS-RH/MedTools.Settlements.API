using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionOncologyServiceConfiguration : IEntityTypeConfiguration<ProjectionOncologyService>
{
    public void Configure(EntityTypeBuilder<ProjectionOncologyService> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.OncologyServiceUid).HasColumnName("uid");
        builder.Property(prop => prop.ServiceTypeCode).HasColumnName("service_type_code");
        builder.Property(prop => prop.ServiceType).HasColumnName("service_type");
        builder.Property(prop => prop.SurgicalTreatmentTypeCode).HasColumnName("surgical_treatment_type_code").IsRequired(false);
        builder.Property(prop => prop.SurgicalTreatmentType).HasColumnName("surgical_treatment_type").IsRequired(false);
        builder.Property(prop => prop.DrugTherapyLineCode).HasColumnName("drug_therapy_line_code").IsRequired(false);
        builder.Property(prop => prop.DrugTherapyLine).HasColumnName("drug_therapy_line").IsRequired(false);
        builder.Property(prop => prop.DrugTherapyCycleCode).HasColumnName("drug_therapy_cycle_code").IsRequired(false);
        builder.Property(prop => prop.DrugTherapyCycle).HasColumnName("drug_therapy_cycle").IsRequired(false);
        builder.Property(prop => prop.IsAntiemeticProphylaxis).HasColumnName("pptr").IsRequired(false);
        builder.Property(prop => prop.RadioTherapyTypeCode).HasColumnName("radio_therapy_type_code").IsRequired(false);
        builder.Property(prop => prop.RadiotherapyType).HasColumnName("radio_therapy_type").IsRequired(false);
    }
}
