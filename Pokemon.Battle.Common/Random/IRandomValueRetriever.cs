namespace Pokemon.Battle.Common.Random;

public interface IRandomValueRetriever
{
    bool GetRandomBool(int chancePercentage);

    int GetRandomIntFromRange(IEnumerable<int> intRange);
}