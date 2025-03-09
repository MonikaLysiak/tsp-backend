namespace TspAPI.Models;

public class TspRequest
{
    public string FilePath { get; set; }
    public int PopulationSize { get; set; }
    public double MutationRate { get; set; }
    public int Generations { get; set; }
}