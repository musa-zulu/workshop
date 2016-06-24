using System.Runtime.InteropServices;
using NUnit.Framework;

namespace FizzBuzzKata
{
    [TestFixture]
    public class TestFizzBuzz
    {
        [Test]
        public void IsFizzBuzz_GivenOne_ShouldReturnOne()
        {
            //---------------Set up test pack-------------------
            const int input = 1;
            const string expected = "1";
            var fizzBuzz = new FizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenTwo_ShouldReturnTwo()
        {
            //---------------Set up test pack-------------------
            const int input = 2;
            const string expected = "2";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenThree_ShouldReturnFizz()
        {
            //---------------Set up test pack-------------------
            const int input = 3;
            const string expected = "Fizz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenFour_ShouldReturnFour()
        {
            //---------------Set up test pack-------------------
            const int input = 4;
            const string expeted = "4";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expeted, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenFive_ShouldReturnBuzz()
        {
            //---------------Set up test pack-------------------
            const int input = 5;
            const string expected = "Buzz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenSix_ShouldReturnSix()
        {
            //---------------Set up test pack-------------------
            const int input = 6;
            const string expected = "Fizz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenNine_ShouldReturnFizz()
        {
            //---------------Set up test pack-------------------
            const int input = 9;
            const string expected = "Fizz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_GivenTen_ShouldReturnBuzz()
        {
            //---------------Set up test pack-------------------
            const int input = 10;
            const string expected = "Buzz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsFizzBuzz_Given15_ShouldReturnFizzBuzz()
        {
            //---------------Set up test pack-------------------
            const int input = 15;
            const string expected = "FizzBuzz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsBuzz_Given20_ShouldReturnBuzz()
        {
            //---------------Set up test pack-------------------
            const int input = 20;
            const string expected= "Buzz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void IsBuzz_Given30_ShouldReturnFizzBuzz()
        {
            //---------------Set up test pack-------------------
            const int input = 30;
            const string expected= "FizzBuzz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }[Test]
        public void IsBuzz_Given75_ShouldReturnFizzBuzz()
        {
            //---------------Set up test pack-------------------
            const int input = 75;
            const string expected= "FizzBuzz";
            var fizzBuzz = CreateFizzBuzz();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = fizzBuzz.IsFizzBuzz(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        private static FizzBuzz CreateFizzBuzz()
        {
            return new FizzBuzz();
        }
    }
}