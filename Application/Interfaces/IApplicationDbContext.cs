using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<Product> products { get; set; }

        Task<int> SaveChangesAsync();
    }
}
