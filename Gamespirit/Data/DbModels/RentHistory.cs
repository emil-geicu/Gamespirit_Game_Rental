using Gamespirit.Areas.Identity.Data;

namespace Gamespirit.Data.DbModels
{
    public class RentHistory
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid GamespiritUserId { get; set; }
        public GamespiritUser GamespiritUser { get; set; }

    }
}
