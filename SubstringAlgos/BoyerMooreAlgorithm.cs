using System;
using System.Collections.Generic;
using System.Linq;

namespace SubstringAlgos
{
    public class BoyerMooreAlgorithm : ISubstringSearch
    {
        public IEnumerable<int> IndexesOf(string pattern, string text)
        {
            var result = new List<int>();
            var stopTable = new Dictionary<char, int>();
            var suffixTable = new Dictionary<int, int>();

            for (var i = 0; i < pattern.Length; i++)
            {
                stopTable[pattern[i]] = i;
            }

            var reversedPattern = pattern.Reverse();
            var prefix = PrefixFunction(pattern).ToArray();
            var reversedPrefix = PrefixFunction(pattern).ToArray();

            for (var i = 0; i < pattern.Length + 1; i++)
            {
                suffixTable[i] = pattern.Length - prefix.Last();
            }

            for (var i = 1; i < pattern.Length; i++)
            {
                var j = reversedPrefix[i];
                suffixTable[j] = Math.Min(suffixTable[j], i - reversedPrefix[i] + 1);
            }

            for (var i = 0; i < text.Length - pattern.Length;)
            {
                var position = pattern.Length - 1;

                while (position >= 0 && pattern[position] == text[position + i])
                {
                    if (position == 0)
                    {
                        result.Add(i);
                    }

                    position--;
                }

                if (position == pattern.Length - 1)
                {
                    int stopSymbolAdditional;
                    if (stopTable.ContainsKey(text[position + i]))
                    {
                        stopSymbolAdditional = position - stopTable[text[position + i]];
                    }
                    else
                    {
                        stopSymbolAdditional = position + 1;
                    }

                    i += stopSymbolAdditional;
                }
                else
                {
                    i += suffixTable[pattern.Length - position - 1];
                }
            }

            return result;
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