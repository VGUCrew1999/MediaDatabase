using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MediaDatabase
{
    internal class MediaContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ConnectionString = "Server=localhost;User ID=root; Database=mediadatabase";
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasKey(v => v.GameId);
            modelBuilder.Entity<Movie>().HasKey(m => m.MovieId);
        }
    }
}
