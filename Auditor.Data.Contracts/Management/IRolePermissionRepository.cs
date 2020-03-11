using Allweb.Core.Common.Contracts;
using Auditor.Business.Models;
using Auditor.Security.Common.Models;

namespace Auditor.Data.Contracts.Repository_Interfaces.Management
{
    public interface IRolePermissionRepository : ISecurityDataRepository<RolePermission>
    {
    }
}
