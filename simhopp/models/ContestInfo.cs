using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simhopp
{
    class ContestInfo
    {
        #region Properties
        public string Name { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Arena { get; set; }
        #endregion

        #region Constructor(s)
        public ContestInfo()
        {
            Name = "";
            City = "";
            StartDate = DateTime.Now;
            EndDate = new DateTime();
            Arena = "";
        }

        public ContestInfo(string name, string city, DateTime startDate, DateTime endDate, string arena)
        {
            this.Name = name;
            this.City = city;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Arena = arena;
        }
        #endregion
    }
}
