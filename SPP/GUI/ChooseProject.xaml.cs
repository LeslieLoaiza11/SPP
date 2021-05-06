using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SPP.DBQuerys;
using System.ComponentModel;

namespace SPP.GUI
{
    /// <summary>
    /// Lógica de interacción para ChooseProject.xaml
    /// </summary>
    public partial class ChooseProject : Window
    {
        public ObservableCollection<FileTable> Projects { get; } = new ObservableCollection<FileTable>();
        public ChooseProject()
        {
            InitializeComponent();
            DataContext = this;
            GetProjects();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        public struct FileTable
        {
            public string ProjectName { get; set; }
            public string LinkedOrganizationName { get; set; }
        }

        public void GetProjects()
        {
            var projects = DataAccess.DAO.ProjectDAO.GetActiveProjects();
            foreach (var project in projects)
            {
                Projects.Add(new FileTable
                {
                    //No supe como poner los checkbox dentro de la listview :( 
                    //No c como poner los nombres de la organización vinculada a la que pertenece el proyecto jeje JELP
                    ProjectName = project.name,
                    //Si le pongo esta línea me manda la excepción "System.ObjectDisposedException: 'The ObjectContext instance has been disposed and can no longer be used for operations that require a connection."
                    //LinkedOrganizationName = project.LinkedOrganization.name,
                });
            }

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //No c que poner
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
