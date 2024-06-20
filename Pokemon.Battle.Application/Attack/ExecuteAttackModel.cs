namespace Pokemon.Battle.Application.Attack;

public class ExecuteAttackModel
{
    public Pokemon AttackingPokemon { get; set; }

    public Move Move { get; set; }

    public Pokemon DefendingPokemon { get; set; }
}