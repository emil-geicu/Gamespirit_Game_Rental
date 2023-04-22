using Microsoft.Extensions.Hosting;

namespace Gamespirit.Data.DbModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public ICollection<PlayerGameRequest> Requests { get; set; }
        public ICollection<RentHistory> RentHistory { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
