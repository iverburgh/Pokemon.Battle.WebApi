using FluentAssertions;
using Moq;
using Pokemon.Battle.Application.Attack;
using Pokemon.Battle.Application.Tests.Attack.Fixtures;
using Pokemon.Battle.Common.Random;

namespace Pokemon.Battle.Application.Tests.Attack;

public class ExecuteAttackCommandTests
{
    private readonly ExecuteAttackCommand _subject;
    private readonly Mock<IRandomValueRetriever> _randomValueRetrieverMock;

    public ExecuteAttackCommandTests()
    {
        _randomValueRetrieverMock = new Mock<IRandomValueRetriever>();
        _randomValueRetrieverMock
            .Setup(rvr => rvr.GetRandomBool(It.IsAny<int>()))
            .Returns(true);
        _randomValueRetrieverMock
            .Setup(rvr => rvr.GetRandomIntFromRange(It.IsAny<IEnumerable<int>>()))
            .Returns(255);
        _subject = new ExecuteAttackCommand(_randomValueRetrieverMock.Object);
    }

    [Fact]
    public void Execute_WhenRaichuAttacksCharizardWithThunder_ThenCorrectDamageIsReturned()
    {
        //arrange
        var executeAttackModel = ExecuteAttackModelFixture.GetExecuteAttackModelForRaichuAttacksCharizardWithThunder();
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