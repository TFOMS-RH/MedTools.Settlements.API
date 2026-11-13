using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionProvidedServiceConfiguration : IEntityTypeConfiguration<ProjectionProvidedService>
{
    public void Configure(EntityTypeBuilder<ProjectionProvidedService> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ProvidedServiceUid).HasColumnName("uid");
        builder.Property(prop => prop.ServiceCode).HasColumnName("service_code");
        builder.Property(prop => prop.ServiceName).HasColumnName("service").IsRequired(false);
        builder.Property(prop => prop.MedicalInterventionType).HasColumnName("vid_vme").IsRequired(false);
        builder.Property(prop => prop.MedicalProfileCode).HasColumnName("medical_profile_code");
        builder.Property(prop => prop.MedicalProfile).HasColumnName("medical_profile");
        builder.Property(prop => prop.PhysicianSpecialtyCode).HasColumnName("physician_specialty_code");
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("physician_specialty");
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.ServiceStartDate).HasColumnName("date_in");
        builder.Property(prop => prop.ServiceEndDate).HasColumnName("date_out");
        builder.Property(prop => prop.DiagnosisCode).HasColumnName("ds");
        builder.Property(prop => prop.DiagnosisName).HasColumnName("NAME_DS");
        builder.Property(prop => prop.ServiceQuantity).HasColumnName("kol_usl");
        builder.Property(prop => prop.UnitRate).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.AmountBilled).HasColumnName("sumv_usl");
        builder.Property(prop => prop.InternalComment).HasColumnName("comentu").IsRequired(false);
    }
}
