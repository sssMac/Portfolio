using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MessageViewModel> Messages { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
