namespace tsp_backend.Models;

public class TspRequest
{
    public string FilePath { get; set; } = "C:\\Users\\k1212\\Documents\\GeneticTSP\\tsp-solver\\data\\Dane_TSP_48.csv";
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