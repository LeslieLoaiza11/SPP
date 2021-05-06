using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Domain.DomainClasses;
using DataAccess;
using DataAccess.DAO;
using System.Data.SqlClient;

namespace SPP.GUI
{
    public partial class DeleteProject : Window
    {
        public DeleteProject()
        {
            InitializeComponent();
            ShowProjects();
        }
        private void ShowProjects()
        {
            ProjectDAO projectDAO = new ProjectDAO();
            List<Project> listProjects = new List<Project>();
            listProjects = projectDAO.GetProjects();
            this.ListViewProject.ItemsSource = listProjects;
        }

        /*private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Project project = button.DataContext as Project;

            MessageBoxResult confirmation = MessageBox.Show
                ("¿Desea eliminar el proyecto?", "Confirmar eliminación", MessageBoxButton.YesNo);
            try
            {
                if (confirmation == MessageBoxResult.Yes)
                {
                    if (!ProjectsHasStudents(project))
                    {
                        Delete(project);
                        ShowProjects();
                        MessageBox.Show("Proyecto eliminado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el proyecto por que tiene estudiantes asociados");
                    }

                }
            }
            catch (SqlException E)
            {
                MessageBox.Show("Se perdió la conexión con la base de datos");
            }

        }

        private bool ProjectsHasStudents(Project project)
        {
            StudentDAO studentDAO = new StudentDAO();

            List<Student> listStudent = studentDAO.GetParticipationStudents(project);
            if (listStudent.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        private bool LinkedOrganizationHasProjects(LinkedOrganization linkedOrganization)
        {

            ProjectDAO projectDAO = new ProjectDAO();
            List<Project> listProjects = projectDAO.GetLinkedOrganizationProjects(linkedOrganization);

            if (listProjects.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       /* private void Delete(Project project)
        {
            ProjectDAO projectDAO = new ProjectDAO();
            projectDAO.DeleteProject(project);
        }*/

        private void ReturnButtonClicked(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
