
namespace TurnBase.Core;

public class PlayerRotatorAllAtOnce : IPlayerRotator
{
    public IPlayerRotator.PlayerRotationResult MoveNext(List<IPlayer>? current, List<IPlayer> allPlayers)
    {
        return new IPlayerRotator.PlayerRotationResult 
        { 
            IsNewTurn = true,
            PlayersInTurn = allPlayers 
        };
    }
}