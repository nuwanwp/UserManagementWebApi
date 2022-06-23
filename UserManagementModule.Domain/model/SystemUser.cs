using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModule.Domain.model
{
    public class SystemUser : Person
    {
        public string AttachedCustomerId { get; set; }

        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }


    }
}
