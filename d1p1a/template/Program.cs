#region Usings

using System;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace template
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
                        
                        
                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                    } while (line != null);
                }
            }

            Console.Out.WriteLine(result);
        }
    }
}
