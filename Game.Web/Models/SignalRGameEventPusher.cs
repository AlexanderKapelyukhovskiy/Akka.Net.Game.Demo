using Game.ActorModel.ExternalSystems;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace Game.Web.Models
{
    public class SignalRGameEventPusher : IGameEventsPusher
    {
        private static readonly IHubContext<GameHub> _geHubContext;

        static SignalRGameEventPusher()
        {
            _geHubContext = Host
                .CreateDefaultBuilder()
                .Build()
                .Services
                .GetService(typeof(IHubContext<GameHub>)) as IHubContext<GameHub>;
        }

        public void PlayerJoined(string playerName, int playerHealth)
        {
            _geHubContext.Clients.All.SendAsync("playerJoined", playerName, playerHealth);
        }

        public void UpdatePlayerHealth(string playerName, int playerHealth)
        {
            _geHubContext.Clients.All.SendAsync("updatePlayerHealth", playerName, playerHealth);
        }
    }
}