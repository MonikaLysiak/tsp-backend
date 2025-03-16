namespace TspSolver.Services.Interfaces;
public interface ITspSolverService
{
    public (List<int> BestRoute, double BestDistance) SolveTsp(string filePath, int populationSize, int generations, double crossoverProbability, double mutationChance, int tournamentSize, string tournamentMethod, string crossoverMethod);
}