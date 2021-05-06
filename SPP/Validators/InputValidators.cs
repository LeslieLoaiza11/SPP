using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SPP.Validators
{
    public class InputValidators
    {
        public static bool EmailStructureValidator(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool CompleteTextbox(string name, string lastName, string enrollment, string phone)
        {
            if (name.Length > 3 && lastName.Length > 3 && enrollment.Length > 3 && phone.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool LoginLength(string password)
        {
            if (password.Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool PasswordLengthValidator(string password, string confirmPassword)
        {
            if (password.Length > 6 && confirmPassword.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool WordSructureValidator(string name)
        {
            String expresion;
            expresion = "([A-ZÑÁÉÍÓÚ][a-z]*)([\\s\\\'-][A-ZÑÁÉÍÓÚ][a-z]*)*";

            if (Regex.IsMatch(name, expresion))
            {
                if (Regex.Replace(name, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool NicknameSructureValidator(string name)
        {
            String expresion;
            expresion = "^[a-zA-Z0-9]+$";

            if (Regex.IsMatch(name, expresion))
            {
                if (Regex.Replace(name, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool CompleteTextboxLinkedOrganization(string name, string address, string phone)
        {
            return name.Length > 3 && address.Length > 3 && phone.Length > 3;
        }

        public static bool PhoneSructureValidator(string phone)
        {
            String expresion;
            expresion = "\\d";

            if (Regex.IsMatch(phone, expresion))
            {
                if (Regex.Replace(phone, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
