using System.Collections.Generic;
namespace SummonerSync.Api.Models
{
    public class Lobby {
        public int LobbyId { get; set; }
        public string Token { get; set; }
        public List<Summoner> Summoners { get; set; }
    }
}