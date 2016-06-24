namespace CSVFileKata
{
    public interface ICSVFileWriter
    {
        void AddToFile(string fileName, string line);
    }
}
