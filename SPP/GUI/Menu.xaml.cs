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

namespace SPP.GUI
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEliminarOrganizacion_Click(object sender, RoutedEventArgs e)
        {
            DeleteLinkedOrganization deleteLinkedOrganization = new DeleteLinkedOrganization();
            deleteLinkedOrganization.Show();
            this.Close();
        }

        private void btnEliminarProyecto_Click(object sender, RoutedEventArgs e)
        {
            DeleteProject deleteProject = new DeleteProject();
            deleteProject.Show();
            this.Close();
        }
    }
}
