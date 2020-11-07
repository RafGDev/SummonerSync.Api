namespace SummonerSync.Api.Models
{
    public class Summoner
    {
        public int SummonerId { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public string Image { get; set; }

        public int LobbyId { get; set; }
        public Lobby Lobby { get; set; }
    }
}