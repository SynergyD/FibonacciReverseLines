using System;
using ReverseFibonacciLines.Extensions;
using Xunit;

namespace ReverseFibonacciLinesTests.ExtensionsTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Hello, world","dlrow ,olleH")]
        [InlineData("H","H")]
        [InlineData("H "," H")]
        [InlineData("\r \t \n h    ","    h \n \t \r")]
        public void Reverse_GetString_ReturnReverseString(string inputString, string expected)
        {
            var actual = inputString.Reverse();
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Reverse_GetNull_ShouldFail()
        {
            string line = null;
            
            Assert.Throws<ArgumentNullException>( () => line.Reverse());
        }
    }
}