#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace d3p2a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (var fs = new FileStream(
                "input.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                using (TextReader tr = new StreamReader(fs))
                {
                    var results = new List<int>();
                    foreach (var slope in new int[] { 1, 3, 5, 7, -2 })
                    {
                        fs.Seek(0, SeekOrigin.Begin);

                        var line = await tr.ReadLineAsync().ConfigureAwait(false);
                        // var lineLength = (line ?? throw new Exception()).Trim().Count();
                        var lineLength = 31;
                        var currentIndex = 0;
                        var trees = 0;

                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                        while (line != null)
                        {
                            if (slope == -2)
                                line = await tr.ReadLineAsync().ConfigureAwait(false);

                            if (slope > 0)
                                currentIndex += slope;
                            else
                                currentIndex++;

                            if (currentIndex >= lineLength)
                                currentIndex -= lineLength;

                            var charAt = line[currentIndex];
                            if (charAt == '#')
                                trees++;
                            line = await tr.ReadLineAsync().ConfigureAwait(false);
                        }

                        results.Add(trees);
                    }

                    var result = 1;
                    foreach (var r in results)
                    {
                        result *= r;
                    }

                    Console.Out.WriteLine(result);
                }
            }
        }
    }
}
