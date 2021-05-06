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
    /// Lógica de interacción para ModifyProject2.xaml
    /// </summary>
    public partial class ModifyProject2 : Window
    {
        public ModifyProject2()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //No c que poner pa que se guarde
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            ModifyProject modifyProject = new ModifyProject();
            modifyProject.Show();
            this.Close();
        }
    }
}
