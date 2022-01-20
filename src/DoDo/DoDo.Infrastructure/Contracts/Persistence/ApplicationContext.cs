using DoDo.Domain.Configurations.Companies;
using DoDo.Domain.Configurations.Employees;
using DoDo.Domain.Entities.Authentications;
using DoDo.Domain.Entities.Commons;
using DoDo.Domain.Entities.Companies;
using DoDo.Domain.Entities.Employees;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Contracts.Persistence
{
    public class ApplicationContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries<EntityBase>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedDate = DateTime.Now;
        //                break;
        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedDate = DateTime.Now;
        //                break;
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            #region Employees

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());


            #endregion

            #region Companies

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            #endregion

            base.OnModelCreating(modelBuilder);


        }

        #region Employees

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        #endregion
    }
}
