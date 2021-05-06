using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainClasses;

namespace DataAccess.DAO
{
    public class LinkedOrganizationDAO
    {
        public bool AddLinkedOrganization(Domain.DomainLinkedOrganization linkedOrganization, out int status)
        {
            bool isRegistered = false;

            using (SPPEntities database = new SPPEntities())
            {
                try
                {
                    DataAccess.LinkedOrganization linkedOrganizationDB = new LinkedOrganization();

                    linkedOrganizationDB.name = linkedOrganization.Name;
                    linkedOrganizationDB.adress = linkedOrganization.Address;
                    linkedOrganizationDB.phone = linkedOrganization.Phone;

                    database.LinkedOrganizationSet.Add(linkedOrganizationDB);
                    database.SaveChanges();

                    isRegistered = true;

                    status = 0;
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    status = 1;
                }
                catch (Exception)
                {
                    status = 2;
                }

            }
            return isRegistered;
        }
        public List<LinkedOrganization> GetlinkedOrganizations()
        {
            List<LinkedOrganization> linkedOrganizations = new List<LinkedOrganization>();
            using (SPPEntities database = new SPPEntities())
            {

                var linkedOrganizationsObtained = database.LinkedOrganizationSet;
                foreach (var linkedOrganization in linkedOrganizationsObtained)
                {
                    linkedOrganizations.Add(linkedOrganization);
                }

            }
            return linkedOrganizations;
        }

        public void DeleteLinkedOrganization(LinkedOrganization linkedOrganization)
        {

            using (SPPEntities database = new SPPEntities())
            {
                LinkedOrganization linkedOrganizationObtained = database.LinkedOrganizationSet
                    .First(x => x.IdLinkedOrganization == linkedOrganization.IdLinkedOrganization);
                if (linkedOrganizationObtained != null)
                {
                    database.LinkedOrganizationSet.Remove(linkedOrganizationObtained);
                    database.SaveChanges();
                }
            }
        }
    }
}
