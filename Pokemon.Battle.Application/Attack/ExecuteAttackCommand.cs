using Pokemon.Battle.Common.Random;

namespace Pokemon.Battle.Application.Attack;

public class ExecuteAttackCommand : IExecuteAttackCommand
{
    private readonly IRandomValueRetriever _randomValueRetriever;

    public ExecuteAttackCommand(
        IRandomValueRetriever randomValueRetriever)
    {
        _randomValueRetriever = randomValueRetriever;
    }

    public AttackResultModel Execute(ExecuteAttackModel executeAttackModel)
    {
        var attackLanded = _randomValueRetriever.GetRandomBool(50);
        var attackResultModel = new AttackResultModel()
        {
            AttackLanded = attackLanded,
            AttackName = executeAttackModel.Move.Name,
            AttackerPokemonName = executeAttackModel.AttackingPokemon.Name,
            DefenderHitPointAfterAttack = executeAttackModel.DefendingPokemon.HitPoint,
            DefenderPokemonName = executeAttackModel.DefendingPokemon.Name,
        };
        if (!attackLanded)
        {
            return attackResultModel;
        }

        var damage = GetDamage(executeAttackModel);
        attackResultModel.DefenderHitPointAfterAttack -= damage;
        return attackResultModel;
    }

    private int GetDamage(ExecuteAttackModel executeAttackModel)
    {
        var twiceAttackerLevel = executeAttackModel.AttackingPokemon.Level * 2;
        var twiceAttackerLevelPlusTen = twiceAttackerLevel + 10.0;
        var twiceAttackerLevelPlusTenDividedByTwoHundredFifty = twiceAttackerLevelPlusTen / 250;

        var subResult = twiceAttackerLevelPlusTenDividedByTwoHundredFifty * executeAttackModel.Move.BasePower;

        var attackPower = executeAttackModel.Move.MoveCategory == MoveCategory.Physical
            ? executeAttackModel.AttackingPokemon.AttackPower
            : executeAttackModel.AttackingPokemon.SpecialAttackPower;
        var defensivePower = executeAttackModel.Move.MoveCategory == MoveCategory.Physical
            ? executeAttackModel.DefendingPokemon.DefensivePower
            : executeAttackModel.DefendingPokemon.SpecialDefensivePower;
        var attackPowerAttackerDividedByDefendPowerDefender = (double)attackPower / (double)defensivePower;

        subResult *= attackPowerAttackerDividedByDefendPowerDefender;
        var damage = subResult + 2;
        var roundedDamage = Math.Round(damage, 1);

        var modifier = GetModifier(executeAttackModel);
        roundedDamage *= modifier;
        return Convert.ToInt32(Math.Round(roundedDamage, 0));
    }

    private double GetModifier(ExecuteAttackModel executeAttackModel)
    {
        var modifier = 1.0;
        // STAB
        if (executeAttackModel.AttackingPokemon.PrimaryType == executeAttackModel.Move.BattleType ||
            executeAttackModel.AttackingPokemon.SecondaryType == executeAttackModel.Move.BattleType)
        {
            modifier *= 1.5;
        }

        // Type
        var primaryTypeEffectiveness = GetTypeEffectiveness(executeAttackModel.Move.BattleType,
            executeAttackModel.DefendingPokemon.PrimaryType);
        modifier *= primaryTypeEffectiveness;

        if (executeAttackModel.DefendingPokemon.SecondaryType.HasValue)
        {
            var secondaryTypeEffectiveness = GetTypeEffectiveness(executeAttackModel.Move.BattleType,
                executeAttackModel.DefendingPokemon.SecondaryType.Value);
            modifier *= secondaryTypeEffectiveness;
        }

        // Random
        var randomIntFromRange = _randomValueRetriever.GetRandomIntFromRange(Enumerable.Range(217, 38));
        var damageMultiplier = randomIntFromRange / 255.0;
        modifier *= damageMultiplier;

        return modifier;
    }

    private double GetTypeEffectiveness(BattleType attackingType, BattleType defendingType)
    {
        var typeMatchupChart = TypeMatchupChart.GetTypeMatchupChart();
        if (!typeMatchupChart.ContainsKey(attackingType))
        {
            throw new Exception("Type not found in TypeMatrix");
        }
        var (_, typeMultiplier) = typeMatchupChart[attackingType].SingleOrDefault(bt => bt.Item1 == defendingType);
        return typeMultiplier;
    }
}