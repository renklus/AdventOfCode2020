﻿#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace d1p2a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IList<int> itemsLower = new List<int>();
            HashSet<int> itemsAll = new HashSet<int>();

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

                        if (number <= 2020 / 3)
                            itemsLower.Add(number);
                        itemsAll.Add(number);
                    } while (line != null);
                }
            }

            foreach (var item in itemsLower)
            {
                foreach (var itemHigh in itemsAll)
                {
                    if (itemsAll.Contains(2020 - item - itemHigh))
                    {
                        Console.Out.WriteLine(
                            $"{item} * {itemHigh} * {2020 - item - itemHigh} = {item * itemHigh * (2020 - item - itemHigh)}");
                    }
                }
            }
        }
    }
}
