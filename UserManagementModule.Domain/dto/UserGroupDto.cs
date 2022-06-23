namespace UserManagementModule.Domain.dto
{
    public class UserGroupDto : AuditDto
    {
        public int UserGroupId { get; set; }

        public string? GroupName { get; set; }
    }
}
