using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorEngine
{
    public class Validator
    {
        public bool ValidateEmailAdress(string emailToValidate)
        {
            try
            {
                var addr = new MailAddress(emailToValidate);
                return addr.Address == emailToValidate;
            }
            catch
            {
                throw new NotValidEmailAdress("Not valid Email.");
            }
        }
    }
}
