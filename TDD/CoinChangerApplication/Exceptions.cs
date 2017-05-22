using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangerApplication
{
    public class ZeroOrNegativeCoinTypeException : Exception
    {
        public ZeroOrNegativeCoinTypeException(string message) : base(message)
        {

        }
    }

    public class NoPossibleExchangeException : Exception
    {
        public NoPossibleExchangeException(string message) : base(message)
        {
        }
    }
}
