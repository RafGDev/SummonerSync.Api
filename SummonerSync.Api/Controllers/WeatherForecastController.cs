using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummonerSync.Api.Models;
using SummonerSync.Api.Repositories;

namespace SummonerSync.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISummonerRepository _summonerRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISummonerRepository summonerRepository)
        {
            _logger = logger;
            _summonerRepository = summonerRepository;
        }

        [HttpGet]
        public async Task<List<Summoner>> Get()
        {
            return await _summonerRepository.GetSummoners();
        }
    }
}