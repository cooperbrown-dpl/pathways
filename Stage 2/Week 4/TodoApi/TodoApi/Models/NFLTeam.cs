namespace TodoApi.Models
{
    public class NFLTeam
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string? Quarterback { get; set; }
    }
}
