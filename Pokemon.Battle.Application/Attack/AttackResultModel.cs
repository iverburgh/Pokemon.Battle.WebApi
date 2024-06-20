namespace Pokemon.Battle.Application.Attack;

public class AttackResultModel
{
    public bool AttackLanded { get; set; }
        
    public string AttackerPokemonName { get; set; }
        
    public string AttackName { get; set; }

    public string DefenderPokemonName { get; set; }

    public int DefenderHitPointAfterAttack { get; set; }
}