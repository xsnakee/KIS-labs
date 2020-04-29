using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace TokenAuthentication
{
    public interface ITokenService
    {
        string GenerateToken(User user, List<int> permissionsIds);
    }
}
