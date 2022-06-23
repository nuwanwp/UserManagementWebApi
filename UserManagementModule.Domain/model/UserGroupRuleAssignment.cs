namespace UserManagementModule.Domain.model
{
    public class UserGroupRuleAssignment
    {
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public int AccessRuleId { get; set; }
        public AccessRule AccessRule { get; set; }
    }
}
