using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Data.Entities
{
    public class UserGroupRuleAssignmentSeedConfiguration : IEntityTypeConfiguration<UserGroupRuleAssignment>
    {
        public void Configure(EntityTypeBuilder<UserGroupRuleAssignment> builder)
        {
            builder.HasData(
                new UserGroupRuleAssignment
                {
                    AccessRuleId = 1,
                    UserGroupId = 1

                },
                new UserGroupRuleAssignment
                 {
                     AccessRuleId = 1,
                     UserGroupId = 2
                 }
            );
        }
    }
}
