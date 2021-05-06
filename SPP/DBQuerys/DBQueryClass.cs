using Domain.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace SPP.DBQuerys
{
    public class DBQueryClass
    {
        public static bool InsertANewLinkedOrganization(Domain.DomainLinkedOrganization linkedOrganization, out int status)
        {
            DataAccess.DAO.LinkedOrganizationDAO linkedOrganizationDAO = new DataAccess.DAO.LinkedOrganizationDAO();
            bool isRegistered = linkedOrganizationDAO.AddLinkedOrganization(linkedOrganization, out status);
            return isRegistered;
        }
    }
}
