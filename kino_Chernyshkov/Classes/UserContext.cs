using System;
using System.Collections.Generic;
using System.Text;
using kino_Chernyshkov.Classes.Common;
using kino_Chernyshkov.Models;
using Microsoft.EntityFrameworkCore;

namespace kino_Chernyshkov.Classes
{
    public class UserContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UserContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>

           optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);


    }
}
