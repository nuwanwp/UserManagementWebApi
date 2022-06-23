using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModule.Data.Entities;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Data
{
    public class UserManagementDbContext : AuditableDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=;Database=UserStore;Integrated Security=True;").
                LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here it is using TPT approach for mapping inheritence by comparing both pros and cons of TPH and TPC
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<SystemUser>().ToTable("SystemUser");


            modelBuilder.Entity<UserGroupRuleAssignment>()
           .HasKey(bc => new { bc.UserGroupId, bc.AccessRuleId });

            modelBuilder.Entity<UserGroupRuleAssignment>()
                .HasOne(bc => bc.UserGroup)
                .WithMany(b => b.UserGroupRuleAssignments)
                .HasForeignKey(bc => bc.UserGroupId);

            modelBuilder.Entity<UserGroupRuleAssignment>()
               .HasOne(bc => bc.AccessRule)
               .WithMany(b => b.UserGroupRuleAssignments)
               .HasForeignKey(bc => bc.AccessRuleId);

            //seeding data to administrator table
            modelBuilder.ApplyConfiguration( new AdministratorSeedConfiguration());

            //seeding data to user table
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());

            //seeding data to user group table
            modelBuilder.ApplyConfiguration(new UserGroupSeedConfiguration());

            //seeding data to access rule table
            modelBuilder.ApplyConfiguration(new AccessRuleSeedConfiguration());

            //seeding data to user group rule assignment table
            modelBuilder.ApplyConfiguration(new UserGroupRuleAssignmentSeedConfiguration());

        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Administrator> Administrator { get; set; }

        public DbSet<SystemUser> SystemUser { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }

        public DbSet<AccessRule> AccessRule { get; set; }

        public DbSet<UserGroupRuleAssignment> UserGroupRuleAssignment { get; set; }


    }
}
