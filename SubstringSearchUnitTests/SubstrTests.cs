using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using SubstringAlgos;

namespace SubstringSearchUnitTests
{
    [TestClass]
    public class SubstrTests
    {
        [TestMethod]
        public void TestAll()
        {
            var algms = new List<ISubstringSearch>
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KmpAlgorithm()
            };

            var expected = new List<int>()
            {
                11, 16
            };

            var result = algms
                .Select(substringSearch => 
                    substringSearch.IndexesOf("ab", "basddssaddsabccdaboba").ToList())
                .ToList();

            foreach (var res in result)
            {
                CollectionAssert.AreEqual(expected, res);
            }
        }
    }
}
