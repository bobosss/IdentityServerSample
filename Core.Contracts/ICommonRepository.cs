using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allweb.Core.Common.Contracts
{
    public interface ICommonRepository
    {
        IEnumerable<LookupInfo> GetLookupInfo();
    }
}
