using Allweb.Core.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Allweb.Core.Common.Data
{
    public static class EntityStateConvert
    {
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Deleted:
                    return EntityState.Deleted;
                case State.Modified:
                    return EntityState.Modified;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}