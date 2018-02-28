using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void DelegateAddContestantToSubContest();
    public delegate void DelegateRemoveContestantFromSubContest();
    public delegate void DelegateAddSubContest();
    public delegate void DelegateFinalizeContest();
    public delegate void DelegateSubContestSelected();

    public interface ICreateSubContestView
    {
        event DelegateAddContestantToSubContest EventAddContestantToSubContest;
        event DelegateRemoveContestantFromSubContest EventRemoveContestantFromSubContest;
        event DelegateAddSubContest EventAddSubContest;
        event DelegateFinalizeContest EventFinalizeContest;
        event DelegateSubContestSelected EventSubContestSelected;

    }
}
