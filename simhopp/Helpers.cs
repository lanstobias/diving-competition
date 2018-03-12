using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public static class Helpers
    {
        public static string SQLDateFormat(DateTime date)
        {
           return date.ToString("yyyy-MM-dd");
        }

        public static string SHA1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hashedInputBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var stringBuilder = new StringBuilder(hashedInputBytes.Length * 2);

                foreach (var hashedByte in hashedInputBytes)
                {
                    stringBuilder.Append(hashedByte.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
