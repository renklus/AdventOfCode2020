﻿#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace d4p1a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var valid = 0;
            using (var fs = new FileStream(
                "input.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                using (TextReader tr = new StreamReader(fs))
                {
                    var line = await tr.ReadLineAsync().ConfigureAwait(false);

                    if (line == null)
                        throw new Exception();


                    do
                    {
                        var passport = new List<string>();

                        do
                        {
                            passport.AddRange(line.Split(' '));

                            line = await tr.ReadLineAsync().ConfigureAwait(false);
                        } while ((line ?? string.Empty) != string.Empty);

                        var noCid = passport.TrueForAll(x => !x.StartsWith("cid"));
                        var count = passport.Count();
                        if (noCid && count == 7 || !noCid && count == 8)
                            valid++;

                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                    } while (line != null);
                }
            }

            Console.Out.WriteLine(valid);
        }
    }
}
