using System;
using NUnit.Framework;

namespace AgeCalculatorKata
{
    [TestFixture]
    public class TestAgeCalculator
    {
        [Test]
        public void CalculateAge_GivenCurrentDateAndBirthDateAreTheSame_ShouldReturnZero()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1983, 01, 01);
            var givenDate = new DateTime(1983, 01, 01);
            const int expected = 0;
            var ageCalculator = new AgeCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = ageCalculator.CalculateAge(birthDate, givenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAge_GivenDateEqualsBirthdayOneYearLater_ShouldReturnOne()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1983, 01, 01);
            var givenDate = new DateTime(1984, 01, 01);
            const int expected = 1;
            var ageCalculator = CreateAgeCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = ageCalculator.CalculateAge(birthDate, givenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAge_GivenCurrentDateIsBeforeBirthDate_ShouldThrowApplicationException()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1983, 01, 01);
            var givenDate = new DateTime(1982, 01, 01);
            const string expected = "Current date is before birth date";
            var ageCalculator = CreateAgeCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => ageCalculator.CalculateAge(birthDate, givenDate));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void CalculateAge_GivenCurrentDateYearAndMonthIsBeforeBirth_ShouldThrowApplicationException()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1983, 03, 01);
            var givenDate = new DateTime(1982, 01, 01);
            const string expected = "Current date is before birth date";
            var ageCalculator = CreateAgeCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => ageCalculator.CalculateAge(birthDate, givenDate));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void CalculateAge_GivenCurrentDateIsOneDayBeforeBirthday_ShouldReturn17()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1983, 09, 30);
            var givenDate = new DateTime(2001, 09, 29);
            const int expected = 17;
            var ageCalculator = CreateAgeCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = ageCalculator.CalculateAge(birthDate, givenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CalculateAge_GivenCurrentDateIsOneMonthBeforeBirthday_ShouldReturn17()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1983, 09, 30);
            var givenDate = new DateTime(2001, 08, 30);
            const int expected = 17;
            var ageCalculator = CreateAgeCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = ageCalculator.CalculateAge(birthDate, givenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAge_GivenBirthDateYearIsLeapYearAndDayIsBefore28_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(2016, 02, 29);
            var givenDate = new DateTime(2017, 02, 27);
            var ageCalculator = CreateAgeCalculator();
            const int expected = 0;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = ageCalculator.CalculateAge(birthDate, givenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAge_GivenBirthDateYearIsLeapYear_ShouldReturn1()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(2016, 02, 29);
            var givenDate = new DateTime(2017, 02, 28);
            var ageCalculator = CreateAgeCalculator();
            const int expected = 1;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = ageCalculator.CalculateAge(birthDate, givenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        
        private static AgeCalculator CreateAgeCalculator()
        {
            return new AgeCalculator();
        }
    }
}
