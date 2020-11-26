namespace Game.ActorModel.ExternalSystems
{
    public interface IGameEventsPusher
    {
        void PlayerJoined(string playerName, int playerHealth);
        void UpdatePlayerHealth(string playerName, int playerHealth);
    }
}