namespace Allweb.Core.Common.Contracts
{
    public interface IEntityState
    {
        State State { get; set; }
    }

    public enum State
    {
        Unchanged = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
}