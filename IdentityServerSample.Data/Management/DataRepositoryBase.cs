

namespace Auditor.Data.Management
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, ManagementDbContext>
        where T : class, new()
    {

    }

    public abstract class VersionedDataRepositoryBase<T> : VersionedDataRepositoryBase<T, ManagementDbContext>
        where T : class, new()
    {

    }

    public abstract class IdPoolRepositoryBase<T> : IdPoolRepositoryBase<T, ManagementDbContext>
        where T : class, new()
    {

    }

    public abstract class PersonDataRepositoryBase<T> : PersonDataRepositoryBase<T, ManagementDbContext>
    where T : class, new()
    {

    }
    public abstract class StatisticsRepositoryBase<T> : StatisticsDataRepositoryBase<T, ManagementDbContext>
     where T : class, new()
    {

    }
    public abstract class ConstructorRepositoryBase<T> : DataRepositoryBase<T, ManagementDbContext>
    where T : class, new()
    {

    }
}
