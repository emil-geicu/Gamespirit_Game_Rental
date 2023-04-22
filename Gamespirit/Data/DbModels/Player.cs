namespace Gamespirit.Data.DbModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string StatusDescription { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfileImageUrl { get; set; }
        public ICollection<PlayerGameRequest> Requests { get; set; }
        public ICollection<RentHistory> RentHistory { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }

    }
}
