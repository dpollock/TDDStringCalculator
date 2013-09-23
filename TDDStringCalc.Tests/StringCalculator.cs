using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            var delimiters = new List<string> { ",", "\n" };
            //strip off the first line if it starts with //
            if (numbers.StartsWith("//"))
            {
                var firstLineBreak = numbers.IndexOf('\n');
                var possibleDelimiters = numbers.Substring(2, firstLineBreak - 2);
                var list = new List<string>();
                foreach (Match m in Regex.Matches(possibleDelimiters, @"\[(.*?)\]"))
                {
                    list.Add(m.Groups[1].Value);
                    possibleDelimiters = possibleDelimiters.Replace(m.Groups[0].Value, "");
                }
                delimiters.AddRange(list);
                if (possibleDelimiters.Length > 0)
                    delimiters.Add(possibleDelimiters[0].ToString());

                numbers = numbers.Substring(firstLineBreak + 1, numbers.Length - firstLineBreak - 1);
            }

            var splitUp = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
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