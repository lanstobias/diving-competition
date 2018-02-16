using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class DiveCode
    {
        public double Multiplier { get; set; }

        public string Code { get; set; }

        public DiveCode()
        {
            this.Multiplier = 0;
        }

        public DiveCode(double multiplier = 0, string code = "")
        {
            this.Multiplier = multiplier;
            this.Code = code;
        }
    }
}
