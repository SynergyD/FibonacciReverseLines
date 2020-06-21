using System;
using ReverseFibonacciLines.Models;
using Xunit;

namespace ReverseFibonacciLinesTests
{
    public class FibonacciSequenceTests
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(14,377)]
        [InlineData(2,1)]
        [InlineData(21,10946)]
        public void GetNumberOfSequence_ShouldCorrectly(int index,int expected)
        {
            var sequence = new FibonacciSequence();

            var actual = sequence[index];
            
            Assert.Equal(expected,actual);
        }
        
        
        [Theory]
        [InlineData(-1)]
        [InlineData(50)]
        [InlineData(-50)]
        [InlineData(100)]
        public void GetNumberOfSequence_IncorrectIndex_OutOfRange(int index)
        {
            var sequence = new FibonacciSequence();
            
            Assert.Throws<IndexOutOfRangeException>( () => sequence[index]);
        }
    }
}