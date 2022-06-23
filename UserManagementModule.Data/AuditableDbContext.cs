using Microsoft.EntityFrameworkCore;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Data
{
    public abstract class AuditableDbContext : DbContext
    {
        public async Task<int> SaveChangesAsync(string userName)
        {
            var entries = ChangeTracker.Entries().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified);

            foreach (var entity in entries)
            {
                var auditableObject = (BaseDomain)entity.Entity;
                auditableObject.ModifiedDate = DateTime.Now;
                auditableObject.ModifiedBy = userName;

                if(entity.State == EntityState.Added)
                {
                    auditableObject.CreatedDate = DateTime.Now;
                    auditableObject.CreatedBy = userName;
                }
            }
            return await base.SaveChangesAsync();
        }
   

    }
}
