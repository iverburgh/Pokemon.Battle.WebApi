using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Pokemon.Battle.Application.Attack;
using Pokemon.Battle.Application.Tests.Attack.Fixtures;
using Pokemon.Battle.Common.Random;

namespace Pokemon.Battle.Application.Tests.Attack
{
    public class ExecuteAttackCommandTests
    {
        private readonly ExecuteAttackCommand _subject;
        private readonly Mock<IRandomValueRetriever> _randomValueRetrieverMock;
        private readonly Mock<ITypeEffectivenessRetriever> _typeEffectivenessRetrieverMock;

        public ExecuteAttackCommandTests()
        {
            _randomValueRetrieverMock = new Mock<IRandomValueRetriever>();
            _randomValueRetrieverMock
                .Setup(rvr => rvr.GetRandomBool(It.IsAny<int>()))
                .Returns(true);
            _randomValueRetrieverMock
                .Setup(rvr => rvr.GetRandomIntFromRange(It.IsAny<IEnumerable<int>>()))
                .Returns(255);
            _typeEffectivenessRetrieverMock = new Mock<ITypeEffectivenessRetriever>();
            _subject = new ExecuteAttackCommand(_randomValueRetrieverMock.Object, _typeEffectivenessRetrieverMock.Object);
        }

        [Fact]
        public void Execute_WhenRaichuAttacksCharizardWithThunder_ThenCorrectDamageIsReturned()
        {
            //arrange
            var executeAttackModel = ExecuteAttackModelFixture.GetExecuteAttackModelForRaichuAttacksCharizardWithThunder();
            _typeEffectivenessRetrieverMock
                .Setup(ter => ter.GetTypeEffectiveness(executeAttackModel.Move.BattleType,
                    executeAttackModel.DefendingPokemon.PrimaryType))
                .Returns(1.0);
            _typeEffectivenessRetrieverMock
                .Setup(ter => ter.GetTypeEffectiveness(executeAttackModel.Move.BattleType,
                    executeAttackModel.DefendingPokemon.SecondaryType!.Value))
                .Returns(2.0);
            var expectedResult = new AttackResultModel()
            {
                DefenderPokemonName = executeAttackModel.DefendingPokemon.Name,
                AttackLanded = true,
                AttackName = executeAttackModel.Move.Name,
                AttackerPokemonName = executeAttackModel.AttackingPokemon.Name,
                DefenderHitPointAfterAttack = 33,
            };
            //act
            var result = _subject.Execute(executeAttackModel);
            //assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Execute_WhenTurtwigAttacksPiplupWithLeafStorm_ThenCorrectDamageIsReturned()
        {
            //arrange
            var executeAttackModel = ExecuteAttackModelFixture.GetExecuteAttackModelForTurtwigAttacksPiplupWithLeafStorm();
            _typeEffectivenessRetrieverMock
                .Setup(ter => ter.GetTypeEffectiveness(executeAttackModel.Move.BattleType,
                    executeAttackModel.DefendingPokemon.PrimaryType))
                .Returns(2.0);
            var expectedResult = new AttackResultModel()
            {
                DefenderPokemonName = executeAttackModel.DefendingPokemon.Name,
                AttackLanded = true,
                AttackName = executeAttackModel.Move.Name,
                AttackerPokemonName = executeAttackModel.AttackingPokemon.Name,
                DefenderHitPointAfterAttack = 3,
            };
            //act
            var result = _subject.Execute(executeAttackModel);
            //assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
