using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Http;
using UMIS.BLL.AppServices._Base;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;

namespace UMIS.BLL.AppServices.Auth
{
    public class WorkgroupManager : BaseManager, IWorkgroupManager
    {
        public WorkgroupManager(IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IWorkgroupRepository workgroupRepository)
            : base(httpContextAccessor, mapper)
        {
            _workgroupRepository = workgroupRepository;
        }

        protected readonly IWorkgroupRepository _workgroupRepository;

        /// <inheritdoc />
        public async Task<List<WorkgroupDto>> GetWorkGroupsWithRolesAsync()
        {
            List<Workgroup> result = await _workgroupRepository
                .GetWorkGroupsWithRolesAsync(UserId);

            return Mapper.Map<List<WorkgroupDto>>(result);
        }

        /// <inheritdoc />
        public async Task<int> CreateWorkgroupAsync(WorkgroupDto workgroupDto)
        {
            Workgroup domainWorkgroup = Mapper.Map<Workgroup>(workgroupDto);
            domainWorkgroup.OwnerId = UserId;
            bool isExist = await _workgroupRepository.IsExistAsync(domainWorkgroup);

            if (isExist)
            {
                throw new CustomException(
                    string.Format(Messages.Exception_EntityAlreadyExist_Templete,
                    Messages.Entity_Workgroup));
            }

            int result = (await _workgroupRepository.AddAsync(domainWorkgroup)).Id;
            await _workgroupRepository.SaveChangesAsync();

            RoleToWorkgroup roleToWorkgroup = await _workgroupRepository
                .AddRoleToWorkgroup(null, domainWorkgroup.Id);
            await _workgroupRepository.SaveChangesAsync();

            return domainWorkgroup.Id;
        }

        /// <inheritdoc />
        public async Task<List<WorkgroupDto>> GetWorkgroupsForUserEditAsync()
        {
            List<Workgroup> result = await _workgroupRepository
                .GetAllForOwnerList<Workgroup>(UserId);

            return Mapper.Map<List<WorkgroupDto>>(result.OrderBy(x => x.Name));
        }
    }
}
