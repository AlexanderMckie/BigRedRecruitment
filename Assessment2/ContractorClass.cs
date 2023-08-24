using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace BigRedRecruitment
{
    public class Contractor
    {
        public int CompanyID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? HourlyWage { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public Job? AssginedJob { get; set; }

        public override string ToString()
        {
            return $"{CompanyID} : {FirstName} {LastName}";
        }
        public void SetStartDate()
        {
            if (StartDate == null)
            {
                StartDate = DateOnly.FromDateTime(DateTime.Today);
            }
        }

       
    }
}
