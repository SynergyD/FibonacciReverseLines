using System.IO;
using System.Text;

namespace ReverseFibonacciLines.Services.Interfaces
{
    public interface IFileService
    {
        StreamReader Open(string filePath);
        StreamWriter Open(string filePath, bool isAppend, Encoding encoding);
    }
}