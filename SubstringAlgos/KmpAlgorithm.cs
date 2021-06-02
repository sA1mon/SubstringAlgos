using System.Collections.Generic;
using System.Linq;

namespace SubstringAlgos
{
    public class KmpAlgorithm : ISubstringSearch
    {
        public IEnumerable<int> IndexesOf(string pattern, string text)
        {
            var indexes = new List<int>();
            var pref = PrefixFunction($"{pattern}#{text}").ToArray();

            for (var i = 0; i < text.Length; i++)
            {
                if (pref[pattern.Length + i + 1] == pattern.Length)
                    indexes.Add(i - pattern.Length + 1);
            }

            return indexes;
        }

        private static IEnumerable<int> PrefixFunction(string str)
        {
            Fill(out int[] prefixIndexes, str.Length);

            for (var i = 1; i < str.Length; i++)
            {
                var j = prefixIndexes[i - 1];
                while (j > 0 && str[i] != str[j])
                    j = prefixIndexes[j - 1];
                if (str[i] == str[j]) 
                    j++;

                prefixIndexes[i] = j;
            }

            return prefixIndexes;
        }

        private static void Fill<T>(out T[] arr, int count, T value = default)
        {
            arr = new T[count];
            for (var i = 0; i < count; i++)
            {
                arr[i] = value;
            }
        }
    }
}