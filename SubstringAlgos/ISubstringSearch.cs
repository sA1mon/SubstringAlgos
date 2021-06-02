using System.Collections.Generic;

namespace SubstringAlgos
{
    public interface ISubstringSearch
    {
        IEnumerable<int> IndexesOf(string pattern, string text);
    }
}