using NUnit.Framework;

namespace SAIDNumberKata
{
    [TestFixture]
    public class TestIdNumber
    {
        [Test]
        public void ExtractIDParts_GivenValidIDNumber_ShouldReturnDateOfBirth()
        {
            //---------------Set up test pack-------------------
            const string id = "8012155009082";
            const string expected = "15-12-1980";
            var sut = new IdNumber();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = sut.ExtractIDParts(id);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual.DateOfBirth);
        }

        [Test]
        public void GetCentury_GivenYearIsLessOrEqual20_ShouldReturn20()
        {
            //---------------Set up test pack-------------------
            const string year = "20";
            const string expected = "20";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = IdNumber.GetCentury(year);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCentury_GivenYearIsGreaterThan20_ShouldReturn19()
        {
            //---------------Set up test pack-------------------
            const string year = "21";
            const string expected = "19";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = IdNumber.GetCentury(year);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExtractIDParts_GivenValidIDNumber_ShouldReturnGender()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "8012155009082";
            const Gender expected = Gender.Male;
            var sut = new IdNumber();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = sut.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual.Gender);
        }

        [Test]
        public void ExtractIDParts_GivenValidIDNumberWith0AsCitizenship_ShouldReturnSA()
        {
            //---------------Set up test pack-------------------
            const  string  idNumber = "8012155009082";
            const string expected = "SA";
            var sut = new IdNumber();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = sut.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual.Citizenship);
        }

        [Test]
        public void ExtractIDParts_GivenValidIDNumberWith1AsCitizenship_ShouldReturnOther()
        {
            //---------------Set up test pack-------------------
            const  string  idNumber = "8012155009182";
            const string expected = "Other";
            var sut = new IdNumber();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = sut.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual.Citizenship);
        }



    }
}
