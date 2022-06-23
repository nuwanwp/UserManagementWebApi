namespace UserManagementModule.Domain.dto
{
    public class SystemUserDto : PersonDto
    {
        public int UserGroupId { get; set; }

        public string AttachedCustomerId { get; set; }

        public UserGroupDto UserGroupDto { get; set; }

    }
}
