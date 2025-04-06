using Microsoft.AspNetCore.SignalR;

public class TspHub : Hub
{
    public async Task SendUpdate(List<int> bestRoute, double bestDistance)
    {
        await Clients.All.SendAsync("ReceiveTspUpdate", bestRoute, bestDistance);
    }
}
