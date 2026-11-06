using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class PersonDbEntityConfiguration : IEntityTypeConfiguration<PersonDbEntity>
{
    public void Configure(EntityTypeBuilder<PersonDbEntity> builder)
    {
        builder.ToTable("dbo.pers").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.PersonRegistryUid)
            .HasColumnName("pers_list_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.PatientRecordCode)
            .HasColumnName("id_pac")
            .HasMaxLength(36)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PatientLastName)
            .HasColumnName("fam")
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PatientFirstName)
            .HasColumnName("im")
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PatientMiddleName)
            .HasColumnName("ot")
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.PatientSex)
            .HasColumnName("w")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.PatientBirthDate)
            .HasColumnName("dr")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.PatientIdentityConfidenceCode)
            .HasColumnName("dost")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.PhoneNumber)
            .HasColumnName("tel")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.PatientRepresentativeLastName)
            .HasColumnName("fam_p")
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.PatientRepresentativeFirstName)
            .HasColumnName("im_p")
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.PatientRepresentativeMiddleName)
            .HasColumnName("ot_p")
            .HasMaxLength(40)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.PatientRepresentativeSex)
            .HasColumnName("w_p")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.PatientRepresentativeBirthday)
            .HasColumnName("dr_p")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.RepresentativeIdentityConfidenceCode)
            .HasColumnName("dost_p")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.BirthPlace)
            .HasColumnName("mr")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.DocumentTypeCode)
            .HasColumnName("doctype")
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.DocumentSeries)
            .HasColumnName("docser")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.DocumentNumber)
            .HasColumnName("docnum")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.Snils)
            .HasColumnName("snils")
            .HasMaxLength(14)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.ResidenceOkatoCode)
            .HasColumnName("okatog")
            .HasMaxLength(11)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.TemporaryResidenceOkatoCode)
            .HasColumnName("okatop")
            .HasMaxLength(11)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.InternalComment)
            .HasColumnName("comentp")
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.DocumentIssueDate)
            .HasColumnName("docdate")
            .HasColumnType("smalldatetime")
            .IsRequired(false);

        builder.Property(prop => prop.IssuedBy)
            .HasColumnName("docorg")
            .HasMaxLength(1000)
            .IsUnicode(true)
            .IsRequired(false);

        builder
            .HasOne(person => person.PersonRegistry)
            .WithMany(personRegistry => personRegistry.Persons)
            .HasForeignKey(person => person.PersonRegistryUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}