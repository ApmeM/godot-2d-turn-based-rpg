namespace TurnBase.Core;

public interface IPlayerRotator
{
    public struct PlayerRotationResult
    {
        public bool IsNewTurn;
        public List<IPlayer> PlayersInTurn;
    }

    public PlayerRotationResult MoveNext(List<IPlayer>? current, List<IPlayer> allPlayers);
}
