using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration.Elements;

public sealed class ProvidedServiceDbEntityConfiguration : IEntityTypeConfiguration<ProvidedServiceDbEntity>
{
    public void Configure(EntityTypeBuilder<ProvidedServiceDbEntity> builder)
    {
        builder.ToTable("usl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid)
            .HasColumnName("uid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(prop => prop.MedicalCaseUid)
            .HasColumnName("sluch_uid")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.ServiceRecordId)
            .HasColumnName("idserv")
            .HasMaxLength(36)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.MedicalOrganizationCode)
            .HasColumnName("lpu")
            .HasMaxLength(6)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.Division)
            .HasColumnName("lpu_1")
            .HasMaxLength(17)
            .IsUnicode(true)
            .IsRequired();

        builder.Property(prop => prop.DepartmentCode)
            .HasColumnName("podr")
            .HasColumnType("bigint")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalProfile)
            .HasColumnName("profil")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(prop => prop.MedicalInterventionType)
            .HasColumnName("vid_vme")
            .HasMaxLength(15)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(prop => prop.IsPediatric)
            .HasColumnName("det")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(prop => prop.ServiceStartDate)
            .HasColumnName("date_in")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.ServiceEndDate)
            .HasColumnName("date_out")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(prop => prop.IsRefusal)
            .HasColumnName("p_otk")
            .HasColumnType("tinyint")
            .IsRequired(false);

        builder.Property(prop => prop.Diagnosis)
            .HasColumnName("ds")
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.ServiceCode)
            .HasColumnName("code_usl")
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.ServiceQuantity)
            .HasColumnName("kol_usl")
            .HasColumnType("smallmoney")
            .IsRequired();

        builder.Property(prop => prop.UnitRate)
            .HasColumnName("tarif")
            .HasColumnType("money")
            .IsRequired(false);

        builder.Property(prop => prop.AmountBilled)
            .HasColumnName("sumv_usl")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(prop => prop.PhysicianSpecialty)
            .HasColumnName("prvs")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(prop => prop.PhysicianCode)
            .HasColumnName("code_md")
            .HasMaxLength(25)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(prop => prop.IncompleteVolume)
            .HasColumnName("npl")
            .HasColumnType("smallint")
            .IsRequired(false);

        builder.Property(prop => prop.InternalComment)
            .HasColumnName("comentu")
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired(false);

        builder
            .HasOne(providedService => providedService.MedicalCase)
            .WithMany(medicalCase => medicalCase.ProvidedServices)
            .HasForeignKey(providedService => providedService.MedicalCaseUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}