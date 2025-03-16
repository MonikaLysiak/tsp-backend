using TspSolver.Services.Interfaces;

namespace tsp_backend.Services;

public class TspSolverService : ITspSolverService
{
    public (List<int> BestRoute, double BestDistance) SolveTsp(string filePath, int populationSize, int generations, double crossoverProbability, double mutationChance, int tournamentSize, string tournamentMethod, string crossoverMethod)
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
        return solver.Evolve();
    }
}
