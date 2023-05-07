using Gamespirit.Areas.Identity.Data;

namespace Gamespirit.Data.DbModels
{
    public class PlayerGameRequest
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid GamespiritUserId { get; set; }
        public GamespiritUser GamespiritUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
