using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Enums;
using Common.Exceptions;
using Common.Models.Filters;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Http;
using UMIS.BLL.AppServices._Base;
using UMIS.BLL.AppServices.Helpers;
using UMIS.BLL.Contracts.Models.Common;
using UMIS.BLL.Contracts.Models.Views.Common;
using UMIS.BLL.Contracts.ServicesAbstraction.Common;
using UMIS.DAL.Domain.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Common;

namespace UMIS.BLL.AppServices.Common
{
    /// <summary>
    /// Менеджер для работы с пациетами
    /// </summary>
    public class PatientManager : BaseManager, IPatientManager
    {
        protected readonly IPatientRepository _patientRepository;

        /// <summary>
        /// Констуктор
        /// </summary>
        public PatientManager(IHttpContextAccessor httpContextAccessor
            , IMapper mapper
            , IPatientRepository patientRepository) : base(httpContextAccessor, mapper)
        {
            _patientRepository = patientRepository;
        }

        /// <inheritdoc />
        public async Task EditPatientAsync(PatientDto patientDto)
        {
            if (patientDto == null)
            {
                throw new ArgumentNullException($"{Messages.Exception_IncorrectData} - {nameof(patientDto)}");
            }

            Patient domainPatient = await _patientRepository.GetAsync(patientDto.Id);
            domainPatient.FillFrom(patientDto);
            await _patientRepository.UpdateAndSaveAsync(domainPatient);

        }

        /// <inheritdoc />
        public async Task<PatientForViewDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetWithRelationshipAsync(id);

            if (patient == null)
            {
                throw new EntityNotFoundException(
                    string.Format(Messages.Exception_EntityNotFoundTemplate, Messages.Entity_Patient, id),
                    id,
                    EntityTypeEnum.Patient);
            }

            return Mapper.Map<PatientForViewDto>(patient);
        }

        /// <inheritdoc />
        public async Task<PaginationResult<PatientForViewDto>> GetPatientsByFilterAsync(BaseFilter filter)
        {
            PaginationResult<Patient> domainResult = await _patientRepository.GetPaginationByBaseFilterAsync(filter);

            return new PaginationResult<PatientForViewDto>()
            {
                CurrentPage = domainResult.CurrentPage,
                Items = Mapper.Map<List<PatientForViewDto>>(domainResult.Items),
                TotalPages = domainResult.TotalPages,
                TotalRecords = domainResult.TotalRecords
            };
        }

        /// <inheritdoc />
        public async Task<int> RegisterPatientAsync(PatientDto patient)
        {
            var domainPatient = await _patientRepository
                .AddAndSaveAsync(Mapper.Map<Patient>(patient));

            return domainPatient.Id;
        }
    }
}
