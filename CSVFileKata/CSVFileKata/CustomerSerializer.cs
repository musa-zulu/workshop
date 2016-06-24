using System;
using System.Collections.Generic;

namespace CSVFileKata
{
    public class CustomerSerializer : ICustomerSerializer
    {
        private readonly ICSVFileWriter _iCsvFileWriter;

        public CustomerSerializer(ICSVFileWriter iCsvFileWriter)
        {
            if (iCsvFileWriter == null)
            {
                throw new ArgumentNullException(nameof(iCsvFileWriter));
            }
            _iCsvFileWriter = iCsvFileWriter;
        }

        public void Serialize(List<Customer> customers, string fileName = null)
        {
            if (customers.Count == 0) throw new ApplicationException("customers");

            var count = 0;
            var fileNameCount = 1;
            foreach (var customer in customers)
            { 
                var name = customer.Name;
                var contactNumber = customer.ContactNumber;
                var line = contactNumber + " " + name;

                WriteBatchToFile(fileName, fileNameCount, line); 
                count++;

                if (!IsDivisibleByTen(count)) continue;
                count = 0;
                fileNameCount++;
            }
        }

        private void WriteBatchToFile(string fileName, int fileNameCount, string line)
        {
            var newFileName = fileName + fileNameCount;
            _iCsvFileWriter.AddToFile(newFileName, line);
        }
        
        private static bool IsDivisibleByTen(int count)
        {
            return count % 10 == 0;
        }
    }
}