using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class DomainReport
    {
        private string totalHoursWorked;
        private string date;
        private string startDate;
        private string endDate;
        private string status;
        private string comments;

        public string TotalHoursWorked { get => totalHoursWorked; set => totalHoursWorked = value; }
        public string Date { get => date; set => date = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public string Status { get => status; set => status = value; }
        public string Comments { get => comments; set => comments = value; }
    }
}
