using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cas27
{
    class UsefulFunctions
    {
        public static string RandomEmail()
        {
            string email_part1, email_part2, email_part3;
            email_part1 = RandomAlphaNumeric(15);
            email_part2 = RandomAlphaNumeric(15);
            email_part3 = RandomAlphaNumeric(5);
            return email_part1 + "@" + email_part2 + "." + email_part3;
        }

        public static string RandomAlphaNumeric(int len = 10)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string RandomPassword(int len = 10)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&-_";

            var builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
