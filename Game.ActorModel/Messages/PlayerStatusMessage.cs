namespace Game.ActorModel.Messages
{
    public class PlayerStatusMessage
    {
        public string PlayerName { get; }
        public int Health { get; }

        public PlayerStatusMessage(string playerName, int health)
        {
            PlayerName = playerName;
            Health = health;
        }
    }
}
