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
    public partial class DeleteLinkedOrganization : Window
    {
        public DeleteLinkedOrganization()
        {
            InitializeComponent();
            ShowLinkedOrganizations();


        }
        private void ShowLinkedOrganizations()
        {
            LinkedOrganizationDAO linkedOrganizationDAO = new LinkedOrganizationDAO();
            List<LinkedOrganization> listLinkedOrganizations = new List<LinkedOrganization>();
            listLinkedOrganizations = linkedOrganizationDAO.GetlinkedOrganizations();

            this.ListViewLinkedOrganization.ItemsSource = listLinkedOrganizations;
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            LinkedOrganization linkedOrganization = button.DataContext as LinkedOrganization;

            MessageBoxResult confirmation = MessageBox.Show
                ("¿Desea eliminar la organización vinculada?", "Confirmar eliminación", MessageBoxButton.YesNo);
            try
            {
                if (confirmation == MessageBoxResult.Yes)
                {
                    if (!LinkedOrganizationHasProjects(linkedOrganization))
                    {
                        Delete(linkedOrganization);
                        ShowLinkedOrganizations();
                        MessageBox.Show("Organización vinculada eliminada con éxito");

                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar la organización vinculada por que tiene proyectos asociados");
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Se perdió la conexión con la base de datos");
            }

        }

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

        private void Delete(LinkedOrganization linkedOrganization)
        {
            LinkedOrganizationDAO linkedOrganizationDAO = new LinkedOrganizationDAO();
            linkedOrganizationDAO.DeleteLinkedOrganization(linkedOrganization);
        }

        private void ReturnButtonClicked(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
