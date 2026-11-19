using Microsoft.EntityFrameworkCore;

using MedTools.Settlements.Application.Models.Filters.MedicalRegister;

using MedTools.Settlements.Infrastructure.Common;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Proxy;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Services.Builders;

public sealed class FilteredMedicalRegisterQueryBuilder
{
    public static IQueryable<CompletedCasePersonJoin> Build(
        MedicalRegisterAppliedFilters appliedFilters,
        MedicalRegisterDbContextBase dbContextBase)
    {
        var query = dbContextBase.Set<CompletedCaseDbEntity>()
            .AsNoTracking()
            .Join(
                dbContextBase.Set<PersonDbEntity>(),
                completedCase => new
                {
                    Registry = completedCase
                        .MedicalRecord
                        .MedicalRegistry
                        .MedicalRegistryHeading
                        .Filename,

                    Patient = completedCase
                        .MedicalRecord
                        .Patient
                        .PatientRecordCode
                },
                person => new
                {
                    Registry = person
                        .PersonRegistry
                        .PersonRegistryHeading
                        .MedicalRegistryFilename,

                    Patient = person.PatientRecordCode
                },
                (completedCase, person) => new CompletedCasePersonJoin
                {
                    CompletedCase = completedCase,
                    Person = person
                });

        query = query.BuildWithPersonFilters(appliedFilters.Person);
        query = query.BuildWithMedicalCaseDetailsFilters(appliedFilters.MedicalCaseDetails);
        query = query.BuildWithOncologyFilters(appliedFilters.Oncology);
        query = query.BuildWithPrescriptionFilters(appliedFilters.Prescription);
        query = query.BuildWithClinicalGroupFilters(appliedFilters.ClinicalGroup);
        query = query.BuildWithProvidedServiceFilters(appliedFilters.ProvidedService);
        query = query.BuildWithSanctionFilters(appliedFilters.Sanction);
        query = query.BuildWithDiseaseFilters(appliedFilters.Diseases);
        query = query.BuildWithInternalFilters(appliedFilters.InternalService);

        return query;
    }

}
