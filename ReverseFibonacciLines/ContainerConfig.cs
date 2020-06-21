using Autofac;
using ReverseFibonacciLines.Models;
using ReverseFibonacciLines.Models.Interfaces;
using ReverseFibonacciLines.Services;
using ReverseFibonacciLines.Services.Interfaces;
using ReverseFibonacciLines.UI;
using ReverseFibonacciLines.UI.Interfaces;

namespace ReverseFibonacciLines
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FibonacciSequence>().As<ISequence>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<FileWorker>().As<IFileWorker>();
            builder.RegisterType<ReverseFibonacciLinesApp>().As<IReverseFibonacciLinesApp>();
            builder.RegisterType<ConsoleUI>().As<IUserInterface>();
            
            return builder.Build();
        }
    }
}