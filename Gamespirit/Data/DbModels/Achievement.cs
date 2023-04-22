namespace Gamespirit.Data.DbModels
{
    public class Achievement
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
