using System;
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
    }
}
