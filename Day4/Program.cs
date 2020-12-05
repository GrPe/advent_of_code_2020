using System;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = Input.data.Split("\r\n\r\n");
            PartOne(passports);
            PartTwo(passports);
        }

        private static void PartTwo(string[] passports)
        {
            int counter = 0;
            foreach (var passport in passports)
            {
                var fields = passport.Trim().Split('\n', ' ');
                var pass = new Passport();
                foreach (var field in fields)
                {
                    pass.AddField(field.Trim().Split(':')[0], field.Trim().Split(':')[1]);
                }
                if (pass.Validate())
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        private static void PartOne(string[] passports)
        {
            int counter = 0;
            foreach (var passport in passports)
            {
                var fields = passport.Trim().Split('\n', ' ');
                int checker = 0;
                foreach (var field in fields)
                {
                    if (field.Trim().Split(':')[0] != "cid")
                    {
                        checker++;
                    }
                }
                if (checker == 7)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
