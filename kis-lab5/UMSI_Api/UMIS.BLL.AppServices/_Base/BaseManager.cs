using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TokenAuthentication.Claims;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.AppServices._Base
{
    public class BaseManager : IBaseManager
    {
        protected readonly IHttpContextAccessor HttpContextAccessor;
        protected readonly IMapper Mapper;

        public BaseManager(IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            HttpContextAccessor = httpContextAccessor;
            Mapper = mapper;
        }


        /// <summary>
        /// Список пермиссий пользователя
        /// </summary>
        private List<int> _userPermissions = null;
        public List<int> UserPermissions
        {
            get
            {
                if (_userPermissions == null)
                {
                    string jsonPermissions = HttpContextAccessor.HttpContext.User.Claims
                                            .FirstOrDefault(x => x.Type == UmisClaimTypes.JsonPermissionsClaimName)
                                            .Value ?? string.Empty;

                    _userPermissions = JsonConvert.DeserializeObject<List<int>>(jsonPermissions)
                        ?? new List<int>();
                }

                return _userPermissions;
            }
        }

        /// <summary>
        /// Идентификатор текущего пользователя
        /// </summary>
        public int UserId
        {
            get
            {
                return Int32.Parse(HttpContextAccessor.HttpContext.User.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                        .Value);
            }
        }

    }
}
