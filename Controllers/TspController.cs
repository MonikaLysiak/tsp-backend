using Microsoft.AspNetCore.Mvc;
using tsp_backend.Models;
using TspSolver.Services.Interfaces;

namespace tsp_backend.Controllers;

[ApiController]
[Route("api/tsp")]
public class TspController : ControllerBase
{
    private readonly ITspSolverService _solverService;

    public TspController(ITspSolverService solverService)
    {
        _solverService = solverService;
    }
    
    [HttpPost("solve")]
    public IActionResult SolveTsp([FromBody] TspRequest request)
    {
        var (bestRoute, bestDistance) = _solverService.SolveTsp(
            request.FilePath, 
            request.PopulationSize, 
            request.Generations, 
            request.CrossoverProbability,
            request.MutationChance,
            request.TournamentSize,
            request.TournamentMethod,
            request.CrossoverMethod
        );

        return Ok(new { BestRoute = bestRoute, Distance = bestDistance });
    }
}
