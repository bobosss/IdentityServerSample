namespace Auditor.Business.Models
{
    public class PermissionsStub
    {
        public bool HasPermissions { get; set; }

        public PermissionStub Person { get; set; }
        public PermissionStub Notifications { get; set; }
        public PermissionStub FileData { get; set; }
        public PermissionStub Statistics { get; set; }
        public PermissionStub Constructor { get; set; }
        public PermissionStub LookupType { get; set; }
        public PermissionStub Issue { get; set; }
        public PermissionStub InformationDocument { get; set; }
    }
}
