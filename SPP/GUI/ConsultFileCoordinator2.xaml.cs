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
    /// Lógica de interacción para ConsultFileCoordinator2.xaml
    /// </summary>
    public partial class ConsultFileCoordinator2 : Window
    {
        public ObservableCollection<FileTable> Reportes { get; } = new ObservableCollection<FileTable>();
        public int idExpediente;
        public ConsultFileCoordinator2(int idExpediente)
        {
            InitializeComponent();
            DataContext = this;
            this.idExpediente = idExpediente;
            GetReports();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        public struct FileTable
        {
            public string Name { get; set; }
            public double Weight { get; set; }
            public DateTime UploadDate { get; set; }
            public String Path { get; set; }
        }

        public void GetReports()
        {
            // El "4" es el id de un expediente y falta pasar el id pero del estudiante que se seleccionó en la ventana ConsultFileCoordinator
            var reports = DataAccess.DAO.ReportDAO.GetReportsByRecord(4);
            foreach (var report in reports)
            {
                Reportes.Add(new FileTable
                {
                    Name = report.name,
                    Weight = report.weight,
                    UploadDate = report.uploadDate,
                    Path = report.path
                });
            }
        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsListView.SelectedIndex != -1)
            {
                var selectedReport = (FileTable)ReportsListView.SelectedItem;
                System.Diagnostics.Process.Start(selectedReport.Path);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            // Por alguna razón si pico este botón se abre la otra ventana pero después se cierran las dos
            ConsultFileCoordinator consultFileCoordinator = new ConsultFileCoordinator();
            consultFileCoordinator.Show();
            this.Close();
        }
    }
}
