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

            var splitUp = numbers.Split(new[] {',','\n'});
            var sum = splitUp.Sum(s => int.Parse(s));

            return sum;
        }
    }
}