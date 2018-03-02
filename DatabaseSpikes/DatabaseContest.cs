using System;
using Simhopp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSpikes
{
    public class DatabaseContest
    {
        public DatabaseContest()
        {

        }

        public void AddContestInfo()
        {
            DateTime endDate = new DateTime(2018, 03, 05);
            ContestInfo contestInto = new ContestInfo("Bra simhoppstävling", "Örebro", DateTime.Now, endDate, "Gustavsvik");

            Database database = new Database();

            try
            {
                database.PushContestInfo(contestInto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
