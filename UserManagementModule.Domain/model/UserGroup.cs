using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModule.Domain.model
{
    public class UserGroup : BaseDomain
    {
        public int UserGroupId { get; set; }

        public string GroupName { get; set; }

        public ICollection<SystemUser> Users { get; set; }

        public IList<UserGroupRuleAssignment> UserGroupRuleAssignments { get; set; }

    }
}
