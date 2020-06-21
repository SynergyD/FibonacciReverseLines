using System;
using System.Collections.Generic;
using System.Text;
using ReverseFibonacciLines.Models.Interfaces;
using ReverseFibonacciLines.Services.Interfaces;

namespace ReverseFibonacciLines.Models
{
    public class FileWorker : IFileWorker
    {
        public Encoding Encoding { get; set; } = Encoding.ASCII;

        private readonly IFileService fileService;
        private readonly ISequence sequence;
        
        public FileWorker(IFileService fileService, ISequence sequence)
        {
            this.fileService = fileService;
            this.sequence = sequence;
        }

        public string[] GetFibonacciLines(string filePath)
        {
            var lines = new List<string>();
            var currentLine = 1;
            var fibonacciLine = 1;
            var index = 2;
            
            using (var streamReader = fileService.Open(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    if (currentLine == fibonacciLine)
                    {
                        lines.Add(streamReader.ReadLine());
                        
                        fibonacciLine = sequence[++index];
                        currentLine++;
                        continue;
                    }
                    
                    currentLine++;
                    streamReader.ReadLine();
                }
            }
            
            return lines.ToArray();
        }

        public void FillFileByReverseLines(string[] lines, string path, bool isAppendToFile)
        {
            if (lines.Length == 0)
            {
                throw new ArgumentNullException(nameof(lines),"No lines in file");
            }

            var currentLine = 0;
            
            using (var streamWriter = fileService.Open(path,isAppendToFile,Encoding))
            {
                do
                {
                    streamWriter.WriteLine(lines[currentLine]);
                    currentLine++;
                } 
                while (currentLine < lines.Length);
            }
        }
    }
}