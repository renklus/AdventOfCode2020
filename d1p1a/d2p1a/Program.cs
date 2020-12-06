#region Usings

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace d2p1a
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var valid = 0;

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
                        line = await tr.ReadLineAsync();

                        var x = line?.Split(' ', 3);
                        if (line == null)
                            continue;
                        (string condition, string character, string password) element = (x[0], x[1],
                            x[2]);
                        var character = element.character.ToCharArray()[0];
                        var conditions = element.condition.Split('-', 2);
                        if (!int.TryParse(conditions[0], out var conditionLower))
                            continue;
                        if (!int.TryParse(conditions[1], out var conditionUpper))
                            continue;

                        var password = element.password;
                        var count = password.Count(p => p == character);

                        if (count >= conditionLower && count <= conditionUpper)
                            valid++;
                    } while (line != null);
                }
            }

            Console.Out.WriteLine(valid);
        }
    }
}
