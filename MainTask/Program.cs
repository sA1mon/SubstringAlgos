using System;
using SubstringAlgos;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MainTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var algms = new List<ISubstringSearch>
            {
                new BoyerMooreAlgorithm(),
                new BruteForceAlgorithm(),
                new RabinKarpAlgorithm(),
                new KmpAlgorithm()
            };

            Console.Write("Введите название файла с текстом: ");
            var path = Console.ReadLine();
            Console.Write("Введите подстроку, которую требуется найти: ");
            var pattern = Console.ReadLine();
            Console.WriteLine();

            string text;
            using (var sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            foreach (var algorithm in algms)
            {
                var sw = new Stopwatch();

                sw.Start();
                var result = algorithm.IndexesOf(pattern, text);
                sw.Stop();

                Console.WriteLine($"Алгоритм \"{algorithm.GetType().Name}\": {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}
