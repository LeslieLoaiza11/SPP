using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ReportDAO
    {
        public static List<Report> GetReportsByRecord(int idRecord)
        {
            List<Report> reports = new List<Report>();
            using (SPPEntities database = new SPPEntities())
            {
                var reportsQuery = database.DocumentSet.OfType<Report>().Where(report => report.Record.idRecord == idRecord);
                reports = reportsQuery.ToList();
                return reports;
            }
        }
    }
}
