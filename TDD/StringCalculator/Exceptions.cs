using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class NegativeNumberException : Exception
    {
        public List<int> Negatives { get; private set; }
        public override string Message { get; }

        public NegativeNumberException(List<int> negatives)
        {
            StringBuilder message = new StringBuilder();

            message.Append("Negatives not allowed: ");

            foreach (var negative in negatives)
            {
                message.Append(negative + " ");
            }

            Message = message.ToString().TrimEnd();
        }
    }
}
