﻿using DoDo.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Domain.Configurations.Companies
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.LegalCompanyTypeId).IsRequired();

            #region ForeingKey

            entity.HasOne(d => d.LegalCompanyType)
              .WithMany(p => p.Companies)
              .HasForeignKey(d => d.LegalCompanyTypeId)
              .OnDelete(DeleteBehavior.ClientNoAction);

            #endregion

            #region Index

            entity.HasIndex(e => new { e.Name }, "UIX_Name").IsUnique();

            #endregion
        }
    }
}
