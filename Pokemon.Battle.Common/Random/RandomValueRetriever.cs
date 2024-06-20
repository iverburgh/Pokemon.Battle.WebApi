namespace Pokemon.Battle.Common.Random;

public class RandomValueRetriever : IRandomValueRetriever
{
    public bool GetRandomBool(int chancePercentage)
    {
        var random = new System.Random();
        var randomInt = random.Next(100);
        return randomInt < chancePercentage;
    }

    public int GetRandomIntFromRange(IEnumerable<int> intRange)
    {
        var random = new System.Random();
        var randomIndex = random.Next(intRange.Count());
        return intRange.ElementAt(randomIndex);
    }
}