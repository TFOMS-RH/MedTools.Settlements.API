using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Projections;

public sealed class ProjectionPatientConfiguration : IEntityTypeConfiguration<ProjectionPatient>
{
    public void Configure(EntityTypeBuilder<ProjectionPatient> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.PatientLastName).HasColumnName("patient_last_name");
        builder.Property(prop => prop.PatientFirstName).HasColumnName("patient_first_name");
        builder.Property(prop => prop.PatientMiddleName).HasColumnName("patient_middle_name");
        builder.Property(prop => prop.PatientBirthDate).HasColumnName("patient_birthday");
        builder.Property(prop => prop.PatientSex).HasColumnName("patient_sex");
        builder.Property(prop => prop.DocumentTypeName).HasColumnName("document_type_name");
        builder.Property(prop => prop.DocumentTypeCode).HasColumnName("document_type_code").IsRequired(false);
        builder.Property(prop => prop.DocumentSeries).HasColumnName("document_series").IsRequired(false);
        builder.Property(prop => prop.DocumentNumber).HasColumnName("document_number").IsRequired(false);
        builder.Property(prop => prop.DocumentIssueDate).HasColumnName("document_issue_date").IsRequired(false);
        builder.Property(prop => prop.IssuedBy).HasColumnName("issued_by").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeLastName).HasColumnName("patient_representative_last_name").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeFirstName).HasColumnName("patient_representative_first_name").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeMiddleName).HasColumnName("patient_representative_middle_name").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeBirthday).HasColumnName("patient_representative_birthday").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeSex).HasColumnName("representative_sex").IsRequired(false);
    }
}
