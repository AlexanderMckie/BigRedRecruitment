using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRedRecruitment
{
    public class Job
    {
        public int JobId { get; set; }
        public string? JobTitle { get; set; }
        public DateOnly? DateOpen { get; set; }
        public DateOnly? CompletedDate { get; set; }
        public DateOnly?  DateAllocated { get; set; } 
        public int? Cost { get; set; }
        public Contractor? ContactorAssigned { get; set; }

        public override string ToString()
        {
            return $"{JobId} : {JobTitle}";
        }
        public void SetDateOpen()
        {
            if (DateOpen == null)
            {
                DateOpen = DateOnly.FromDateTime(DateTime.Today);
            }
        }

    }
}
