using System.Collections.Generic;

namespace UMIS.BLL.Contracts.ServicesAbstraction._Base
{
    public interface IBaseManager
    {
        int UserId { get; }
        List<int> UserPermissions { get; }
    }
}
