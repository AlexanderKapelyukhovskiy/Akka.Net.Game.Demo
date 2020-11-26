using System.Threading.Tasks;
using Akka.Actor;
using Game.ActorModel.Messages;
using Game.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace Game.Web
{
    public class GameHub : Hub
    {
        public void JoinGame(string playerName)
        {
            GameActorSystem.ActorReferences.SignalRBridge.Tell(new JoinGameMessage(playerName));
        }

        public void Attack(string playerName)
        {
            GameActorSystem.ActorReferences.SignalRBridge.Tell(new AttackPlayerMessage(playerName));
        }

        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}