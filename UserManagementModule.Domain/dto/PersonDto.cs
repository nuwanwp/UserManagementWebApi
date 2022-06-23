namespace UserManagementModule.Domain.dto
{
    public class PersonDto : AuditDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        
    }
}
