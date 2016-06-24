using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace CSVFileKata
{
    [TestFixture]
    public class TestCustomerSerializer
    {
        [Test]
        public void Construct_DoesNotThrow()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new CustomerSerializer(Substitute.For<ICSVFileWriter>()));
            //---------------Test Result -----------------------
        }

        [Test]
        public void Contruct_GivenICustomerParserIsNull_ShouldThrow()
        {
            //---------------Set up test pack------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomerSerializer(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("iCsvFileWriter", ex.ParamName);
        }

        [Test]
        public void Serialize_GivenEmptyListOfCustomers_ShouldThrowExcption()
        {
            //---------------Set up test pack-------------------
            var customer = new List<Customer>();
            var csvFileWriter = Substitute.For<ICSVFileWriter>();
            var customerParser = new CustomerSerializer(csvFileWriter);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = Assert.Throws<ApplicationException>(() => customerParser.Serialize(customer));
            //---------------Test Result -----------------------
            Assert.AreEqual(string.Empty, actual.Data);
            Assert.AreEqual("customers", actual.Message);
        }



        [Test]
        public void Serialize_GivenOneCustomerAndFileName_ShouldExpecteAddToFileToHaveBeenCalled()
        {
            //---------------Set up test pack-------------------
            const string fileName = "file1.csv";
            var customers = CreateCustomers(1);
            var csvFileWriter = Substitute.For<ICSVFileWriter>();
            var customerParser = new CustomerSerializer(csvFileWriter);
            //---------------Assert Precondition----------------
            csvFileWriter.DidNotReceive().AddToFile(Arg.Any<string>(), Arg.Any<string>());
            //---------------Execute Test ----------------------
            customerParser.Serialize(customers, fileName);
            //---------------Test Result -----------------------
            csvFileWriter.Received().AddToFile(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void Serialize_GivenTwoCustomersAndFileName_ShouldExpectAddToFileToHaveBennCalledTwicee()
        {
            //---------------Set up test pack-------------------
            const string fileName = "file";
            var customers = CreateCustomers(2);
            var csvFileWriter = Substitute.For<ICSVFileWriter>();
            var customerParser = new CustomerSerializer(csvFileWriter);
            //---------------Assert Precondition----------------
            csvFileWriter.DidNotReceive().AddToFile(Arg.Any<string>(), Arg.Any<string>());
            //---------------Execute Test ----------------------
            customerParser.Serialize(customers, fileName);
            //---------------Test Result -----------------------
            csvFileWriter.Received(2).AddToFile(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void Serialize_Given12Customers_ShouldWriteFirst10CustomersToFile1()
        {
            //---------------Set up test pack-------------------
            const string fileName = "file";
            const string fileName1 = "file1";
            const string fileName2 = "file2";
            var customers = CreateCustomers(12);
            var csvFileWriter = Substitute.For<ICSVFileWriter>();

            var customerParser = new CustomerSerializer(csvFileWriter);
            //---------------Assert Precondition----------------
            csvFileWriter.DidNotReceive().AddToFile(Arg.Any<string>(), Arg.Any<string>());
            //---------------Execute Test ----------------------
            customerParser.Serialize(customers, fileName);
            //---------------Test Result -----------------------
            csvFileWriter.Received(10).AddToFile(fileName1, Arg.Any<string>());
            csvFileWriter.Received(2).AddToFile(fileName2, Arg.Any<string>());
        }

        [Test]
        public void Serialize_Given43Customers_ShouldWriteCustomersTo5DifferentFiles()
        {
            //---------------Set up test pack-------------------
            const string fileName = "file";
            const string fileName1 = "file1";
            const string fileName2 = "file2";
            const string fileName3 = "file3";
            const string fileName4 = "file4";
            const string fileName5 = "file5";
            var customers = CreateCustomers(43);
            var csvFileWriter = Substitute.For<ICSVFileWriter>();

            var customerParser = new CustomerSerializer(csvFileWriter);
            //---------------Assert Precondition----------------
            csvFileWriter.DidNotReceive().AddToFile(Arg.Any<string>(), Arg.Any<string>());
            //---------------Execute Test ----------------------
            customerParser.Serialize(customers, fileName);
            //---------------Test Result -----------------------
            csvFileWriter.Received(10).AddToFile(fileName1, Arg.Any<string>());
            csvFileWriter.Received(10).AddToFile(fileName2, Arg.Any<string>());
            csvFileWriter.Received(10).AddToFile(fileName3, Arg.Any<string>());
            csvFileWriter.Received(10).AddToFile(fileName4, Arg.Any<string>());
            csvFileWriter.Received(3).AddToFile(fileName5, Arg.Any<string>());
        }

        private static List<Customer> CreateCustomers(int numberOfCustomers)
        {
            var customers = new List<Customer>();
            var customer = new Customer
            {
                Name = "ntokozo",
                ContactNumber = "1234567890"
            };

            for (var i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(customer);
            } 
            return customers;
        }

        private static List<string> CreateFileName(int fileNameCount)
        {
            var count = 0;
            List<string> fileName = new List<string>();

            while (fileNameCount > 0)
            {
                fileName.Add("file" + count);
                fileNameCount--;
            }
            return fileName;
        }
    }
}
