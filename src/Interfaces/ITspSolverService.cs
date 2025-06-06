namespace TspSolver.Services.Interfaces;
public interface ITspSolverService
{
    public Task<(List<int> BestRoute, double BestDistance)> SolveTspAsync(IFormFile File, int populationSize, int generations, double crossoverProbability, double mutationChance, int tournamentSize, string tournamentMethod, string crossoverMethod, int? maxDurationSeconds);
    public Task StopEvolutionAsync();
}