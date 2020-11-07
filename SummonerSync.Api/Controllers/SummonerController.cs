using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummonerSync.Api.Models;
using SummonerSync.Api.Repositories;

namespace SummonerSync.Api.Controllers
{
       [ApiController]
       [Route("summoners")]
       public class SummonerController : ControllerBase
       {
           private readonly ILogger<WeatherForecastController> _logger;
           private readonly ISummonerRepository _summonerRepository;
   
           public SummonerController(ILogger<WeatherForecastController> logger, ISummonerRepository summonerRepository)
           {
               _logger = logger;
               _summonerRepository = summonerRepository;
           }
   
           [HttpPost]
           [Route("")]
           public async Task<IActionResult> Post([FromBody] CreateSummonerRequest summonerRequest)
           {
               var summoner = new Summoner
               {
                   Name = summonerRequest.Name,
                   Region = summonerRequest.Region
               };
                   
               await _summonerRepository.CreateSummoner(summoner);
               
               _logger.LogInformation("Created summoner with Id {Id}", summoner.SummonerId);
               return Ok();
           }
       } 
}