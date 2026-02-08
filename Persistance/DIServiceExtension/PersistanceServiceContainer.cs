using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Data;
using Persistance.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Persistance.DIServiceExtension
{
    public static class PersistanceServiceContainer
    {
        public static void AddPersistance(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options =>
                                               options.UseSqlServer(
                                                configuration.GetConnectionString("DefaultConnection"))
                                               );
            service.AddIdentityCore<ApplicationUser>()
                   .AddRoles<ApplicationRole>()
                   .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
