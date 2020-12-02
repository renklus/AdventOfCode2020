using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace d2p2a
{
    class Program
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
                        if (!int.TryParse(conditions[0], out var conditionFirst))
                            continue;
                        if (!int.TryParse(conditions[1], out var conditionSecond))
                            continue;

                        var password = element.password;
                        int count = 0;

                        if (password.ElementAt(conditionFirst - 1) == character)
                            count++;
                        if (password.ElementAt(conditionSecond - 1) == character)
                            count++;
                        if (count == 1)
                            valid++;

                    } while (line != null);
                }
            }

            Console.Out.WriteLine(valid);
        }
    }
}
