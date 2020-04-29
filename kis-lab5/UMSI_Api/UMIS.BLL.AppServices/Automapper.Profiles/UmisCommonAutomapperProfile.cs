using AutoMapper;
using UMIS.BLL.Contracts.Models.Common;
using UMIS.BLL.Contracts.Models.Common.Catalogs;
using UMIS.BLL.Contracts.Models.Common.Catalogs.RelationsEntityDto;
using UMIS.BLL.Contracts.Models.Views.Common;
using UMIS.BLL.Contracts.Models.Views.Common.Catalogs;
using UMIS.DAL.Domain.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs;
using UMIS.DAL.Domain.Contracts.Models.Common.Catalogs.RelationsEntityModels;

namespace UMIS.BLL.AppServices.Automapper.Profiles
{
    public class UmisCommonAutomapperProfile : Profile
    {
        public UmisCommonAutomapperProfile()
        {
            CreateMap<PatientDto, Patient>()
                .ReverseMap();
            CreateMap<DisabilityDescriptionDto, DisabilityDescription>()
                .ReverseMap();
            CreateMap<WorkHistoryDto, WorkHistory>()
                .ReverseMap();
            CreateMap<AllergyAnamnesisDto, AllergyAnamnesis>()
                .ReverseMap();

            CreateMap<MedicalHistoryDto, MedicalHistory>()
                .ReverseMap();
            CreateMap<MediacalAnamnesisDto, MediacalAnamnesis>()
                .ReverseMap();
            CreateMap<PhysiologicalIndicationDto, PhysiologicalIndication>()
                .ReverseMap();
            CreateMap<MedicalExaminationDto, MedicalExamination>()
                .ReverseMap();
            CreateMap<PhysicalExaminationDto, PhysicalExamination>()
                .ReverseMap();
            CreateMap<DiagnosisDto, Diagnosis>()
                .ReverseMap();
            CreateMap<MedicalHistoryNoteDto, MedicalHistoryNote>()
                .ReverseMap();
            CreateMap<AssignmentDto, Assignment>()
                .ReverseMap();

            CreateMap<MedicalTestResultDto, MedicalTestResult>()
                .ReverseMap();

            CreateMap<CatalogToCatalogFieldDto, CatalogToCatalogField>()
                .ReverseMap();
            CreateMap<CatalogDto, Catalog>()
                .ReverseMap();
            CreateMap<CatalogFieldDto, CatalogField>()
                .ReverseMap();
            CreateMap<CatalogTypeDto, CatalogType>()
                .ReverseMap();
            CreateMap<CatalogFieldValueDto, CatalogFieldValue>()
                .ReverseMap();

            CreateMap<Patient, PatientForViewDto>();

            CreateMap<MedicalHistory, MedicalHistoryForViewDto>();

            CreateMap<CatalogFieldValueDto, CatalogFieldValueForViewDto>()
                .ForMember(d => d.CatalogName, opt => opt.MapFrom(s => s.CatalogToCatalogField.Catalog.Name))
                .ForMember(d => d.CatalogTypeName, opt => opt.MapFrom(s => s.CatalogToCatalogField.Catalog.CatalogType.Name))
                .ForMember(d => d.DataType, opt => opt.MapFrom(s => s.CatalogToCatalogField.CatalogField.DataType))
                .ForMember(d => d.DefaultValue, opt => opt.MapFrom(s => s.CatalogToCatalogField.DefaultValue))
                .ForMember(d => d.DefaultValue2, opt => opt.MapFrom(s => s.CatalogToCatalogField.DefaultValue2))
                .ForMember(d => d.FieldName, opt => opt.MapFrom(s => s.CatalogToCatalogField.CatalogField.Name))
                .ForMember(d => d.Units, opt => opt.MapFrom(s => s.CatalogToCatalogField.Units));
        }
    }
}
