using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public static class Day4
    {
        public static List<string> GetFields()
        {
            List<string> List = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
            return List;
        }
        public static List<string> GetRequiredFields()
        {
            List<string> List = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            return List;
        }

        public static List<string> TestData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 4- Test Data.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public static List<string> RealData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 4.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public static bool PassportValidator(List<string> Passport)
        {
            List<string> Credentials = GetCredentials(Passport);
            if (!NaivePassportChecker(Passport, GetRequiredFields()))
            {
                return false;
            }
            foreach (string credential in Credentials)
            {
                if (ValidateCredential(credential))
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This is quite sloppy.
        /// </summary>
        /// <param name="FullCredential"></param>
        /// <returns></returns>
        public static bool ValidateCredential(string FullCredential)
        {
            string[] x = FullCredential.Split(':');
            switch (x[0])
            {
                case "byr":
                    if (int.TryParse(x[1], out int year))
                    {
                        return year >= 1920 && year <= 2002;
                    }
                    else
                    {
                        return false;
                    }
                case "iyr":
                    if (int.TryParse(x[1], out year))
                    {
                        return year >= 2010 && year <= 2020;
                    }
                    else
                    {
                        return false;
                    }
                case "eyr":
                    if (int.TryParse(x[1], out year))
                    {
                        return year >= 2020 && year <= 2030;
                    }
                    else
                    {
                        return false;
                    }
                case "hgt":
                    if (x[1].ToLower().Contains("cm"))
                    {
                        if (int.TryParse(x[1].Replace("cm", ""), out int cmHeight))
                        {
                            //Replacing all instances of "cm" with "" will cause a false `true` when "cm" is present in the string twice.
                            return cmHeight >= 150 && cmHeight <= 193;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (x[1].ToLower().Contains("in"))
                    {
                        if (int.TryParse(x[1].Replace("in", ""), out int inHeight))
                        {
                            return inHeight >= 59 && inHeight <= 76;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                case "hcl":
                    if (x[1].Length == 7 && x[1][0] == '#')
                    {
                        List<int> numbers = Enumerable.Range(0, 10).ToList();
                        List<string> Acceptable = numbers.Select(x => x.ToString()).ToList();
                        Acceptable.AddRange(new List<string>() { "a", "b", "c", "d", "e", "f" });
                        foreach (string goodLetter in Acceptable)
                        {
                            x[1] = x[1].Replace(goodLetter, "");
                        }
                        return x[1] == "#";
                    }
                    else
                    {
                        return false;
                    }
                case "ecl":
                    List<string> GoodColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                    return GoodColors.Contains(x[1]);
                case "pid":
                    if (x[1].Length == 9)
                    {
                        x[1] = new String(x[1].Where(c => !char.IsDigit(c)).ToArray());
                        return x[1] == "";
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }

        public static List<List<string>> GetPassportsFromText(List<string> lines)
        {
            lines.Add("");
            List<List<string>> Passports = new List<List<string>>();
            List<string> Passport = new List<string>();
            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    Passports.Add(Passport);
                    Passport = new List<string>();
                }
                else
                {
                    Passport.Add(line);
                }
            }
            return Passports;
        }

        public static int CountNaivelyGoodPassports(List<List<string>> PassPorts, List<string> Fields)
        {
            int result = 0;
            foreach (List<string> passport in PassPorts)
            {
                if (NaivePassportChecker(passport, Fields))
                {
                    result++;
                }
            }
            return result;
        }

        public static List<string> GetCredentials(List<string> Passport)
        {
            List<string> Credentials = new List<string>();
            foreach (string line in Passport)
            {
                Credentials.AddRange(line.Split(null));
            }
            return Credentials;
        }

        public static bool NaivePassportChecker(List<string> Passport, List<string> Fields)
        {
            List<string> Credentials = GetCredentials(Passport);

            foreach (string field in Fields)
            {
                if (Credentials.Any(x => x.Contains(field)))
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }


    }
}
