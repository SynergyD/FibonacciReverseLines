using System.IO;
using System.Text;
using ReverseFibonacciLines.Services.Interfaces;

namespace ReverseFibonacciLines.Services
{
    public class FileService : IFileService
    {
        public StreamReader Open(string filePath)
        {
            return new StreamReader(filePath);
        }

        public StreamWriter Open(string filePath, bool isAppend, Encoding encoding)
        {
            return new StreamWriter(filePath,isAppend,encoding);
        }
    }
}