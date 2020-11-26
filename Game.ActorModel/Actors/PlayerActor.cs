using Akka.Actor;
using Game.ActorModel.Messages;
using System;

namespace Game.ActorModel.Actors
{
    public class PlayerActor: ReceiveActor
    {
        private readonly string _playerName;
        private int _health;

        public PlayerActor(string playerName)
        {
            _playerName = playerName;
            _health = 100;

            Receive<AttackPlayerMessage>(HandleAttackPlayerMessage);
            Receive<RefreshPlayerStatusMessage>(HandleRefreshPlayerStatusMessage);
        }

        private void HandleRefreshPlayerStatusMessage(RefreshPlayerStatusMessage obj)
        {
            Sender.Tell(new PlayerStatusMessage(_playerName, _health));
        }

        private void HandleAttackPlayerMessage(AttackPlayerMessage message)
        {
            _health -= 20;
            Sender.Tell(new PlayerHealthChangedMessage(_playerName, _health));
        }
    }
}
