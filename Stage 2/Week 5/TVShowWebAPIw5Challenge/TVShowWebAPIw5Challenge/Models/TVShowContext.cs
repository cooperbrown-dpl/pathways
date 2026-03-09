using Microsoft.EntityFrameworkCore;

namespace TVSeriesWebAPIw5Challenge.Models;

public class TVSeriesContext : DbContext
{
    public TVSeriesContext(DbContextOptions<TVSeriesContext> options)
        : base(options)
    {
    }

    public DbSet<TVShow> TVSeries { get; set; } = null!;
}
