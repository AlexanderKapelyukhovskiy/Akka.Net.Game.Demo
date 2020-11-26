namespace Game.ActorModel.Messages
{
    public class JoinGameMessage
    {
        public string PlayerName { get; }

        public JoinGameMessage(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
