using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DomainRecord
    {
        private string totalHoursWorked;
        private string comments;
        private string finalScore;

        public string TotalHoursWorked { get => totalHoursWorked; set => totalHoursWorked = value; }
        public string Comments { get => comments; set => comments = value; }
        public string FinalScore { get => finalScore; set => finalScore = value; }
    }
}
