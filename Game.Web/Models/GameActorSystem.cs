using Akka.Actor;
using Game.ActorModel.Actors;

namespace Game.Web.Models
{
    public static class GameActorSystem
    {
        private static ActorSystem ActorSystem;

        public static void Create()
        {
            ActorSystem = ActorSystem.Create("GameSystem");

            ActorReferences.GameController = ActorSystem.ActorOf<GameControllerActor>();
        }

        public static void Shutdown()
        {
            ActorSystem.Terminate().Wait();
        }

        public static class ActorReferences
        {
            public static IActorRef GameController { get; set; }
        }
    }
}
