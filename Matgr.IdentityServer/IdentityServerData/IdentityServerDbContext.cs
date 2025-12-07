using Matgr.IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matgr.IdentityServer.IdentityServerData
{
    public class IdentityServerDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityServerDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
