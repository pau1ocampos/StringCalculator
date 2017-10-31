using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.NamedExceptions;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private readonly StringCalculator _calculator = new StringCalculator();

        [TestMethod]
        public void StringCalculator_InputEmptyString_Return0()
        {
            // Arrange
            var fakeInput = string.Empty;
            var expectedResult = 0;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_InputStringOne_ReturnsOne()
        {
            // Arrange
            var fakeInput = "1";
            var expectedResult = 1;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputStringOneCommaTwo_ReturnsThree()
        {
            // Arrange
            var fakeInput = "1,2";
            var expectedResult = 3;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputStringWithOneZeroEmptyEmptyEmpty_ReturnsOne()
        {
            // Arrange
            var fakeInput = "1,0,,,";
            var expectedResult = 1;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputStringWithEmptyEmptyEmpty_ReturnsZero()
        {
            // Arrange
            var fakeInput = ",,";
            var expectedResult = 0;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputNullString_ReturnsZero()
        {
            // Arrange
            string fakeInput = null;
            var expectedResult = 0;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputOneNewLineOne_ReturnsTwo()
        {
            // Arrange
            var fakeInput = "1\n1";
            var expectedResult = 2;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputOneNewLineTwoThree_ReturnsSix()
        {
            // Arrange
            var fakeInput = "1\n2,3";
            var expectedResult = 6;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputOneOneNewLineOne_ReturnsThree()
        {
            // Arrange
            var fakeInput = "1,1\n1";
            var expectedResult = 3;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputNewDelimiterAndOneTwo_ReturnsThree()
        {
            // Arrange
            var fakeInput = "//;\n1;2";
            var expectedResult = 3;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputNewDelimiterAndOneTwoThreeNewLineThreeDelimiter_ReturnsNine()
        {
            // Arrange
            var fakeInput = "//;\n1;2;3\n3;";
            var expectedResult = 9;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputNewDelimiterAndEmptyEmptyThreeNewLineThreeDelimiter_ReturnsSix()
        {
            // Arrange
            var fakeInput = "//;\n;;3\n3;";
            var expectedResult = 6;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeNumberException), "Negatives not allowed: -1.")]
        public void StringCalculator_Add_InputOneTwoMinusOne_ExceptionWithStringWithNegativeNumbers()
        {
            // Arrange
            var fakeInput = "1,2,-1";
            // Act
            _calculator.Add(fakeInput);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeNumberException), "Negatives not allowed: -1, -2. -3.")]
        public void StringCalculator_Add_InputWithNewDelimiterAndMinusOneMinusTwoMinusThree_ExceptionWithStringWithNegativeNumbers()
        {
            // Arrange
            var fakeInput = "//#\n-1#-2#-3";
            // Act
            _calculator.Add(fakeInput);
        }

        [TestMethod]
        public void StringCalculator_Add_InputNewDelimiterAndEmptyEmptyThreeNewLineThreeThowsendThowsendAndOne_ReturnsThowsendAndSix()
        {
            // Arrange
            var fakeInput = "//;\n;;3\n3;1000;1001";
            var expectedResult = 1006;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputNewDelimiterAndEmptyEmptyThowsendAndOne_ReturnsZero()
        {
            // Arrange
            var fakeInput = "//;\n;;1001";
            var expectedResult = 0;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputEmptyEmptyThowsendAndOne_ReturnsZero()
        {
            // Arrange
            var fakeInput = ",,1001";
            var expectedResult = 0;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputOneEmptyThowsendAndOne_ReturnsOne()
        {
            // Arrange
            var fakeInput = "1,,1001";
            var expectedResult = 1;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputOneThowsendThowsendAndOne_ReturnsThowsendAndOne()
        {
            // Arrange
            var fakeInput = "1,1000,1001";
            var expectedResult = 1001;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputDelimiterWithMoreThanOneCharOneTwoThreeFour_ReturnsTen()
        {
            // Arrange
            var fakeInput = "//*#*\n1*#*2*#*3*#*4";
            var expectedResult = 10;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputDelimiterWithFourCharsOneTwoThreeFourNewLineThowsendTwothowsendDelimiter_Returns1010()
        {
            // Arrange
            var fakeInput = "//$%&/\n1$%&/2$%&/3$%&/4\n1000$%&/2000$%&/";
            var expectedResult = 1010;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputTwoDelimitersOfOneCharOneOneOneOne_ReturnsFour()
        {
            // Arrange
            var fakeInput = "//[*][|]\n1*1|1*1";
            var expectedResult = 4;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StringCalculator_Add_InputTwoDelimitersOfTwoOrMoreCharOneOneOneOne_ReturnsFour()
        {
            // Arrange
            var fakeInput = "//[****][!!|]\n1****1!!|1****1";
            var expectedResult = 4;
            // Act
            var result = _calculator.Add(fakeInput);
            // Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
