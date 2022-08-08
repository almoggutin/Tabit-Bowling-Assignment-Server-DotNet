using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("scores")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoresRepository _scoresRepository;

        public ScoresController(IScoresRepository scoresRepository)
        {
            _scoresRepository = scoresRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetScores([FromQuery] int? limit)
        {
            var scores = await _scoresRepository.GetScoresAsync(limit);
            
            return Ok(new ResponseModel() 
            { 
                StatusCode = 200,
                StatusMessage = "Ok",
                Data = scores,
            });
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddScore([FromBody] ScoreModel scoreModel)
        {
            var score = await _scoresRepository.AddScoreAsync(scoreModel);

            return CreatedAtAction(null, new ResponseModel() 
            {
                StatusCode = 201,
                StatusMessage = "Created",
                Data = score,
                Message = "Score was created succesfully"
            });
        }
    }
}
