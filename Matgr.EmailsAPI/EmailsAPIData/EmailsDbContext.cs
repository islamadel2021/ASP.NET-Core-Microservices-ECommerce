using Matgr.EmailsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Matgr.EmailsAPI.EmailsAPIData
{
    public class EmailsDbContext : DbContext
    {
        public EmailsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmailLog> EmailLogs { get; set; }
    }
}
