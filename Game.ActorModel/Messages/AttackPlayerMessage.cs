namespace Game.ActorModel.Messages
{
    public class AttackPlayerMessage
    {
        public string PlayerName { get; }

        public AttackPlayerMessage(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
