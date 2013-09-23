using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDStringCalc.Tests
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var delimiters = new List<char> { ',', '\n' };
            //strip off the first line if it starts with //
            if (numbers.StartsWith("//"))
            {
                var firstLineBreak = numbers.IndexOf('\n');
                var delimiter = numbers.Substring(2, 1);
                delimiters.Add(delimiter.ToCharArray()[0]);
                numbers = numbers.Substring(firstLineBreak + 1, numbers.Length - firstLineBreak - 1);
            }

            var splitUp = numbers.Split(delimiters.ToArray());
            var sum = 0;
            var negativeNumbers = new List<int>();
            foreach (string s in splitUp)
            {
                var n = int.Parse(s);
                if (n < 0)
                {
                    negativeNumbers.Add(n);
                }
                if (n >= 1000)
                    continue;

                sum += n;
            }

            if (negativeNumbers.Any())
            {
                throw new Exception(string.Format("Negative numbers not Allowed: {0}", negativeNumbers.Select(x => x.ToString()).Aggregate((a, b) => a + " " + b)));
            }

            return sum;
        }
    }
}