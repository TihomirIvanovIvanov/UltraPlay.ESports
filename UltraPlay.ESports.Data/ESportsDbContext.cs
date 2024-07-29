using Microsoft.EntityFrameworkCore;
using UltraPlay.ESports.Data.Models;

namespace UltraPlay.ESports.Data
{
    public class ESportsDbContext : DbContext
    {
        public DbSet<Sport> Sports { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Odd> Odds { get; set; }

        public ESportsDbContext(DbContextOptions<ESportsDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Sport>()
                .HasMany(s => s.Events)
                .WithOne(e => e.Sport)
                .HasForeignKey(e => e.SportId);

            builder.Entity<Event>()
                .HasMany(e => e.Matches)
                .WithOne(m => m.Event)
                .HasForeignKey(m => m.EventId);

            builder.Entity<Match>()
                .HasMany(m => m.Bets)
                .WithOne(b => b.Match)
                .HasForeignKey(b => b.MatchId);

            builder.Entity<Bet>()
                .HasMany(b => b.Odds)
                .WithOne(o => o.Bet)
                .HasForeignKey(o => o.BetId);

            // Disable cascade delete
            var entityTypes = builder.Model.GetEntityTypes().ToList();
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
