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
    /// Lógica de interacción para ConsultFile.xaml
    /// </summary>
    public partial class ConsultFile : Window
    {
        public ObservableCollection<FileTable> Reportes { get; } = new ObservableCollection<FileTable>();
        public ConsultFile()
        {
            InitializeComponent();
            DataContext = this;
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
            // El "4" es el id de un expediente pero falta hacer el Login y de ahí sacar el expediente del estudiante que ingresó
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
            if(ReportsListView.SelectedIndex != -1)
            {
                var selectedReport = (FileTable)ReportsListView.SelectedItem;
                System.Diagnostics.Process.Start(selectedReport.Path);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}