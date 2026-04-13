using kino_Chernyshkov.Classes.Common;
using kino_Chernyshkov.Models;
using Microsoft.EntityFrameworkCore;

namespace kino_Chernyshkov.Classes
{
    public class ClubsContext : DbContext
    {
        public DbSet<Clubs> Clubs { get; set; }

        public ClubsContext() => 
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>

           optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);

    }
}
