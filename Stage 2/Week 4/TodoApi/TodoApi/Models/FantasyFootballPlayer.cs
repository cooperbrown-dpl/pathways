namespace TodoApi.Models
{
    public class FantasyFootballPlayer
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double ReceivingYards { get; set; }
        public double RushingYards { get; set; }
        public int Touchdowns { get; set; }
        public double FantasyPoints { get; set; }
    }
}
