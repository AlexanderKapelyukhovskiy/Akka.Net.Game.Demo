using System;
using Akka.Actor;
using Game.ActorModel.ExternalSystems;
using Game.ActorModel.Messages;

namespace Game.ActorModel.Actors
{
    public class SignalRBridgeActor : ReceiveActor
    {
        private readonly IGameEventsPusher _gameEventsPusher;
        private readonly IActorRef _gameController;

        public SignalRBridgeActor(IGameEventsPusher gameEventsPusher, IActorRef gameController)
        {
            _gameEventsPusher = gameEventsPusher ?? throw new ArgumentNullException(nameof(gameEventsPusher));
            _gameController = gameController ?? throw new ArgumentNullException(nameof(gameController));

            Receive<JoinGameMessage>(JoinGameHandler);
            Receive<AttackPlayerMessage>(AttackPlayerHandler);
            Receive<PlayerStatusMessage>(PlayerStatusHandler);
            Receive<PlayerHealthChangedMessage>(PlayerHealthChangedHandler);
        }

        private void PlayerHealthChangedHandler(PlayerHealthChangedMessage message)
        {
            _gameEventsPusher.UpdatePlayerHealth(message.PlayerName, message.Health);
        }

        private void PlayerStatusHandler(PlayerStatusMessage message)
        {
            _gameEventsPusher.PlayerJoined(message.PlayerName, message.Health);
        }

        private void AttackPlayerHandler(AttackPlayerMessage message)
        {
            _gameController.Tell(message);
        }

        private void JoinGameHandler(JoinGameMessage message)
        {
            _gameController.Tell(message);
        }
    }
}