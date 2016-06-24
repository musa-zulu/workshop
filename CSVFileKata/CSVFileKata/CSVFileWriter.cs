using System;

namespace CSVFileKata
{
    public class CSVFileWriter : ICSVFileWriter
    {
        private readonly IFolder _folder;

        public CSVFileWriter(IFolder folder)
        {
            if (folder == null)
                throw new ArgumentNullException("folder");
            _folder = folder;
        }

        public void AddToFile(string fileName, string line)
        {
            _folder.AppendLine(fileName, line);
        }
    }
}