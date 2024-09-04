using HostalAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HostalAppAPI.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Grupo> Grupos { get; set; }
    }
}
