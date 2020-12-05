using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        private Dictionary<string, string> fields = new Dictionary<string, string>();

        public void AddField(string key, string value) => fields.Add(key, value);

        public bool Validate() =>
            fields.Where(x => ValidateField(x.Key, x.Value)).Count() is 7;

        private bool ValidateField(string key, string value) =>
            key switch
            {
                "byr" => int.Parse(value) is >= 1920 and <= 2002,
                "iyr" => int.Parse(value) is >= 2010 and <= 2020,
                "eyr" => int.Parse(value) is >= 2020 and <= 2030,
                "hgt" => value.Contains("cm") ? int.Parse(value[0..^2]) is >= 150 and <= 193 
                        : value.Contains("in") ? int.Parse(value[0..^2]) is >= 59 and <= 76
                        : false,
                "hcl" => Regex.Match(value, "^[#]{1}[0-9a-f]{6}$").Success,
                "ecl" => new string[]{ "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value),
                "pid" => Regex.Match(value, "^[0-9]{9}$").Success,
                _ => false
            };
    }
}
