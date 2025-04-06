using Microsoft.AspNetCore.SignalR;
using TspSolver.Services.Interfaces;

public class TspSolverService : ITspSolverService
{
    private readonly IHubContext<TspHub> _hubContext;

    public TspSolverService(IHubContext<TspHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task<(List<int> BestRoute, double BestDistance)> SolveTspAsync(
        string filePath, int populationSize, int generations, 
        double crossoverProbability, double mutationChance, 
        int tournamentSize, string tournamentMethod, string crossoverMethod, 
        int? maxDurationSeconds)
    {
        var parameters = new Parameters(
            populationSize, tournamentSize, generations, 
            mutationChance, crossoverProbability,
            Enum.Parse<Parameters.TournamentMethod>(tournamentMethod, true),
            Enum.Parse<Parameters.CrossoverMethod>(crossoverMethod, true)
        );

        var solver = new MainGP(filePath, parameters);

        // Subscribe to updates from the genetic solver
        solver.OnBestSolutionUpdated += async (bestRoute, bestDistance) =>
        {
            await _hubContext.Clients.All.SendAsync("ReceiveTspUpdate", bestRoute, bestDistance);
        };

        if (maxDurationSeconds.HasValue) return await Task.Run(() => solver.Evolve(maxDurationSeconds.Value));
        return await Task.Run(() => solver.Evolve());
    }

    public async Task StopEvolutionAsync()
    {
        await Task.Run(() => MainGP.StopEvolution());
    }
}
