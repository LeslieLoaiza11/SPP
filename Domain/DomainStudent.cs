using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainClasses
{
    public class DomainStudent
    {
        private string enrollment;
        private string name;
        private string lastName;
        private string email;
        private string phone;
        private string password;


        public string Enrollment { get => enrollment; set => enrollment = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }

    }
}
