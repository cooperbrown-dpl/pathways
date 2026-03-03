using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class FantasyFootballPlayerContext : DbContext
    {
        public FantasyFootballPlayerContext(DbContextOptions<FantasyFootballPlayerContext> options)
            : base(options) { }

        public DbSet<FantasyFootballPlayer> FantasyFootballPlayers { get; set; } = null!;
    }
}
