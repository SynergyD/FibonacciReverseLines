using System.IO;
using System.Text;
using Moq;
using ReverseFibonacciLines.Models;
using ReverseFibonacciLines.Models.Interfaces;
using ReverseFibonacciLines.Services.Interfaces;
using Xunit;

namespace ReverseFibonacciLinesTests
{
    public class FileWorkerTests
    {
        private readonly IFileWorker fileWorker;
        private readonly IFileWorker fileWorkerWithoutFile;
        private readonly string fakeFileContent;
        
        public FileWorkerTests()
        {
            var mockFileService = new Mock<IFileService>();
            var mockFileServiceWithoutFile = new Mock<IFileService>();
            var mockFibonacci = new Mock<ISequence>();
            fakeFileContent = "Hello world";
            var fibonacciSequence = new[] {0, 1, 1, 2, 3, 5, 8, 13};

            var fakeMemoryStream = new MemoryStream(Encoding.ASCII.GetBytes(fakeFileContent));
            
            mockFileService.Setup(f => f.Open(It.IsAny<string>()))
                .Returns(() => new StreamReader(fakeMemoryStream));
            mockFileServiceWithoutFile.Setup(f => f.Open(It.IsAny<string>()))
                .Throws<FileNotFoundException>();
            mockFibonacci.Setup(s => s[It.IsAny<int>()]).Returns(fibonacciSequence[It.IsAny<int>()]);
            
            fileWorker = new FileWorker(mockFileService.Object,mockFibonacci.Object);
            fileWorkerWithoutFile = new FileWorker(mockFileServiceWithoutFile.Object,mockFibonacci.Object);
        }

        [Fact]
        public void GetFibonacciLines()
        {
            var expected = fakeFileContent;
            var lines = fileWorker.GetFibonacciLines("Some file path");
            
            Assert.Equal(expected,lines[0]);
        }
        
        [Fact]
        public void GetFibonacciLinesFail()
        {
            Assert.Throws<FileNotFoundException>(() => fileWorkerWithoutFile.GetFibonacciLines("Some wrong path"));
        }
    }
}