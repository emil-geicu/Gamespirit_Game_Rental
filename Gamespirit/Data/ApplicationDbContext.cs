using Azure.Core;
using Gamespirit.Areas.Identity.Data;
using Gamespirit.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Data
{
    public class ApplicationDbContext : IdentityDbContext<GamespiritUser,IdentityRole<Guid>,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<RentHistory> RentHistory { get; set; }
        public DbSet<PlayerGameRequest> Requests { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentHistory>().HasKey(sc => new { sc.GameId, sc.GamespiritUserId });
            modelBuilder.Entity<RentHistory>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.RentHistory)
                .HasForeignKey(sc => sc.GameId);
            modelBuilder.Entity<RentHistory>()
                .HasOne<GamespiritUser>(sc => sc.GamespiritUser)
                .WithMany(s => s.RentHistory)
                .HasForeignKey(sc => sc.GamespiritUserId);

            modelBuilder.Entity<PlayerGameRequest>().HasKey(sc => new { sc.GameId, sc.GamespiritUserId });
            modelBuilder.Entity<PlayerGameRequest>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.Requests)
                .HasForeignKey(sc => sc.GameId);
            modelBuilder.Entity<PlayerGameRequest>()
                .HasOne<GamespiritUser>(sc => sc.GamespiritUser)
                .WithMany(s => s.Requests)
                .HasForeignKey(sc => sc.GamespiritUserId);

            modelBuilder.Entity<Wishlist>().HasKey(sc => new { sc.GameId, sc.GamespiritUserId });
            modelBuilder.Entity<Wishlist>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.Wishlists)
                .HasForeignKey(sc => sc.GameId);
            modelBuilder.Entity<Wishlist>()
                .HasOne<GamespiritUser>(sc => sc.GamespiritUser)
                .WithMany(s => s.Wishlists)
                .HasForeignKey(sc => sc.GamespiritUserId);
			base.OnModelCreating(modelBuilder);
		}

    }
}
