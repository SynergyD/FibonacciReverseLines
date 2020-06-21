using Autofac;

namespace ReverseFibonacciLines
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IReverseFibonacciLinesApp>();
                
                if (args.Length < 1)
                {
                    app.Error();
                }
                else
                {
                    app.Run(args[0]);
                }
            }
        }
    }
}