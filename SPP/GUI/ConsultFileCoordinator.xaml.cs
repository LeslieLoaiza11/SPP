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
    /// Lógica de interacción para ConsultFileCoordinator.xaml
    /// </summary>
    public partial class ConsultFileCoordinator : Window
    {
        public ObservableCollection<FileTable> Estudiantes { get; } = new ObservableCollection<FileTable>();
        public ConsultFileCoordinator()
        {
            InitializeComponent();
            DataContext = this;
            GetStudents();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        public struct FileTable
        {
            public string Enrollment { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
        }

        public void GetStudents()
        {
            //No sirve el GetActiveStudents jejeje no supe como hacerlo
            var students = DataAccess.DAO.StudentDAO.GetActiveStudents();
            foreach (var student in students)
            {
                Estudiantes.Add(new FileTable
                {
                    Enrollment = student.enrollment,
                    Name = student.name,
                    LastName = student.lastName,
                });
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if(StudentsListView.SelectedIndex != -1)
            {
                //Hola jeje no supe como pasar como parámetro el estudiante seleccionado a la siguiente página jejejej
                var selectedStudent = (FileTable)StudentsListView.SelectedItem;
                ConsultFileCoordinator2 consultFileCoordinator2 = new ConsultFileCoordinator2();
                consultFileCoordinator2.Show();
                this.Close();
            }
        }
    }
}
