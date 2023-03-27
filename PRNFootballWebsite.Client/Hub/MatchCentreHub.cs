using Microsoft.AspNetCore.SignalR;

namespace PRNFootballWebsite.Client
{
    public class MatchCentreHub : Hub
    {
        public async Task SendMatchCentreUpdate()
        {
            await Clients.All.SendAsync("RefreshMatchCentre");
        }
    }
}
