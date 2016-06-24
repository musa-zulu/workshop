using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace StringKataCalculator
{
    [TestFixture]
    public class TestStringCalculator
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Add_GivenNumber_ShouldReturnThatNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "20";
            const int expected = 20;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input); 
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenTwoNumbersSeparatedByComma_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyNumbersSeparatedByComma_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyNumbersWithNewLineInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyNumbersWithADelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersWithANegativeNumbers_ShouldThrowApplicationException()
        {
            //---------------Set up test pack-------------------
            const string input = "1,-2,3";
            const string expected = "negatives are not allowed : -2";
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void Add_GivenNumbersWithManyNegativeNumbers_ShouldThrowApplicationException()
        {
            //---------------Set up test pack-------------------
            const string input = "1,-2,3,-4";
            const string expected = "negatives are not allowed : -2,-4";
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreNumbersGreaterThanThousandAndReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenDelimitersOfAnyLength_ShouldReturnTheSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenMultipleDelimitersOfAnyLength_ShouldReturnTheSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*******][&]\n1*******2&3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }


        private static StringCalculator CreateCalculator()
        {
            return new StringCalculator();
        }
    }
}