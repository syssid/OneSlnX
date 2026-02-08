using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public required string? FirstName { get; set; }
        public required string? LastName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
