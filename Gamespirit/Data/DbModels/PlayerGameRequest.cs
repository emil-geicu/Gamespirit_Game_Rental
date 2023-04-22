namespace Gamespirit.Data.DbModels
{
    public class PlayerGameRequest
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
