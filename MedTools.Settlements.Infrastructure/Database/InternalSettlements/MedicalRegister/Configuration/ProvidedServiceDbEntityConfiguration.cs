using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Configuration;

public sealed class ProvidedServiceDbEntityConfiguration : IEntityTypeConfiguration<ProvidedServiceDbEntity>
{
    public void Configure(EntityTypeBuilder<ProvidedServiceDbEntity> builder)
    {
        builder.ToTable("usl").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.ServiceRecordId).HasColumnName("idserv");
        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("lpu");
        builder.Property(prop => prop.Division).HasColumnName("lpu_1");
        builder.Property(prop => prop.DepartmentCode).HasColumnName("podr").IsRequired(false);
        builder.Property(prop => prop.MedicalProfile).HasColumnName("profil").IsRequired(false);
        builder.Property(prop => prop.MedicalInterventionType).HasColumnName("vid_vme").IsRequired(false);
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.ServiceStartDate).HasColumnName("date_in");
        builder.Property(prop => prop.ServiceEndDate).HasColumnName("date_out");
        builder.Property(prop => prop.IsRefusal).HasColumnName("p_otk").IsRequired(false);
        builder.Property(prop => prop.Diagnosis).HasColumnName("ds");
        builder.Property(prop => prop.ServiceCode).HasColumnName("code_usl");
        builder.Property(prop => prop.ServiceQuantity).HasColumnName("kol_usl");
        builder.Property(prop => prop.UnitRate).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.AmountBilled).HasColumnName("sumv_usl");
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("prvs");
        builder.Property(prop => prop.PhysicianCode).HasColumnName("code_md");
        builder.Property(prop => prop.IncompleteVolume).HasColumnName("npl").IsRequired(false);
        builder.Property(prop => prop.InternalComment).HasColumnName("comentu").IsRequired(false);

        builder
            .HasOne(providedService => providedService.MedicalCase)
            .WithMany(medicalCase => medicalCase.ProvidedServices)
            .HasForeignKey(providedService => providedService.MedicalCaseUid);
    }
}