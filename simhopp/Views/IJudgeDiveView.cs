using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void DelegateGiveScore();

    public interface IJudgeDiveView
    {
        event DelegateGiveScore EventGiveScore;
    }
}
