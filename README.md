# tspBackend

This repository is part of the [GeneticTSP](https://github.com/MonikaLysiak?tab=projects#:~:text=Sort-,GeneticTSP,-%232%20updated%203) project, which solves the **Travelling Salesman Problem (TSP)** using a **genetic algorithm**. This backend service is responsible for:

- Receiving TSP data and parameters
- Running the genetic algorithm computation
- Returning real-time or final results
- Accepting a stop signal to interrupt computation

---

## Endpoints

This backend exposes a minimal RESTful API with two primary endpoints, documented and testable via Swagger.

![image](https://github.com/user-attachments/assets/d53889d1-b1bc-42dc-a1cd-c7c703851d92)

### `POST /api/tsp/solve`

This endpoint accepts a `multipart/form-data` request containing:

- A CSV file representing the distance matrix between cities
- Parameters controlling the behavior of the genetic algorithm

#### Input Parameters

| Parameter               | Type    | Description |
|------------------------|---------|-------------|
| `File`                 | File    | CSV matrix with distances |
| `PopulationSize`       | int     | Number of individuals in each generation |
| `Generations`          | int     | Max number of generations |
| `CrossoverProbability` | double  | Probability of performing crossover |
| `MutationChance`       | double  | Chance of mutation per gene |
| `TournamentSize`       | int     | Number of individuals selected for tournament |
| `TournamentMethod`     | string  | Tournament selection strategy (e.g., `BEST_RANDOM`) |
| `CrossoverMethod`      | string  | Crossover strategy (e.g., `TWO_POINT`) |
| `MaxDurationSeconds`   | int?    | Optional max computation time in seconds |

> See below Swagger screenshot with parameter view:  
![image](https://github.com/user-attachments/assets/9e4612ac-6865-4699-a5ef-fb172996a27e)

### Response

Returns:

```json
{
  "bestRoute": [0, 3, 2, 1, 4],
  "distance": 123.45
}
```

Example Swagger result view:  
![image](https://github.com/user-attachments/assets/e0f69591-4162-488d-8d3f-1484af2f7dc8)

---

### `POST /api/tsp/stop`

This endpoint stops the currently running TSP solver. The most recently found best solution is returned to the frontend.

Use this if the user decides to cancel the computation early. Since the genetic algorithm might not yet converge to the optimal solution, the result may be worse than if allowed to complete.

Example of early stop with worse result:  
![image](https://github.com/user-attachments/assets/36d9be43-6c21-48bc-a36f-f064d231e9f0)

---

## Genetic Algorithm

The backend leverages a **custom genetic algorithm** implementation with configurable parameters. Some defaults include:

```csharp
new GeneticParameters {
  PopulationSize = 80000,
  MutationRate = 0.05,
  Generations = 100,
  CrossoverProbability = 0.9,
  MutationChance = 0.05,
  TournamentSize = 5,
  CrossoverMethod = "TWO_POINT",
  TournamentMethod = "BEST_RANDOM"
}
```

These parameters can be customized for balancing performance, speed, and solution quality.

---

## Technologies Used

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)  
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api)  
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) for API documentation  
- [CsvHelper](https://joshclose.github.io/CsvHelper/) for CSV parsing  
- Dependency Injection & async tasks for scalable, clean architecture  

---
