using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class NFLTeamContext : DbContext
{
    public NFLTeamContext(DbContextOptions<NFLTeamContext> options)
        : base(options)
    {
    }

    public DbSet<NFLTeam> NFLTeams { get; set; } = null!;
}
