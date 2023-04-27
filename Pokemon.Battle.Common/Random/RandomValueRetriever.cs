using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Battle.Common.Random
{
    public class RandomValueRetriever : IRandomValueRetriever
    {
        public bool GetRandomBool(int chancePercentage)
        {
            throw new NotImplementedException();
        }

        public int GetRandomIntFromRange(IEnumerable<int> intRange)
        {
            throw new NotImplementedException();
        }
    }
}
