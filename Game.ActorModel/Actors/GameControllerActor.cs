using Akka.Actor;
using Game.ActorModel.Messages;
using System;
using System.Collections.Generic;

namespace Game.ActorModel.Actors
{
    public class GameControllerActor : ReceiveActor
    {
        private readonly Dictionary<string, IActorRef> _players;
        public GameControllerActor()
        {
            _players = new Dictionary<string, IActorRef>();

            Receive<JoinGameMessage>(JoinGame);
            Receive<AttackPlayerMessage>(HandleAttackPlayerMessage);
        }

        private void HandleAttackPlayerMessage(AttackPlayerMessage message)
        {
            _players[message.PlayerName].Forward(message);
        }

        private void JoinGame(JoinGameMessage message)
        {
            bool playerNeedsCreating = !_players.ContainsKey(message.PlayerName);

            if(playerNeedsCreating)
            {
                IActorRef newPlayerActor = Context.ActorOf(
                    Props.Create(() => new PlayerActor(message.PlayerName)), message.PlayerName);

                _players.Add(message.PlayerName, newPlayerActor);
                foreach (var player in _players.Values)
                {
                    player.Tell(new RefreshPlayerStatusMessage(), Sender);
                }
            }
        }
    }
}
