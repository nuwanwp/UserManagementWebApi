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
    public class UserSeedConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasData(
                new SystemUser
                {
                    Id = 2,
                    FirstName = "GEORGE",
                    LastName = "SMITH",
                    Email = "SMITH@GMAIL.COM",
                    AttachedCustomerId = "100001",
                    UserGroupId = 1,
                    CreatedBy = "NUWANW",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
