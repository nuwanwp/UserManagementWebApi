using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModule.Domain.model
{
    public class AccessRule : BaseDomain
    {
        public int AccessRuleId { get; set; }

        public string RuleName { get; set; }

        public bool Permission { get; set; }

        public ICollection<UserGroupRuleAssignment> UserGroupRuleAssignments { get; set; }

    }
}
