using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangerApplication
{
    public class CoinChanger
    {
        private List<decimal> coinTypes;

        public CoinChanger(List<decimal> coinTypes)
        {
            this.coinTypes = coinTypes;
        }

        public Dictionary<decimal, int> MakeChange(decimal amount)
        {
        
            if(coinTypes.Count() == 0 || coinTypes == null)
            {
                throw new NoPossibleExchangeException("Missing CoinType.");
            }

            if (amount <= 0)
            {
                throw new NoPossibleExchangeException("Exchange amount is 0 or negative.");
            }

            var change = new Dictionary<decimal, int>();

            var sortedCoinTypes = coinTypes.OrderByDescending(x => x).ToList();
            var amountLeft = amount;

            foreach (var coinType in sortedCoinTypes)
            {
                while (amountLeft >= coinType)
                {
                    if (coinType <= 0)
                    {
                        throw new ZeroOrNegativeCoinTypeException("Invalid CoinType.");
                    }

                    if (change.ContainsKey(coinType))
                    {
                        change[coinType] += 1;
                    }
                    else
                    {
                        change[coinType] = 1;
                    }
                    
                    amountLeft -= coinType;
                }
            }

            if (change.Count() == 0)
            {
                throw new NoPossibleExchangeException("No exchange possible.");
            }

            return change;
        }
    }
}
