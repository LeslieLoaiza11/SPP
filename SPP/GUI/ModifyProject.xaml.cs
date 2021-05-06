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
    /// Lógica de interacción para ModifyProject.xaml
    /// </summary>
    public partial class ModifyProject : Window
    {
        public ObservableCollection<FileTable> Projects { get; } = new ObservableCollection<FileTable>();
        public ModifyProject()
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
            var projects = DataAccess.DAO.ProjectDAO.GetAllProjects();
            foreach (var project in projects)
            {
                Projects.Add(new FileTable
                {
                    ProjectName = project.name,
                });
            }

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //No c que poner para que se ponga la ventana ModifyProject2 y se mande como parámetro el proyecto seleccionado
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
