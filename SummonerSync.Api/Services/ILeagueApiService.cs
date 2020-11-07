using System.Threading.Tasks;
using SummonerSync.Api.Models;

namespace SummonerSync.Api.Services
{
    public interface ILeagueApiService
    {
        public Task<Summoner> GetSummoner(CreateSummonerRequest summonerRequest);
    }
}