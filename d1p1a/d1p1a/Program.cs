#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace d1p1a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IList<int> itemsLower = new List<int>();
            HashSet<int> itemsHigher = new HashSet<int>();

            using (FileStream fs = new FileStream(
                "input.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                using (TextReader tr = new StreamReader(fs))
                {
                    string? line;
                    do
                    {
                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                        var result = int.TryParse(line?.Trim(), out var number);
                        if (!result)
                            continue;

                        if (number < 2020 / 2)
                            itemsLower.Add(number);
                        else
                            itemsHigher.Add(number);
                    } while (line != null);
                }
            }

            foreach (var item in itemsLower)
            {
                if (itemsHigher.Contains(2020 - item))
                    Console.Out.WriteLine($"{item} * {2020 - item} = {item * (2020 - item)}");
            }
        }
    }
}
