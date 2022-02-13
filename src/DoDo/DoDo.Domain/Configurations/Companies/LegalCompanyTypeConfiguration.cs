using DoDo.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Configurations.Companies
{
    public class LegalCompanyTypeConfiguration : IEntityTypeConfiguration<LegalCompanyType>
    {
        public void Configure(EntityTypeBuilder<LegalCompanyType> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.Name).IsRequired();

            #region ForeingKey

            #endregion

            #region Index

            entity.HasIndex(e => new { e.Name }, "UIX_Name").IsUnique();

            #endregion
        }
    }
}
