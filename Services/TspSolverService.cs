using TspSolver.Services.Interfaces;

namespace tsp_backend.Services;

public class TspSolverService : ITspSolverService
{
    public async Task<(List<int> BestRoute, double BestDistance)> SolveTspAsync(string filePath, int populationSize, int generations, double crossoverProbability, double mutationChance, int tournamentSize, string tournamentMethod, string crossoverMethod, int? maxDurationSeconds)
    {
        var parameters = new Parameters(
            populationSize,
            tournamentSize,
            generations,
            mutationChance,
            crossoverProbability,
            Enum.Parse<Parameters.TournamentMethod>(tournamentMethod, true),
            Enum.Parse<Parameters.CrossoverMethod>(crossoverMethod, true)
        );

        var solver = new MainGP(filePath, parameters);

        if (maxDurationSeconds.HasValue) return await Task.Run(() => solver.Evolve(maxDurationSeconds.Value));
        return await Task.Run(() => solver.Evolve());
    }

    public async Task StopEvolutionAsync()
    {
        await Task.Run(() => MainGP.StopEvolution());
    }
}
