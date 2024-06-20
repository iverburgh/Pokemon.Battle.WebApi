namespace Pokemon.Battle.Application.Attack;

public class Move
{
    public string Name { get; set; }
        
    public int BasePower { get; set; }

    public BattleType BattleType { get; set; }

    public MoveCategory MoveCategory { get; set; }
}