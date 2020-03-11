namespace Allweb.Core.Common.Contracts
{
    public interface IProjectOwnerType
    {
        ProjectOwnerType ProjectOwnerType { get; set; }
    }

    public enum ProjectOwnerType
    {
        Coordinator = 1,
        LegalRepresentative = 2,
        Evaluator = 3
        
    }
}