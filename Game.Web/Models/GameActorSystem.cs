using System;
using Akka.Actor;
using Game.ActorModel.Actors;
using Game.ActorModel.ExternalSystems;
using Microsoft.AspNetCore.SignalR;

namespace Game.Web.Models
{
    public static class GameActorSystem
    {
        private static ActorSystem ActorSystem;
        private static IGameEventsPusher _gameEventsPusher;
        private static IHubContext<GameHub> _gameHubContext;

        public static void SetGameHub(IHubContext<GameHub> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public static void Create()
        {
            _gameEventsPusher = new SignalRGameEventPusher(_gameHubContext);

            ActorSystem = ActorSystem.Create("GameSystem");

            ActorReferences.GameController = 
                ActorSystem.ActorSelection("akka.tcp://GameSystem@127.0.0.1:8091/user/GameController")
                    .ResolveOne(TimeSpan.FromSeconds(3))
                    .Result;

            ActorReferences.SignalRBridge = ActorSystem.ActorOf(
                Props.Create(() => new SignalRBridgeActor(_gameEventsPusher, ActorReferences.GameController)),
                "SignalRBridge");
        }

        public static void Shutdown()
        {
            ActorSystem.Terminate().Wait();
        }

        public static class ActorReferences
        {
            public static IActorRef GameController { get; set; }
            public static IActorRef SignalRBridge { get; set; }
        }
    }
}
