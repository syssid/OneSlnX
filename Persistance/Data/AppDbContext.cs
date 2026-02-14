using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public async Task<int> SaveChangesAsync() =>  await base.SaveChangesAsync();
    }
}
