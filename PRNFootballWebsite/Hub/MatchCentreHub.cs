using Microsoft.AspNetCore.SignalR;

namespace PRNFootballWebsite.Api
{
    public class MatchCentreHub : Hub
    {
        public async Task SendMatchCentreUpdate()
        {
            await Clients.All.SendAsync("RefreshMatchCentre");
        }
    }
}
