#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace d6p2a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var result = 0;

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
                        var answers = new List<List<char>>();
                        do
                        {
                            answers.Add(new List<char>(line.ToCharArray()));

                            line = await tr.ReadLineAsync().ConfigureAwait(false);
                        } while ((line ?? string.Empty) != string.Empty);

                        foreach (var answer in answers.First())
                        {
                            if (answers.All(answerList => answerList.Contains(answer)))
                                result++;
                        }

                        // var answersInGroup = answers.Distinct().Count();
                        // result += answersInGroup;


                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                    } while (line != null);
                }
            }

            Console.Out.WriteLine(result);
        }
    }
}
