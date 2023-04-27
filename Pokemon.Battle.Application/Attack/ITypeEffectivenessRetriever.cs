namespace Pokemon.Battle.Application.Attack
{
    public interface ITypeEffectivenessRetriever
    {
        double GetTypeEffectiveness(BattleType attackingType, BattleType defendingType);
    }
}