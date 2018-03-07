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
        public static bool EmailCheckFormat(string email)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

            if (regex.IsMatch(email))
                return true;

            return false;
        }

        public static bool SSNCheckFormat(string ssn)
        {
            Regex regex = new Regex(@"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$");

            if (regex.IsMatch(ssn))
                return true;

            return false;
        }
    }
}
