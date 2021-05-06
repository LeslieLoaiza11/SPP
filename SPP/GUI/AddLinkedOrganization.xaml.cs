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
using SPP.Validators;
using SPP.DBQuerys;
using System.ComponentModel;

namespace SPP.GUI
{
    /// <summary>
    /// Lógica de interacción para AddLinkedOrganization.xaml
    /// </summary>
    public partial class AddLinkedOrganization : Window
    {
        public AddLinkedOrganization()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void FillObjectLinkedOrganization()
        {
            string name = this.TxtBoxName.Text;
            string address = this.TxtBoxAddress.Text;
            string phone = this.TxtBoxPhone.Text;

            if (InputValidators.CompleteTextboxLinkedOrganization(name, address, phone))
            {
                if (InputValidators.WordSructureValidator(name) && InputValidators.PhoneSructureValidator(phone))
                {
                    Domain.DomainLinkedOrganization linkedOrganization = new Domain.DomainLinkedOrganization();
                    linkedOrganization.Name = name;
                    linkedOrganization.Address = address;
                    linkedOrganization.Phone = phone;
                    DBQueryClass.InsertANewLinkedOrganization(linkedOrganization, out int status);
                    if (status == 0)
                    {
                        MessageBox.Show("Organización vinculada registrada en el sistema");
                    }
                    else if (status == 3)
                    {
                        MessageBox.Show("Error. Ya existe una organización vinculada con ese nombre");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al registrar los datos");
                    }
                }
                else
                {
                    this.TxtBoxName.BorderBrush = Brushes.Red;
                    this.TxtBoxAddress.BorderBrush = Brushes.Red;
                    this.TxtBoxPhone.BorderBrush = Brushes.Red;
                    MessageBox.Show("Campos inválidos.");
                }
            }
            else
            {
                this.TxtBoxName.BorderBrush = Brushes.Red;
                this.TxtBoxAddress.BorderBrush = Brushes.Red;
                this.TxtBoxPhone.BorderBrush = Brushes.Red;
                MessageBox.Show("Favor de llenar todos los campos.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillObjectLinkedOrganization();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
