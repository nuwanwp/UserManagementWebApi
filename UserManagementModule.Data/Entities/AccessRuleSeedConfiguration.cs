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
    public class AccessRuleSeedConfiguration : IEntityTypeConfiguration<AccessRule>
    {
        public void Configure(EntityTypeBuilder<AccessRule> builder)
        {
            builder.HasData(new AccessRule
                {
                    AccessRuleId = 1,
                    RuleName = "CUSTOMER_PROFILE_ACCESS",
                    Permission = true,
                    CreatedBy = "NUWANW",
                    CreatedDate = DateTime.Now
                }
            );;
        }
    }
}
