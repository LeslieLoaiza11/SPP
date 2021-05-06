using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class StudentDAO
    {
        public bool AddStudent(Domain.DomainClasses.DomainStudent student)
        {
            bool isRegistered = false;
            using (SPPEntities database = new SPPEntities())
            {
                DataAccess.Student studentDB = new Student();
                studentDB.enrollment = student.Enrollment;
                studentDB.name = student.Name;
                studentDB.lastName = student.LastName;
                studentDB.phone = student.Phone;
                studentDB.password = student.Password;
                studentDB.email = student.Email;

                if (!StudentExistsValidation(student))
                {
                    database.StudentSet.Add(studentDB);
                    database.SaveChanges();
                    isRegistered = true;
                }
            }
            return isRegistered;
        }
        public bool StudentExistsValidation(Domain.DomainClasses.DomainStudent student)
        {
            bool studentExists = false;
            Student studentDB = new Student();
            using (SPPEntities database = new SPPEntities())
            {

                studentDB = database.StudentSet.First(s => s.enrollment == student.Enrollment);
                if (student != null)
                {
                    studentExists = true;
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
            }
            return studentExists;
        }


        public List<Student> GetParticipationStudents(Project project)
        {
            List<Student> students = new List<Student>();
            using (SPPEntities database = new SPPEntities())
            {
                Project projectObtained = database.ProjectSet.Find(project.idProject);

                var participationsObtained = database.ParticipationSet.Where
                    (x => x.idParticipation == projectObtained.Participation.idParticipation);

                if (projectObtained.Participation != null)
                {
                    foreach (var participation in participationsObtained)
                    {
                        students.Add(participation.Student);
                    }
                }
            }
            return students;
        }

        public static List<Student> GetActiveStudents()
        {
            List<Student> students = new List<Student>();
            /*  Hay que enlistar los estudiantes activos, el atributo para ver si están activos está dentro de la
             *  clase participation y se llama status, este puede ser "Activo" e "Inactivo"
             *  
             *  La clase Student tiene un atributo de participation
             */
            return students;
        }

    }
}

