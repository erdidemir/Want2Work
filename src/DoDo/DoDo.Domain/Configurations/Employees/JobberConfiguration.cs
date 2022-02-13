using DoDo.Domain.Entities.Jobbers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DoDo.Domain.Configurations.Jobbers
{
    public class JobberConfiguration : IEntityTypeConfiguration<Jobber>
    {
        public void Configure(EntityTypeBuilder<Jobber> entity)
        {
            entity.HasKey(e => e.Id);

            #region ForeingKey

            //entity.HasOne(d => d.User)
            //    .WithMany(p => p.Jobbers)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.ClientNoAction);

            #endregion

            #region Index

            entity.HasIndex(e => new { e.UserId }, "UIX_UserId").IsUnique();

            #endregion
        }
    }
}
