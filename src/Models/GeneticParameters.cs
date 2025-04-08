namespace tsp_backend.Models;

public class GeneticParameters
{
    public int PopulationSize { get; set; } = 80000;
    public double MutationRate { get; set; } = 0.05;
    public int Generations { get; set; } = 100;
    public double CrossoverProbability { get; set; } = 0.9;
    public double MutationChance { get; set; } = 0.05;
    public int TournamentSize { get; set; } = 5;
    public string CrossoverMethod { get; set; } = "TWO_POINT";
    public string TournamentMethod { get; set; } = "BEST_RANDOM";
    public int? MaxDurationSeconds { get; set; } = null;
}