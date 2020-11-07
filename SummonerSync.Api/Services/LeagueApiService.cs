using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummonerSync.Api.Models;

namespace SummonerSync.Api.Services
{
    public class LeagueApiService : ILeagueApiService
    {
        private readonly HttpClient _leagueClient;
        private readonly string _apiUrl = "https://{0}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{1}";

        public LeagueApiService(IHttpClientFactory clientFactory)
        {
            _leagueClient = clientFactory.CreateClient("leagueApi");
        }

        public async Task<Summoner> GetSummoner(CreateSummonerRequest summonerRequest)
        {
            var url = FormatUrl(summonerRequest);
            var response =  await _leagueClient.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            
            var responseStream = await response.Content.ReadAsStreamAsync();
            var summoner = JsonSerializer.DeserializeAsync<LeagueSummonerResponse>(responseStream);
            
            return new Summoner();
        }

        private string FormatUrl(CreateSummonerRequest summonerRequest)
        {
            var mappedRegion = MapRegion(summonerRequest.Region);
            return String.Format(_apiUrl, mappedRegion, summonerRequest.Name);
        }

        private static string MapRegion(Region region)
        {
            return region switch
            {
                Region.NorthAmerica => "na1",
                Region.Oceania => "oc1",
                Region.EuropeWest => "EUW1",
                _ => "na1"
            };
        }
    }
}