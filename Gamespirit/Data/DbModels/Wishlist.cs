using Gamespirit.Areas.Identity.Data;

namespace Gamespirit.Data.DbModels
{
    public class Wishlist
    {
        public Guid GamespiritUserId { get; set; }
        public GamespiritUser GamespiritUser { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
