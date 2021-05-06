using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DomainProject
    {
        private string name;
        private string description;
        private DateTime date;
        private string activities;
        private string methodology;
        private string schedule;
        private string generalPurpose;
        private string mediateObjetive;
        private string inmediateObjetive;
        private int studentsRequired;
        private int studentsAssigned;
        private string status;
        
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Activities { get => activities; set => activities = value; }
        public string Methodology { get => methodology; set => methodology = value; }
        public string Schedule { get => schedule; set => schedule = value; }
        public string GeneralPurpose { get => generalPurpose; set => generalPurpose = value;  }
        public string MediateObjetive { get => mediateObjetive; set => mediateObjetive = value;  }
        public string InmediateObjetive { get => inmediateObjetive; set => inmediateObjetive = value; }
        public int StudentsRequired { get => studentsRequired; set => studentsRequired = value;  }
        public int StudentsAssigned { get => studentsAssigned; set => studentsAssigned = value;  }
        public string Status { get => status; set => status = value;  }
    }
}
