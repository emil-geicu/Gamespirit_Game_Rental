namespace Gamespirit.Data.DbModels
{
    public class RentHistory
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
