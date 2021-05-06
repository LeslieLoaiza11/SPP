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
using SPP.Validators;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SPP.GUI
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class RegistrationRequest : Window
    {
        DataAccess.DAO.StudentDAO studentDAO = new DataAccess.DAO.StudentDAO();
        public RegistrationRequest()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
        }
        private void FillObjectRegistration()
        {
            string name = this.TxtBoxName.Text;
            string lastName = this.TxtBoxLName.Text;
            string enrollment = this.TxtBoxEnrollment.Text;
            string email = this.TxtBoxEmail.Text;
            string phone = this.TxtBoxPhone.Text;
            string password = this.PbPassword.Password;
            string confirmPassword = this.PbConfirmPassword.Password;

            if (InputValidators.EmailStructureValidator(email))
            {
                if (InputValidators.CompleteTextbox(name, lastName, enrollment, phone))
                {
                    if (InputValidators.PasswordLengthValidator(password, confirmPassword))
                    {
                        if (password.Equals(confirmPassword))
                        {
                            Domain.DomainClasses.DomainStudent student = new Domain.DomainClasses.DomainStudent();
                            
                            student.Name = name;
                            student.LastName = lastName;
                            student.Enrollment = enrollment;
                            student.Email = email;
                            student.Phone = phone;
                            student.Password = confirmPassword;
                            try
                            {
                                bool isRegistered = studentDAO.AddStudent(student);
                                if (isRegistered)
                                {
                                    MessageBox.Show("Su registro ha sido enviado de manera correcta");
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("No se ha podido registrar al usuario porque ya existe");
                                }
                            }catch (SqlException)
                            {
                                MessageBox.Show("Se perdió la conexión con la base de datos");
                            }
                            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                            {
                                Exception raise = dbEx;
                                foreach (var validationErrors in dbEx.EntityValidationErrors)
                                {
                                    foreach (var validationError in validationErrors.ValidationErrors)
                                    {
                                        string message = string.Format("{0}:{1}",
                                            validationErrors.Entry.Entity.ToString(),
                                            validationError.ErrorMessage);
                                        // raise a new exception nesting  
                                        // the current instance as InnerException  
                                        raise = new InvalidOperationException(message, raise);
                                    }
                                }
                                throw raise;
                            }
                        }
                        else
                        {
                            this.PbPassword.BorderBrush = Brushes.Red;
                            this.PbConfirmPassword.BorderBrush = Brushes.Red;
                            this.txtBlockNotification.Text = "Las contraseñas no coinciden";
                        }
                    }
                    else
                    {
                        this.PbConfirmPassword.BorderBrush = Brushes.Red;
                        this.PbPassword.BorderBrush = Brushes.Red;
                        this.txtBlockNotification.Text = "La contraseña debe tener al menos 6 caracteres";
                    }
                }
                else
                {
                    this.TxtBoxLName.BorderBrush = Brushes.Red;
                    this.TxtBoxName.BorderBrush = Brushes.Red;
                    this.TxtBoxEnrollment.BorderBrush = Brushes.Red;
                    this.txtBlockNotification.Text = "Algunos campos de texto se encuentran vacíos";
                }
            }
            else
            {
                this.TxtBoxEmail.BorderBrush = Brushes.Red;
                this.txtBlockNotification.Text = "El correo electrónico tiene una estructura incorrecta";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillObjectRegistration();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void AlphabeticValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-ZñÑÁÉÍÓÚ]");
            e.Handled = regex.IsMatch(e.Text);
            //"[^a-zA-Z]"

        }
    }
}
