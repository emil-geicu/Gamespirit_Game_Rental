using Azure.Core;
using Gamespirit.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<RentHistory> RentHistory { get; set; }
        public DbSet<PlayerGameRequest> Requests { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentHistory>().HasKey(sc => new { sc.GameId, sc.PlayerId });
            modelBuilder.Entity<RentHistory>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.RentHistory)
                .HasForeignKey(sc => sc.GameId);
            modelBuilder.Entity<RentHistory>()
                .HasOne<Player>(sc => sc.Player)
                .WithMany(s => s.RentHistory)
                .HasForeignKey(sc => sc.PlayerId);

            modelBuilder.Entity<PlayerGameRequest>().HasKey(sc => new { sc.GameId, sc.PlayerId });
            modelBuilder.Entity<PlayerGameRequest>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.Requests)
                .HasForeignKey(sc => sc.GameId);
            modelBuilder.Entity<PlayerGameRequest>()
                .HasOne<Player>(sc => sc.Player)
                .WithMany(s => s.Requests)
                .HasForeignKey(sc => sc.PlayerId);

            modelBuilder.Entity<Wishlist>().HasKey(sc => new { sc.GameId, sc.PlayerId });
            modelBuilder.Entity<Wishlist>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.Wishlists)
                .HasForeignKey(sc => sc.GameId);
            modelBuilder.Entity<Wishlist>()
                .HasOne<Player>(sc => sc.Player)
                .WithMany(s => s.Wishlists)
                .HasForeignKey(sc => sc.PlayerId);
        }

    }
}
