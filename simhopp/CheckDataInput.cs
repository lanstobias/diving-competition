using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simhopp
{
    public static class CheckDataInput
    {
        // check if a string is formatted correctly
        public static bool StringCheckFormat(string s)
        {
            Regex regex = new Regex(@"^[a-öA-Ö0-9_ -]+$");

            if (regex.IsMatch(s))
                return true;

            return false;
        }

    }
}
