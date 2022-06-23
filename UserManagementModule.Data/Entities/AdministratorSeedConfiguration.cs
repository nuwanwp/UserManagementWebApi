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
    public class AdministratorSeedConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasData(new Administrator
            {
                Id = 1,
                FirstName = "JOHN",
                LastName = "DOE",
                Email = "JOHN@GMAIL.COM",
                Privilege = "ADMINISTRATOR",
                CreatedBy = "NUWANW",
                CreatedDate = DateTime.Now
            }
            );
        }
    }
}
