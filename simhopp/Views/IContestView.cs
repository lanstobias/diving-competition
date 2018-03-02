using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void DelegateAddJump();
    public delegate void DelegateSubContestSelection();
    public delegate void DelegatePauseContest();
    public delegate void DelegateCloseContest();

    public interface IContestView
    {
        event DelegateAddJump EventAddJump;
        event DelegateSubContestSelection EventSubContestSelection;
        event DelegatePauseContest EventPauseContest;
        event DelegateCloseContest EventCloseContest;
    }
}
