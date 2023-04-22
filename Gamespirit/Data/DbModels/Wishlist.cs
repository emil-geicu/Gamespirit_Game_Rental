namespace Gamespirit.Data.DbModels
{
    public class Wishlist
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
