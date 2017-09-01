using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using StringCalculator.NamedExceptions;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const string DefaultDelimiter = ",";
        private const string DelimiterDefinitionChars = "//";
        private const string NewDelimiterStart = "[";
        private const string NewDelimiterEnd = "]";

        public int Add(string numbers)
        {
            if (numbers == null)
            {
                return 0;
            }

            List<string> delimiters = new List<string>();
            string handledNumbers;

            if (numbers.StartsWith(DelimiterDefinitionChars))
            {
                delimiters.AddRange(GetDelimiters(numbers));
                handledNumbers = HandleDelimiterLine(numbers);
            }
            else
            {
                delimiters.Add(DefaultDelimiter);
                handledNumbers = numbers;
            }

            var delimiter = delimiters[0];

            handledNumbers = handledNumbers.Replace("\n", delimiter);

            handledNumbers = delimiters.Aggregate(handledNumbers, (current, record) => current.Replace(record, delimiter));

            var numbersConvertedToListOfInts = handledNumbers.Split(delimiter.ToCharArray()).Select(y => y == string.Empty ? 0 : int.Parse(y));
            
            ValidateExistenceOfNegativeNumbers(numbersConvertedToListOfInts);
            numbersConvertedToListOfInts = RemoveNumbersHigherThanThowsend(numbersConvertedToListOfInts);


            var sum = numbersConvertedToListOfInts.Sum();

            return sum;
        }

        private IEnumerable<string> GetDelimiters(string numbers)
        {
            var numbersWithoutDefinitionChars = numbers.Replace(DelimiterDefinitionChars, string.Empty);
            var lineOfDelimiters = string.Join(string.Empty, numbersWithoutDefinitionChars.TakeWhile(x => x != '\n'));


            if (!numbersWithoutDefinitionChars.StartsWith(NewDelimiterStart))
            {
                return new List<string>
                {
                    lineOfDelimiters
                };
            }

            return lineOfDelimiters.Split(char.Parse(NewDelimiterStart), char.Parse(NewDelimiterEnd)).Where(x => x != string.Empty);
        }

        private string HandleDelimiterLine(string numbers)
        {
            return numbers.Remove(0, numbers.IndexOf("\n", StringComparison.InvariantCulture) + 1);
        }

        private void ValidateExistenceOfNegativeNumbers(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(x => x < 0);

            if (negativeNumbers.Any())
            {
                throw new NegativeNumberException(string.Join(DefaultDelimiter, negativeNumbers));
            }
        }

        private IEnumerable<int> RemoveNumbersHigherThanThowsend(IEnumerable<int> intNumbers)
        {
            return intNumbers.Where(x => x <= 1000);
        }
    }
}
