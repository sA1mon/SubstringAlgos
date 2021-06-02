using System;
using System.Collections.Generic;
using System.Linq;

namespace SubstringAlgos
{
    public class RabinKarpAlgorithm : ISubstringSearch
    {
        public IEnumerable<int> IndexesOf(string pattern, string text)
        {
            const int PRIME = 17;
            var enters = new List<int>();

            var primePowers = GetPrimePowers(PRIME, Math.Max(pattern.Length, text.Length)).ToArray();

            var patternHash = pattern
                .Select((t, i) => (t - 'a' + 1) * primePowers[i])
                .Sum();

            var subHash = new List<long>();
            for (var i = 0; i < text.Length; i++)
            {
                subHash.Add((text[i] - 'a' + 1) * primePowers[i]);

                if (i > 0)
                {
                    subHash[i] += subHash[i - 1];
                }
            }

            for (var i = 0; i + pattern.Length - 1 < text.Length; i++)
            {
                var currentHash = subHash[i + pattern.Length - 1];
                if (i > 0) 
                    currentHash -= subHash[i - 1];

                if (currentHash == patternHash * primePowers[i])
                    enters.Add(i);
            }

            return enters;
        }

        private static IEnumerable<long> GetPrimePowers(int prime, int count)
        {
            var result = new List<long> {1};
            for (var i = 1; i < count; i++)
            {
                result.Add(result[i - 1] * prime);
            }

            return result;
        }
    }
}