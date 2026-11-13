using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionPrescriptionConfiguration : IEntityTypeConfiguration<ProjectionPrescription>
{
    public void Configure(EntityTypeBuilder<ProjectionPrescription> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.PerscriptionUid).HasColumnName("uid");
        builder.Property(prop => prop.SequenceNumber).HasColumnName("naz_n");
        builder.Property(prop => prop.PrescriptionTypeCode).HasColumnName("prescription_type_code");
        builder.Property(prop => prop.PrescriptionType).HasColumnName("prescription_type");
        builder.Property(prop => prop.PhysicianSpecialtyCode).HasColumnName("naz_sp");
        builder.Property(prop => prop.DiagnosticMethodCode).HasColumnName("diagnostic_method_code");
        builder.Property(prop => prop.DiagnosticMethod).HasColumnName("diagnostic_method");
        builder.Property(prop => prop.ServiceCode).HasColumnName("naz_usl");
        builder.Property(prop => prop.MedicalCareProfile).HasColumnName("naz_pmp");
        builder.Property(prop => prop.BedProfile).HasColumnName("naz_pk");
        builder.Property(prop => prop.ReferralDate).HasColumnName("napr_date");
        builder.Property(prop => prop.ReferredToMoCode).HasColumnName("napr_mo");
    }
}
