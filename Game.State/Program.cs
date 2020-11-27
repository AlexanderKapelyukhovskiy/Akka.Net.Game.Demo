using System;
using Akka.Actor;
using Game.ActorModel.Actors;

namespace Game.State
{
    class Program
    {

        private static ActorSystem ActorSystemInstance;

        static void Main(string[] args)
        {
            ActorSystemInstance = ActorSystem.Create("GameSystem");

            var gameController = ActorSystemInstance.ActorOf<GameControllerActor>("GameController");

            Console.ReadKey();
        }
    }
}
