using Pokemon.Battle.Application.Attack;

namespace Pokemon.Battle.Application.Tests.Attack.Fixtures
{
    internal static class ExecuteAttackModelFixture
    {
        internal static ExecuteAttackModel GetExecuteAttackModelForTurtwigAttacksPiplupWithLeafStorm()
        {
            return new ExecuteAttackModel()
            {
                Move = new Move()
                {
                    BasePower = 140,
                    BattleType = BattleType.Grass,
                    Name = "Leaf Storm",
                    MoveCategory = MoveCategory.Special,
                },
                AttackingPokemon = new Application.Attack.Pokemon()
                {
                    PokedexNumber = 387,
                    Name = "Turtwig",
                    PrimaryType = BattleType.Grass,
                    SecondaryType = null,
                    Level = 100,
                    SpecialAttackPower = 200,
                    SpecialDefensivePower = 200,
                    HitPoint = 400,
                },
                DefendingPokemon = new Application.Attack.Pokemon()
                {
                    PokedexNumber = 393,
                    Name = "Piplup",
                    PrimaryType = BattleType.Water,
                    SecondaryType = null,
                    Level = 90,
                    SpecialAttackPower = 194,
                    SpecialDefensivePower = 190,
                    HitPoint = 380,
                },
            };
        }

        internal static ExecuteAttackModel GetExecuteAttackModelForRaichuAttacksCharizardWithThunder()
        {
            return new ExecuteAttackModel()
            {
                Move = new Move()
                {
                    BasePower = 110,
                    BattleType = BattleType.Electric,
                    Name = "Thunder",
                    MoveCategory = MoveCategory.Special,
                },
                AttackingPokemon = new Application.Attack.Pokemon()
                {
                    PokedexNumber = 26,
                    Name = "Raichu",
                    PrimaryType = BattleType.Electric,
                    SecondaryType = null,
                    Level = 65,
                    SpecialAttackPower = 145,
                    SpecialDefensivePower = 115,
                    HitPoint = 200,
                },
                DefendingPokemon = new Application.Attack.Pokemon()
                {
                    PokedexNumber = 6,
                    Name = "Charizard",
                    PrimaryType = BattleType.Fire,
                    SecondaryType = BattleType.Flying,
                    Level = 75,
                    SpecialAttackPower = 170,
                    SpecialDefensivePower = 140,
                    HitPoint = 230,
                },
            };
        }
    }
}
