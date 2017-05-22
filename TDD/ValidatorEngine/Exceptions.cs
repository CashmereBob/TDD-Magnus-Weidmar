using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorEngine
{
    public class NotValidEmailAdress : Exception
    {
        
        public NotValidEmailAdress(string message) : base(message)
        {
           
        }
    }


}
