using System.Collections.Generic;
using System.Threading.Tasks;
using SummonerSync.Api.Models;

namespace SummonerSync.Api.Repositories
{
    public interface ISummonerRepository
    {
        public Task CreateSummoner(Summoner summoner);

        public Task<List<Summoner>> GetSummoners();
    }
}