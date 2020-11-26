namespace Game.ActorModel.Messages
{
    public class PlayerHealthChangedMessage
    {
        public string PlayerName { get; }
        public int Health { get; }

        public PlayerHealthChangedMessage(string playerName, int health)
        {
            PlayerName = playerName;
            Health = health;
        }
    }
}
