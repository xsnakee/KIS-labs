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
using UMIS.BLL.Contracts.Models.Common;
using UMIS.BLL.Contracts.Models.Views.Common;
using UMIS.BLL.Contracts.ServicesAbstraction.Common;
using UMIS.DAL.Domain.Contracts.Models.Common;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Common;

namespace UMIS.BLL.AppServices.Common
{
    public class MedicalHistoryManager : BaseManager, IMedicalHistoryManager
    {
        protected readonly IMedicalHistoryRepository _medicalHistoryRepository;

        /// <summary>
        /// Констуктор
        /// </summary>
        public MedicalHistoryManager(IHttpContextAccessor httpContextAccessor
            , IMapper mapper
            , IMedicalHistoryRepository medicalHistoryRepository) : base(httpContextAccessor, mapper)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        /// <inheritdoc />
        public async Task<int> CreateMedicalHistoryAsync(MedicalHistoryDto medicalHistory)
        {
            var domainMedicalHistory = await _medicalHistoryRepository.AddAndSaveAsync(Mapper.Map<MedicalHistory>(medicalHistory));

            return domainMedicalHistory.Id;
        }

        public async Task<PaginationResult<MedicalHistoryForViewDto>> GetMedicalHistoriesByFilterAsync(BaseFilter filter)
        {
            PaginationResult<MedicalHistory> domainResult = await _medicalHistoryRepository.GetPaginationByBaseFilterAsync(filter);

            return new PaginationResult<MedicalHistoryForViewDto>()
            {
                CurrentPage = domainResult.CurrentPage,
                Items = Mapper.Map<List<MedicalHistoryForViewDto>>(domainResult.Items),
                TotalPages = domainResult.TotalPages,
                TotalRecords = domainResult.TotalRecords
            };
        }

        /// <inheritdoc />
        public async Task<MedicalHistoryForViewDto> GetMedicalHistoryByIdAsync(int id)
        {
            var medicalHistory = await _medicalHistoryRepository.GetAsync(id);

            if (medicalHistory == null)
            {
                throw new EntityNotFoundException(
                    string.Format(Messages.Exception_EntityNotFoundTemplate, Messages.Entity_MedicalHistory, id),
                    id,
                    EntityTypeEnum.MedicalHistory);
            }

            return Mapper.Map<MedicalHistoryForViewDto>(medicalHistory);
        }
    }
}
