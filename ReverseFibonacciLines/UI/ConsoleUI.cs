using System;
using ReverseFibonacciLines.UI.Interfaces;

namespace ReverseFibonacciLines.UI
{
    public class ConsoleUI : IUserInterface
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}