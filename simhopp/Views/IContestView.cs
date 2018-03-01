using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void DelegateAddJump();
    public delegate void DelegateSubContestSelection();

    public interface IContestView
    {
        event DelegateAddJump EventAddJump;
        event DelegateSubContestSelection EventSubContestSelection;
    }
}
