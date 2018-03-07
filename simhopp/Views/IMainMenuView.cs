using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    #region Delegates
    public delegate void DelegateCreateNewContest();
    public delegate void DelegateJudgeContest();
    #endregion
    interface IMainMenuView
    {
        event DelegateCreateNewContest EventCreateNewContest;
        event DelegateJudgeContest EventJudgeContest;
    }
}
