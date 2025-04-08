namespace tsp_backend.Models;

public class TspRequest
{
    public required IFormFile File { get; set; } = null!;

    public GeneticParameters GeneticParameters { get; set; } = new GeneticParameters();

}