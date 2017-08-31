using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private readonly StringCalculator _calculator = new StringCalculator();

        [TestMethod]
        public void StringCalculator_InputEmptyString_ReturnZero()
        {
            // Arrange
            var fakeInput = string.Empty;
            var expectedResult = 0;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
