#region Usings

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace d5p2a
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
                var highestSeatId = 0;
                var seatIDs = new bool[971];

                using (TextReader tr = new StreamReader(fs))
                {
                    var line = await tr.ReadLineAsync().ConfigureAwait(false);

                    if (line == null)
                        throw new Exception();


                    do
                    {
                        var rowData = line[0 .. 7];
                        var columnData = line[7 .. 10];

                        var rowBinary = string.Concat(rowData.Select(i => i == 'B' ? '1' : '0'));
                        var columnBinary =
                            string.Concat(columnData.Select(i => i == 'R' ? '1' : '0'));
                        var row = Convert.ToInt32(rowBinary, 2);
                        var column = Convert.ToInt32(columnBinary, 2);

                        var seatId = row * 8 + column;
                        if (seatId > highestSeatId)
                            highestSeatId = seatId;

                        seatIDs[seatId] = true;

                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                    } while (line != null);
                }

                for (var i = 0; i < seatIDs.Length - 1; i++)
                {
                    if (seatIDs[i + 1] && seatIDs[i - 1] && !seatIDs[i])
                        Console.Out.WriteLine(i);
                }
            }
        }
    }
}
