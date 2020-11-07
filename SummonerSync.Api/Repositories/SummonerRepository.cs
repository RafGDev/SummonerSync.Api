using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummonerSync.Api;
using SummonerSync.Api.Models;

namespace SummonerSync.Api.Repositories
{
    
    public class SummonerRepository : ISummonerRepository
    {
        private readonly DataContext _context;

        public SummonerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateSummoner(Summoner summoner)
        {
            await _context.Summoners.AddAsync(summoner);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Summoner>> GetSummoners()
        {
            return await _context.Summoners.ToListAsync();
        }
    }
}