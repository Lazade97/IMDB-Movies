using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_Films.Controllers
{
    public class WatchListContext : DbContext
    {
        public WatchListContext(DbContextOptions<WatchListContext> options)
            :base(options)
        {
            
        }
        public DbSet<WatchList> WatchLists { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=MovieWatchList;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchList>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.UserId,
                    e.FilmId
                });
            });
        }
    }
}
