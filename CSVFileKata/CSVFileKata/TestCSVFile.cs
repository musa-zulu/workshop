using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace CSVFileKata
{
    [TestFixture]
    public class TestCSVFile
    {
        [Test]
        public void Construct_DoesNotThrow()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
           Assert.DoesNotThrow(() => new CSVFileWriter(Substitute.For<IFolder>()));
        }

        [Test]
        public void Construct_GivenIFolderIsNull_ShouldThrowException()  
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => new CSVFileWriter(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("folder", ex.ParamName);
        }
       
        [Test]
        public void AddToFolder_GivenOneCustomer_ShouldExpectAppendLineToHaveBeenCalled()
        {
            //---------------Set up test pack-------------------
            const string line = "0123456789 musa";
            const string fileName = "file1.csv";
            var folder = Substitute.For<IFolder>();
            var csvFile = new CSVFileWriter(folder);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            csvFile.AddToFile(fileName, line);
            //---------------Test Result -----------------------
           folder.Received().AppendLine(fileName, line);
        }
    }
}