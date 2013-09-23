using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TDDStringCalc.Tests
{
    public class StringCalculator
    {
        public int Add(string numberString)
        {
            if (string.IsNullOrWhiteSpace(numberString))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };
            var negativeNumbers = new List<int>();

            //strip off the first line if it starts with //
            var numbersWithOutCommentLine = ReadDelimiterLine(numberString, delimiters);

            string[] numbersAsStrings = numbersWithOutCommentLine.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            foreach (string s in numbersAsStrings)
            {
                int num = int.Parse(s);
             
                if (num < 0)
                {
                    negativeNumbers.Add(num);
                }
                if (num >= 1000)
                    continue;

                sum += num;
            }

            if (negativeNumbers.Any())
            {
                throw new Exception(string.Format("Negative numbers not Allowed: {0}",
                    negativeNumbers.Select(x => x.ToString()).Aggregate((a, b) => a + " " + b)));
            }

            return sum;
        }

        private static string ReadDelimiterLine(string numbers, List<string> delimiters)
        {
            if (!numbers.StartsWith("//"))
                return numbers;

            var newDelimters = new List<string>();

            int firstLineBreak = numbers.IndexOf('\n');
            string possibleDelimiters = numbers.Substring(2, firstLineBreak - 2);

            //find matched [] groups and remove them from the string.
            foreach (Match m in Regex.Matches(possibleDelimiters, @"\[(.*?)\]"))
            {
                newDelimters.Add(m.Groups[1].Value);
                possibleDelimiters = possibleDelimiters.Replace(m.Groups[0].Value, "");
            }
            delimiters.AddRange(newDelimters);

            //if theres anything left in the string use it as delimiter also.
            if (possibleDelimiters.Length > 0)
                delimiters.Add(possibleDelimiters[0].ToString());

            //strip the delimter line before returning.
            numbers = numbers.Substring(firstLineBreak + 1, numbers.Length - firstLineBreak - 1);
            return numbers;
        }
    }
}