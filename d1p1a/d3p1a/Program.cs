#region Usings

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace d3p1a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (FileStream fs = new FileStream(
                "input.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                using (TextReader tr = new StreamReader(fs))
                {
                    var line = await tr.ReadLineAsync().ConfigureAwait(false);
                    // var lineLength = (line ?? throw new Exception()).Trim().Count();
                    var lineLength = 31;
                    var currentIndex = 0;
                    var trees = 0;

                    line = await tr.ReadLineAsync().ConfigureAwait(false);
                    while (line != null)
                    {
                        currentIndex += 3;
                        if (currentIndex >= lineLength)
                            currentIndex -= lineLength;
                        var charAt = line[currentIndex];
                        if (charAt == '#')
                            trees++;
                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                    }

                    Console.Out.WriteLine(trees);
                }
            }
        }
    }
}
