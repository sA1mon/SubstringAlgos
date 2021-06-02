using System.Collections.Generic;
using System.Text;

namespace SubstringAlgos
{
    public class BruteForceAlgorithm : ISubstringSearch
    {
        public IEnumerable<int> IndexesOf(string pattern, string text)
        {
            var enters = new List<int>();

            for (var i = 0; i < text.Length - pattern.Length; i++)
            {
                var actual = new StringBuilder();
                for (var j = i; j < i + pattern.Length; j++)
                {
                    actual.Append(text[j]);
                }
                if (actual.ToString() == pattern) enters.Add(i);
            }
            return enters;
        }
    }
}