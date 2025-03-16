namespace tsp_backend.Models;

public class TspRequest
{
    public string FilePath { get; set; }
    public int PopulationSize { get; set; }
    public double MutationRate { get; set; }
    public int Generations { get; set; }
    public double CrossoverProbability { get; set; }
    public double MutationChance { get; set; }
    public int TournamentSize { get; set; }
    public string CrossoverMethod { get; set; }
    public string TournamentMethod { get; set; }
}