using System;

namespace StringCalculator.NamedExceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base("Negatives not allowed: " + message + ".") { }
    }
}
