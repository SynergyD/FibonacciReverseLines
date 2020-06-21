namespace ReverseFibonacciLines.Models.Interfaces
{
    public interface IFileWorker
    {
        string[] GetFibonacciLines(string filePath);
        void FillFileByReverseLines(string[] lines, string path = "../../output.txt", bool isAppendToFile = false);
    }
}