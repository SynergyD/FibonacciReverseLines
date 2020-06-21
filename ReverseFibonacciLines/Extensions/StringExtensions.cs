using System;

namespace ReverseFibonacciLines.Extensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException();
            }

            if (line.Length == 1)
            {
                return line;
            }
            
            var charArray = line.ToCharArray();
            
            for (var i = 0; i < charArray.Length / 2; i++)
            {
                var temp = charArray[i];
                charArray[i] = charArray[charArray.Length - i - 1];
                charArray[charArray.Length - i - 1] = temp;
            }
            
            return new string(charArray);
        }
    }
}