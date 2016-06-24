using System;

namespace CSVFileKata
{
    public interface IFolder
    {
        void AppendLine(string fileName, string line);
    }
}