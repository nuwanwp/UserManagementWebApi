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
    public class UserGroupSeedConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasData(
                new UserGroup
                {
                    UserGroupId = 1,
                    GroupName = "FRONTDESK",
                    CreatedBy = "NUWANW",
                    CreatedDate = DateTime.Now
                },
                new UserGroup
                {
                    UserGroupId = 2,
                    GroupName = "RECEPTIONIST",
                    CreatedBy = "NUWANW",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
