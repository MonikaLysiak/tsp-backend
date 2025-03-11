using Microsoft.AspNetCore.Mvc;
using System.IO;
using CsvHelper;
using System.Globalization;
using TspAPI.Models;

namespace TspAPI.Controllers;

[ApiController]
[Route("api/tsp")]
public class TspController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public TspController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var filePath = Path.Combine(_environment.WebRootPath, "uploads", file.FileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { FilePath = filePath });
    }

    [HttpPost("solve")]
    public IActionResult SolveTsp([FromBody] TspRequest request)
    {
        if (!System.IO.File.Exists(request.FilePath))
            return BadRequest("File not found");

        var points = ReadCsv(request.FilePath);
        var result = RunGeneticAlgorithm(points, request.PopulationSize, request.MutationRate, request.Generations);

        return Ok(result);
    }

    private List<(double X, double Y)> ReadCsv(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
        var points = new List<(double, double)>();
        while (csv.Read())
        {
            double x = csv.GetField<double>(0);
            double y = csv.GetField<double>(1);
            points.Add((x, y));
        }
        return points;
    }

    private object RunGeneticAlgorithm(List<(double X, double Y)> points, int populationSize, double mutationRate, int generations)
    {
        // Call your existing C# TSP solver here
        return new { BestRoute = points, Distance = 123.45 }; // Placeholder response
    }
}
