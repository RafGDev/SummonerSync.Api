using Microsoft.EntityFrameworkCore;
using SummonerSync.Api.Models;

namespace SummonerSync.Api
{
    public class DataContext : DbContext
    {
        public DbSet<Summoner> Summoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=summoner_sync_db;Username=raf");
        }
    }
}