using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void DelegateSetStartDate();
    public delegate void DelegateSetEndDate();
    public delegate void DelegateAddJudgeToDB();
    public delegate void DelegateAddJudgeToContest();
    public delegate void DelegateRemoveJudgeFromContest();
    public delegate void DelegateAddContestantToDB();
    public delegate void DelegateAddContestantToContest();
    public delegate void DelegateRemoveContestantFromContest();
    public delegate void DelegateCreateSubContest();

    public interface ICreateContestView
    {
        event DelegateSetStartDate EventSetStartDate;
        event DelegateSetEndDate EventSetEndDate;
        event DelegateAddJudgeToDB EventAddJudgeToDB;
        event DelegateAddJudgeToContest EventAddJudgeToContest;
        event DelegateRemoveJudgeFromContest EventRemoveJudgeFromContest;
        event DelegateAddContestantToDB EventAddContestantToDB;
        event DelegateAddContestantToContest EventAddContestantToContest;
        event DelegateRemoveContestantFromContest EventRemoveContestantFromContest;
        event DelegateCreateSubContest EventCreateSubContest;

    }
}
