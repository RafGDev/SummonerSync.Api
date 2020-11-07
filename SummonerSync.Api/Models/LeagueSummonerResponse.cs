namespace SummonerSync.Api.Models
{
    public class LeagueSummonerResponse
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        public int RevisionDate { get; set; }
        public string SummonerLevel { get; set; }
    }
}