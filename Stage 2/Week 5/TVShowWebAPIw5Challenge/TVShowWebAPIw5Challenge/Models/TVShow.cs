namespace TVSeriesWebAPIw5Challenge.Models;

public class TVShow
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public int TotalSeasons { get; set; }
    public string Platform { get; set; }
    public string TVRating { get; set; }
    public bool HaveStartedWatching { get; set; }
}
