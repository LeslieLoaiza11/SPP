using System;
using System.ComponentModel;
using System.Windows;

namespace SPP.GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationRequest register = new RegistrationRequest();
            register.ShowDialog();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        /*private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Domain.DomainClasses.DomainStudent student = new Domain.DomainClasses.DomainStudent();
            student.Name = "Edgar";
            student.LastName = "Morales";
            student.Enrollment = "dakosljd";
            student.Email = "Edgardo";
            student.Phone = "654654654";
            student.Password = "XD";
            try
            {
                DataAccess.DAO.StudentDAO studentDAO = new DataAccess.DAO.StudentDAO();
                bool xd = studentDAO.AddStudentTest(student);
                if (xd)
                {
                    MessageBox.Show("A huevo si jala");
                }
                else
                {
                    MessageBox.Show("Mongol ya date de baja alv");
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Eres un pendejo");
            }
        }*/
    }
}
