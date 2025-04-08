using System.Threading.Tasks;
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

    /// <summary>
    /// Solves the TSP problem using genetic algorithm
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <remarks>
    /// Sample request:
    /// 
    /// {
    ///    "filePath": "C:\\\Users\\\k1212\\\Documents\\\GeneticTSP\\\tsp-solver\\\data\\\Dane_TSP_48.csv",
    ///    "populationSize": 80000,
    ///    "mutationRate": 0.05,
    ///    "generations": 100,
    ///    "crossoverProbability": 0.9,
    ///    "mutationChance": 0.05,
    ///    "tournamentSize": 70,
    ///    "crossoverMethod": "TWO_POINT",
    ///    "tournamentMethod": "BEST_RANDOM"
    /// }
    /// </remarks>
    [HttpPost("solve")]
    public async Task<IActionResult> SolveTsp([FromForm] TspRequest request)
    {
        if (request.File == null || request.File.Length == 0)
        return BadRequest("No file uploaded.");

        var (bestRoute, bestDistance) = await _solverService.SolveTspAsync(
            request.File,
            request.GeneticParameters.PopulationSize,
            request.GeneticParameters.Generations,
            request.GeneticParameters.CrossoverProbability,
            request.GeneticParameters.MutationChance,
            request.GeneticParameters.TournamentSize,
            request.GeneticParameters.TournamentMethod,
            request.GeneticParameters.CrossoverMethod,
            request.GeneticParameters.MaxDurationSeconds
        );

        return Ok(new { BestRoute = bestRoute, Distance = bestDistance });
    }

    [HttpPost("stop")]
    public async Task StopTsp()
    {
        await _solverService.StopEvolutionAsync();
    }
}
