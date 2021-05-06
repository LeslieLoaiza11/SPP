using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainClasses;

namespace DataAccess.DAO
{
    public class ProjectDAO
    {
        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            using (SPPEntities database = new SPPEntities())
            {
                var projectsObtained = database.ProjectSet;
                foreach (var project in projectsObtained)
                {
                    projects.Add(project);
                }
            }
            return projects;
        }

        public List<Project> GetLinkedOrganizationProjects(LinkedOrganization linkedOrganization)
        {
            List<Project> projects = new List<Project>();
            using (SPPEntities database = new SPPEntities())
            {
                var projectsObtained = database.ProjectSet.Where
                    (project => project.LinkedOrganization.IdLinkedOrganization == linkedOrganization.IdLinkedOrganization);
                foreach (var project in projectsObtained)
                {
                    projects.Add(project);
                }
            }
            return projects;
        }


        public static List<Project> GetActiveProjects()
        {
            List<Project> activeProjects = new List<Project>();
            using (SPPEntities database = new SPPEntities())
            {
                var projectsQuery = database.ProjectSet.Where(x => x.status == "Activo");
                activeProjects = projectsQuery.ToList();
                return activeProjects;
            }
        }

        public static List<Project> GetAllProjects()
        {
            List<Project> allProjects = new List<Project>();
            using (SPPEntities database = new SPPEntities())
            {
                var projectsQuery = database.ProjectSet;
                allProjects = projectsQuery.ToList();
                return allProjects;
            }
        }

        /*public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            using (SPPEntities database = new SPPEntities())
            {
                var projectsObtained = database.ProjectSet;
                foreach (var project in projectsObtained)
                {
                    projects.Add(project);
                }
            }
            return projects;

            public void DeleteProject(Project project)
            {
                using (SPPEntities database = new SPPEntities())
                {
                    Project projectObtained = database.ProjectSet
                        .First(x => x.idProject == project.idProject);
                    if (projectObtained != null)
                    {
                        database.ProjectSet.Remove(projectObtained);
                        database.SaveChanges();
                    }
                }
            }
        }*/
    } 
}
