using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            Regex regex = new Regex($"//(.*?)\n");
            Match regexMatch = regex.Match(numbers);
            string delimeter = regexMatch.Groups[1].ToString();

            string[] delimeterArray = null;

            if (string.IsNullOrEmpty(delimeter))
            {
                delimeterArray = new string[] { "\n", "," };
            }
            else
            {
                List<string> delimeterList = delimeter.Split('[', ']').Where(x => !string.IsNullOrEmpty(x)).ToList();
                delimeterList.Add("\n");

                delimeterArray = delimeterList.ToArray();
            }

            int tempOutput;
            List<string> list = numbers.Split(delimeterArray, StringSplitOptions.None).Where(x => int.TryParse(x, out tempOutput)).ToList();

            int result = 0;

            List<int> negatives = new List<int>();

            foreach (var num in list)
            {
                int parsedNum = int.Parse(num);

                if (parsedNum < 0)
                {
                    negatives.Add(parsedNum);
                }
                else if (parsedNum <= 1000)
                {
                    result += parsedNum;
                }
            }

            if (negatives.Count() > 0)
            {
                throw new NegativeNumberException(negatives);
            }

            return result;
        }

    }
}
