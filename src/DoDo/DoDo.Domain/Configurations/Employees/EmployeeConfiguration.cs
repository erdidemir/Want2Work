using DoDo.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DoDo.Domain.Configurations.Employees
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(x => x.Id).IsRequired();

            #region ForeingKey

            entity.HasOne(d => d.User)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Index

            entity.HasIndex(e => new { e.UserId }, "UIX_UserId").IsUnique();

            #endregion
        }
    }
}
