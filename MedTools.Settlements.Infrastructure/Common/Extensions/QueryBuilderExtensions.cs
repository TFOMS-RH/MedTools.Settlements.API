using MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;
using MedTools.Settlements.Infrastructure.Common.Models;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Proxy;

namespace MedTools.Settlements.Infrastructure.Common.Extensions;

public static class QueryBuilderExtensions
{
    public static IQueryable<CompletedCasePersonJoin> BuildWithPersonFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        PersonFilters filters)
    {
        if (!string.IsNullOrWhiteSpace(filters.Patient.FirstName))
        {
            query = query.Where(
                x => x.Person.PatientFirstName
                    .StartsWith(filters.Patient.FirstName));
        }

        if (!string.IsNullOrWhiteSpace(filters.Patient.LastName))
        {
            query = query.Where(
                x => x.Person.PatientLastName
                    .StartsWith(filters.Patient.LastName));
        }

        if (!string.IsNullOrWhiteSpace(filters.Patient.MiddleName))
        {
            query = query.Where(
                x => x.Person.PatientMiddleName
                    .StartsWith(filters.Patient.MiddleName));
        }

        if (filters.Patient.BirthDate is not null)
        {
            query = query.Where(
                x => x.Person.PatientBirthDate == filters.Patient.BirthDate);
        }

        if (filters.Patient.Sex is Core.Enums.Sex patientSex)
        {
            var sexValue = (byte)patientSex;

            query = query.Where(
                x => x.Person.PatientSex == sexValue);
        }

        if (!string.IsNullOrWhiteSpace(filters.Representative.FirstName))
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeFirstName != null &&
                    x.Person.PatientRepresentativeFirstName
                        .StartsWith(filters.Representative.FirstName));
        }

        if (!string.IsNullOrWhiteSpace(filters.Representative.LastName))
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeLastName != null &&
                    x.Person.PatientRepresentativeLastName
                        .StartsWith(filters.Representative.LastName));
        }

        if (!string.IsNullOrWhiteSpace(filters.Representative.MiddleName))
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeMiddleName != null &&
                x.Person.PatientRepresentativeMiddleName
                    .StartsWith(filters.Representative.MiddleName));
        }

        if (filters.Representative.BirthDate is not null)
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeBirthday == filters.Representative.BirthDate);
        }

        if (filters.Representative.Sex is Core.Enums.Sex representativeSex)
        {
            var sexValue = (byte)representativeSex;

            query = query.Where(
                x => x.Person.PatientRepresentativeSex == sexValue);
        }

        if (filters.Insurance.Insurances.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsuranceCompanyCode != null
                && filters.Insurance.Insurances
                    .Contains(x.CompletedCase.MedicalRecord.Patient.InsuranceCompanyCode));
        }

        if (filters.Insurance.InsurancePolicyTypes.Count > 0)
        {
            query = query.Where(
                x => filters.Insurance.InsurancePolicyTypes
                    .Contains(x.CompletedCase.MedicalRecord.Patient.InsurancePolicyType.ToString()));
        }

        if (!string.IsNullOrWhiteSpace(filters.Insurance.InsurancePolicySeries))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsurancePolicySeries == filters.Insurance.InsurancePolicySeries);
        }

        if (filters.Insurance.InsurancePolicyNumbers.Count > 0)
        {
            query = query.Where(
                x => filters.Insurance.InsurancePolicyNumbers
                    .Contains(x.CompletedCase.MedicalRecord.Patient.InsurancePolicyNumber));
        }

        if (filters.Insurance.UnifiedPolicyNumbers.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsurancePolicyUnifiedNumber != null
                    && filters.Insurance.UnifiedPolicyNumbers
                        .Contains(x.CompletedCase.MedicalRecord.Patient.InsurancePolicyUnifiedNumber));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithMedicalCaseDetailsFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        MedicalCaseDetailsFilters filters)
    {
        if (filters.BaseMedicalCaseDetails.MedicalProfiles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => filters.BaseMedicalCaseDetails.MedicalProfiles
                        .Contains(medicalCase.MedicalProfile)));
        }

        if (filters.BaseMedicalCaseDetails.BedProfiles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.BedProfile.HasValue &&
                    filters.BaseMedicalCaseDetails.BedProfiles
                        .Contains(medicalCase.BedProfile.Value)));
        }

        if (!string.IsNullOrWhiteSpace(filters.BaseMedicalCaseDetails.Division))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Division == filters.BaseMedicalCaseDetails.Division));
        }

        if (filters.BaseMedicalCaseDetails.EncounterMedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.EncounterMoCode != null &&
                    filters.BaseMedicalCaseDetails.EncounterMedicalOrganizations
                        .Contains(medicalCase.EncounterMoCode)));
        }

        if (filters.BaseMedicalCaseDetails.VisitPurposes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.VisitPurpose != null &&
                    filters.BaseMedicalCaseDetails.VisitPurposes
                        .Contains(medicalCase.VisitPurpose)));
        }

        if (filters.BaseMedicalCaseDetails.PreventiveCarePlaces.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.PreventiveCareMoCode.HasValue &&
                    filters.BaseMedicalCaseDetails.PreventiveCarePlaces
                        .Contains(medicalCase.PreventiveCareMoCode.Value)));
        }

        if (filters.BaseMedicalCaseDetails.TreatmentStartDate is not null)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.TreatmentStartDate == filters.BaseMedicalCaseDetails.TreatmentStartDate));
        }

        if (filters.BaseMedicalCaseDetails.TreatmentEndDate is not null)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.TreatmentEndDate == filters.BaseMedicalCaseDetails.TreatmentEndDate));
        }

        if (!string.IsNullOrWhiteSpace(filters.BaseMedicalCaseDetails.MedicalRecordNumber))
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.MedicalRecordNumber == filters.BaseMedicalCaseDetails.MedicalRecordNumber));
        }

        if (filters.BaseMedicalCaseDetails.DiseaseCharacters.Count > 0)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.DiseaseCharacter.HasValue &&
                filters.BaseMedicalCaseDetails.DiseaseCharacters
                    .Contains(medicalCase.DiseaseCharacter.Value)));
        }

        if (filters.BaseMedicalCaseDetails.PhysicianSpecialties.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => filters.BaseMedicalCaseDetails.PhysicianSpecialties
                        .Contains(medicalCase.PhysicianSpecialty)));
        }


        if (filters.CompletedCaseDetails.CareConditions.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.CareConditions.Contains(
                    x.CompletedCase.CareCondition));
        }

        if (filters.CompletedCaseDetails.CareForms.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.CareForms
                    .Contains(x.CompletedCase.CareForm));
        }

        if (filters.CompletedCaseDetails.MedicalCareTypes.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.MedicalCareTypes
                    .Contains(x.CompletedCase.MedicalCareType));
        }

        if (filters.CompletedCaseDetails.MedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.MedicalOrganizations
                    .Contains(x.CompletedCase.MedicalOrganizationCode));
        }

        if (filters.CompletedCaseDetails.ReferringMedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.ReferringMedicalOrganizationCode != null &&
                filters.CompletedCaseDetails.ReferringMedicalOrganizations
                    .Contains(x.CompletedCase.ReferringMedicalOrganizationCode));
        }

        if (filters.CompletedCaseDetails.TreatmentStartDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.TreatmentStartDate == filters.CompletedCaseDetails.TreatmentStartDate);
        }

        if (filters.CompletedCaseDetails.TreatmentEndDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.TreatmentEndDate == filters.CompletedCaseDetails.TreatmentEndDate);
        }

        if (filters.CompletedCaseDetails.DiseaseOutcomes.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.DiseaseOutcomes
                    .Contains(x.CompletedCase.DiseaseOutcome));
        }

        if (filters.CompletedCaseDetails.ScreeningResults.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.ScreeningResult.HasValue
                && filters.CompletedCaseDetails.ScreeningResults
                    .Contains(x.CompletedCase.ScreeningResult.Value));
        }

        if (filters.CompletedCaseDetails.HospitalizationOutcomes.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.HospitalizationOutcomes
                    .Contains(x.CompletedCase.HospitalizationOutcome));
        }

        if (filters.CompletedCaseDetails.PaymentMethods.Count > 0)
        {
            query = query.Where(
                x => filters.CompletedCaseDetails.PaymentMethods
                    .Contains(x.CompletedCase.PaymentMethodCode));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithOncologyFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        OncologyFilters filters,
        ResolvedMedicalRegisterFilters resolvedFilters)
    {
        if (filters.OncologyCase.Stages.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.Stage.HasValue &&
                    resolvedFilters.DiseaseStageKeys.Contains(
                        medicalCase.OncologyCase.Stage.Value)));
        }

        if (filters.OncologyCase.ReferralReasons.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.ReferralReasonCode.HasValue &&
                    filters.OncologyCase.ReferralReasons
                        .Contains(medicalCase.OncologyCase.ReferralReasonCode.Value)));
        }

        if (filters.OncologyService.ServiceTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => filters.OncologyService.ServiceTypes.Contains(
                            oncologyService.ServiceTypeCode))));
        }

        if (filters.OncologyService.SurgicalTreatmentTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.SurgicalTreatmentTypeCode.HasValue
                        && filters.OncologyService.SurgicalTreatmentTypes.Contains(
                            oncologyService.SurgicalTreatmentTypeCode.Value))));
        }

        if (filters.OncologyService.RadioTherapyTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.RadioTherapyTypeCode.HasValue
                        && filters.OncologyService.RadioTherapyTypes.Contains(
                            oncologyService.RadioTherapyTypeCode.Value))));
        }

        if (filters.OncologyService.DrugTherapyCycles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.DrugTherapyCycleCode.HasValue
                        && filters.OncologyService.DrugTherapyCycles.Contains(
                            oncologyService.DrugTherapyCycleCode.Value))));
        }

        if (filters.OncologyService.DrugTherapyLines.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.DrugTherapyLineCode.HasValue &&
                        filters.OncologyService.DrugTherapyLines
                            .Contains(oncologyService.DrugTherapyLineCode.Value))));
        }


        if (filters.Medication.DrugIdentifiers.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.Medications.Any(
                            medication => medication.DrugIdentifier != null
                            && filters.Medication.DrugIdentifiers.Contains(medication.DrugIdentifier)))));
        }

        if (filters.Medication.TherapyRegimens.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.Medications.Any(
                            medication => medication.TherapyRegimenCode != null
                            && filters.Medication.TherapyRegimens.Contains(medication.TherapyRegimenCode)))));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithPrescriptionFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        PrescriptionFilters filters)
    {
        if (filters.BasePrescription.PrescriptionTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => filters.BasePrescription.PrescriptionTypes
                            .Contains(prescription.PrescriptionType))));
        }

        if (filters.BasePrescription.DiagnosticMethods.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => prescription.DiagnosticMethod.HasValue &&
                        filters.BasePrescription.DiagnosticMethods
                            .Contains(prescription.DiagnosticMethod.Value))));
        }

        if (filters.BasePrescription.ReferralDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => prescription.ReferralDate != null &&
                        prescription.ReferralDate == filters.BasePrescription.ReferralDate)));
        }

        if (filters.BasePrescription.ReferredToMedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => prescription.ReferredToMoCode != null &&
                        filters.BasePrescription.ReferredToMedicalOrganizations
                            .Contains(prescription.ReferredToMoCode))));
        }

        if (filters.BasePrescription.MedicalCareProfiles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => prescription.MedicalCareProfile.HasValue &&
                        filters.BasePrescription.MedicalCareProfiles
                            .Contains(prescription.MedicalCareProfile.Value))));
        }

        if (filters.BasePrescription.BedProfiles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => prescription.BedProfile != null &&
                        filters.BasePrescription.BedProfiles
                            .Contains(prescription.BedProfile))));
        }

        if (filters.BasePrescription.Services.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Prescriptions.Any(
                        prescription => prescription.ServiceCode != null &&
                        filters.BasePrescription.Services
                            .Contains(prescription.ServiceCode))));
        }


        if (filters.Referral.ReferralTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Referrals.Any(
                        referral => filters.Referral.ReferralTypes
                            .Contains(referral.ReferralType))));
        }

        if (filters.Referral.DiagnosticMethods.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Referrals.Any(
                        referral => referral.DiagnosticMethod.HasValue &&
                        filters.Referral.DiagnosticMethods
                            .Contains(referral.DiagnosticMethod.Value))));
        }

        if (filters.Referral.ReferralDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Referrals.Any(
                        referral => referral.ReferralDate == filters.Referral.ReferralDate)));
        }

        if (filters.Referral.ReferredToMedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Referrals.Any(
                        referral => referral.ReferredToMoCode != null &&
                        filters.Referral.ReferredToMedicalOrganizations
                            .Contains(referral.ReferredToMoCode))));
        }

        if (filters.Referral.ReferredServices.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Referrals.Any(
                        prescription => prescription.ReferredServiceCode != null &&
                        filters.Referral.ReferredServices
                            .Contains(prescription.ReferredServiceCode))));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithClinicalGroupFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        ClinicalGroupFilters filters)
    {
        if (filters.BaseClinicalGroup.ClinicalStatisticGroupNumbers.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => filters.BaseClinicalGroup.ClinicalStatisticGroupNumbers
                        .Contains(medicalCase.ClinicalGroup.ClinicalStatisticGroupNumber)));
        }

        if (filters.BaseClinicalGroup.ComplexityCoefficientNumbers.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.ClinicalGroup.TreatmentComplexityCoefficients.Any(
                        coefficient => coefficient.ComplexityCoefficientNumber != null &&
                        filters.BaseClinicalGroup.ComplexityCoefficientNumbers
                            .Contains(coefficient.ComplexityCoefficientNumber))));
        }

        if (filters.BaseClinicalGroup.InterruptedCasePaymentReasons.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.ClinicalGroup.InterruptedCasePaymentReason != null &&
                    filters.BaseClinicalGroup.InterruptedCasePaymentReasons
                        .Contains(medicalCase.ClinicalGroup.InterruptedCasePaymentReason)));
        }


        if (filters.HighTechMedicalCare.HighTechCareTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.HighTechCareType != null &&
                    filters.HighTechMedicalCare.HighTechCareTypes
                        .Contains(medicalCase.HighTechCareType)));
        }

        if (filters.HighTechMedicalCare.HighTechCareMethods.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.HighTechCareMethod != null &&
                    filters.HighTechMedicalCare.HighTechCareMethods
                        .Contains(medicalCase.HighTechCareMethod)));
        }

        if (filters.HighTechMedicalCare.VoucherIssueDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.VoucherIssueDate == filters.HighTechMedicalCare.VoucherIssueDate));
        }

        if (!string.IsNullOrWhiteSpace(filters.HighTechMedicalCare.VoucherNumber))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.VoucherNumber != null &&
                    medicalCase.VoucherNumber == filters.HighTechMedicalCare.VoucherNumber));
        }

        if (filters.HighTechMedicalCare.PlannedAdmissionDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.PlannedAdmissionDate == filters.HighTechMedicalCare.PlannedAdmissionDate));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithProvidedServiceFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        ProvidedServiceFilters filters)
    {

        if (filters.ProvidedServices.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.ProvidedServices.Any(
                        providedService => filters.ProvidedServices.Contains(providedService.ServiceCode))));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithSanctionFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        SanctionFilters filters)
    {
        if (filters.ControlTypeCodes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Sanctions.Any(
                        sanction => filters.ControlTypeCodes
                            .Contains(sanction.ControlTypeCode))));
        }

        if (filters.RefusalReasons.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Sanctions.Any(
                        sanction => filters.RefusalReasons
                            .Contains(sanction.RefusalReasonCode))));
        }

        if (!string.IsNullOrWhiteSpace(filters.ExpertiseActNumber))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Sanctions.Any(
                        sanction => sanction.ExpertiseActNumber == filters.ExpertiseActNumber)));
        }

        if (filters.ExpertiseActDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Sanctions.Any(
                        sanction => sanction.ExpertiseActDate == filters.ExpertiseActDate)));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithDiseaseFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        DiseaseFilters filters,
        ResolvedMedicalRegisterFilters resolvedFilters)
    {
        if (filters.BaseDisease.DiagnosisClasses.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => resolvedFilters.DiseasesByClassUids
                        .Contains(medicalCase.PrimaryDiagnosis)));
        }

        if (filters.BaseDisease.DiagnosisSubClasses.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => resolvedFilters.DiseasesBySubClassUids
                        .Contains(medicalCase.PrimaryDiagnosis)));
        }

        if (filters.BaseDisease.PrimaryDiagnoses.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => filters.BaseDisease.PrimaryDiagnoses
                        .Contains(medicalCase.PrimaryDiagnosis)));
        }

        if (filters.AdditionalDisease.InitialDiagnoses.Count > 0)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.InitialDiagnosis != null &&
                filters.AdditionalDisease.InitialDiagnoses
                    .Contains(medicalCase.InitialDiagnosis)));
        }

        if (filters.AdditionalDisease.ConcomitantDiagnoses.Count > 0)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.ConcomitantDiagnoses.Any(
                    concomitantDiagnosis => filters.AdditionalDisease.ConcomitantDiagnoses
                        .Contains(concomitantDiagnosis.DiagnosisName))));
        }

        if (filters.AdditionalDisease.ComplicationDiagnoses.Count > 0)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.ComplicationDiagnoses.Any(
                    complicationDiagnosis => filters.AdditionalDisease.ComplicationDiagnoses
                        .Contains(complicationDiagnosis.DiagnosisName))));
        }

        return query;
    }

    public static IQueryable<CompletedCasePersonJoin> BuildWithInternalFilters(
        this IQueryable<CompletedCasePersonJoin> query,
        InternalServiceFilters filters)
    {
        if (!string.IsNullOrWhiteSpace(filters.PatientUid) &&
            Int32.TryParse(filters.PatientUid, out int patientUid))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.Uid == patientUid);
        }

        if (!string.IsNullOrWhiteSpace(filters.MedicalCaseUid) &&
            Int32.TryParse(filters.MedicalCaseUid, out int medicalCaseUid))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Uid == medicalCaseUid));
        }

        if (!string.IsNullOrWhiteSpace(filters.CompletedCaseUid) &&
            Int32.TryParse(filters.CompletedCaseUid, out int completedCaseUid))
        {
            query = query.Where(
                x => x.CompletedCase.Uid == completedCaseUid);
        }

        if (!string.IsNullOrWhiteSpace(filters.InvoiceUid) &&
            Int32.TryParse(filters.InvoiceUid, out int invoiceUid))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.MedicalRegistry.Invoice.Uid == invoiceUid);
        }

        if (!string.IsNullOrEmpty(filters.InvoiceNumber))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.MedicalRegistry.Invoice.InvoiceNumber == filters.InvoiceNumber);
        }

        if (!string.IsNullOrEmpty(filters.InvoiceBillingMonth) &&
            Byte.TryParse(filters.InvoiceBillingMonth, out var billingMonth))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.MedicalRegistry.Invoice.BillingMonth == billingMonth);
        }

        if (!string.IsNullOrWhiteSpace(filters.InvoiceBillingYear) &&
            Int32.TryParse(filters.InvoiceBillingYear, out int billingYear))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.MedicalRegistry.Invoice.BillingYear == billingYear);
        }

        return query;
    }
}
