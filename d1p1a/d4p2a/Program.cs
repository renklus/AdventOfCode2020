#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace d4p2a
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
                        var passportData = new List<string>();

                        do
                        {
                            passportData.AddRange(line.Split(' '));

                            line = await tr.ReadLineAsync().ConfigureAwait(false);
                        } while ((line ?? string.Empty) != string.Empty);

                        var noCid = passportData.TrueForAll(x => !x.StartsWith("cid"));
                        var count = passportData.Count();
                        if (noCid && count == 7 || !noCid && count == 8)
                        {
                            // (string byr, string iyr, string eyr, string hgt, string hgtInCm, string hcl, string ecl, string pid, string cid) passport;
                            Boolean invalid=true;
                            foreach (var dataEntry in passportData)
                            {
                                var splittedDataEntry = dataEntry.Split(':', 2);
                                var key = splittedDataEntry[0];
                                var value = splittedDataEntry[1];

                                invalid = true;
                                switch (key)
                                {
                                    case "byr":
                                        if (int.TryParse(value, out var byr))
                                        {
                                            if (byr >= 1920 && byr <= 2002)
                                                invalid = false;
                                        }

                                        break;

                                    case "iyr":
                                        if (int.TryParse(value, out var iyr))
                                        {
                                            if (iyr >= 2010 && iyr <= 2020)
                                                invalid = false;
                                        }

                                        break;

                                    case "eyr":
                                        if (int.TryParse(value, out var eyr))
                                        {
                                            if (eyr >= 2020 && eyr <= 2030)
                                                invalid = false;
                                        }

                                        break;

                                    case "hgt":
                                        var number = string.Concat(
                                            value.TakeWhile(x => x >= '0' && x <= '9'));
                                        if (value.Count() != number.Length + 2)
                                            break;
                                        var unit = value.Substring(number.Length, 2);

                                        if (int.TryParse(number, out var hgt))
                                        {
                                            if (unit == "cm" && hgt >= 150 && hgt <= 193)
                                                invalid = false;
                                            else if (unit == "in" && hgt >= 59 && hgt <= 76)
                                                invalid = false;
                                        }

                                        break;

                                    case "hcl":
                                        if (value.Count() == 7
                                            && value.StartsWith('#')
                                            && value.Substring(1, 6)
                                                .All(
                                                    x => x >= '0' && x <= '9'
                                                         || x >= 'a' && x <= 'f'))
                                            invalid = false;

                                        break;

                                    case "ecl":
                                        if (new[]
                                        {
                                            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
                                        }.Any(x => x == value))
                                            invalid = false;
                                        break;

                                    case "pid":
                                        if (value.Count() == 9
                                            && value.All(x => x >= '0' && x <= '9'))
                                            invalid = false;
                                        break;

                                    case "cid":
                                        invalid = false;
                                        break;

                                    default:
                                        break;
                                }

                                if (invalid)
                                    break;
                            }

                            if (!invalid)
                                valid++;
                        }
                        

                        line = await tr.ReadLineAsync().ConfigureAwait(false);
                    } while (line != null);
                }
            }

            Console.Out.WriteLine(valid);
        }
    }
}
