using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Infrastructure.Data;

namespace UrlShortener.Infrastructure.Identity
{
    public sealed class AppIdentityDBContext : IdentityDbContext<ApplicationUser> 
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options) { }
    }
}
