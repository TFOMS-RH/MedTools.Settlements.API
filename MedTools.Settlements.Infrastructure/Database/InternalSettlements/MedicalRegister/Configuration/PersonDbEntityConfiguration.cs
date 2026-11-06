using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class PersonDbEntityConfiguration : IEntityTypeConfiguration<PersonDbEntity>
{
    public void Configure(EntityTypeBuilder<PersonDbEntity> builder)
    {
        builder.ToTable("pers").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.PersonRegistryUid).HasColumnName("pers_list_uid");

        builder.Property(prop => prop.PatientRecordCode).HasColumnName("id_pac");
        builder.Property(prop => prop.PatientLastName).HasColumnName("fam");
        builder.Property(prop => prop.PatientFirstName).HasColumnName("im");
        builder.Property(prop => prop.PatientMiddleName).HasColumnName("ot");
        builder.Property(prop => prop.PatientSex).HasColumnName("w");
        builder.Property(prop => prop.PatientBirthDate).HasColumnName("dr");
        builder.Property(prop => prop.PatientIdentityConfidenceCode).HasColumnName("dost").IsRequired(false);
        builder.Property(prop => prop.PhoneNumber).HasColumnName("tel").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeLastName).HasColumnName("fam_p").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeFirstName).HasColumnName("im_p").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeMiddleName).HasColumnName("ot_p").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeSex).HasColumnName("w_p").IsRequired(false);
        builder.Property(prop => prop.PatientRepresentativeBirthday).HasColumnName("dr_p").IsRequired(false);
        builder.Property(prop => prop.RepresentativeIdentityConfidenceCode).HasColumnName("dost_p").IsRequired(false);
        builder.Property(prop => prop.BirthPlace).HasColumnName("mr").IsRequired(false);
        builder.Property(prop => prop.DocumentTypeCode).HasColumnName("doctype").IsRequired(false);
        builder.Property(prop => prop.DocumentSeries).HasColumnName("docser").IsRequired(false);
        builder.Property(prop => prop.DocumentNumber).HasColumnName("docnum").IsRequired(false);
        builder.Property(prop => prop.Snils).HasColumnName("snils").IsRequired(false);
        builder.Property(prop => prop.ResidenceOkatoCode).HasColumnName("okatog").IsRequired(false);
        builder.Property(prop => prop.TemporaryResidenceOkatoCode).HasColumnName("okatop").IsRequired(false);
        builder.Property(prop => prop.InternalComment).HasColumnName("comentp").IsRequired(false);
        builder.Property(prop => prop.DocumentIssueDate).HasColumnName("docdate").IsRequired(false);
        builder.Property(prop => prop.IssuedBy).HasColumnName("docorg").IsRequired(false);

        builder
            .HasOne(person => person.PersonRegistry)
            .WithMany(personRegistry => personRegistry.Persons)
            .HasForeignKey(person => person.PersonRegistryUid);
    }
}
