using System;
using System.Collections.Generic;
using System.Text;
using Sequences.Library;
using Xunit;

namespace Sequences.Tests
{
    public class StringSequenceTests
    {
        // these attributes like [Fact] tell xUnit that this is a test method.

        [Theory]
        [InlineData("abc")]
        [InlineData("")]
        [InlineData("😊😂😁")]
        [InlineData(null)]
        public void AddShouldAdd(string item)
        {
            // arrange (any setup necessary to prepare for the behavior to test)
            var seq = new StringSequence();

            // act (do the thing you want to test)
            seq.Add(item);

            // assert (verify that the behavior was as expected)
            Assert.Equal(expected: item, actual: seq[0]);
        }

        [Fact]
        public void AddShouldAddInConsistentOrder()
        {
            // arrange
            var seq = new StringSequence();

            // act
            seq.Add("abc");
            seq.Add("def");

            // assert
            Assert.Equal(expected: "abc", actual: seq[0]);
            Assert.Equal(expected: "def", actual: seq[1]);
        }

        [Fact]
        public void AccessOutOfBoundsShouldThrow()
        {
            // arrange
            var seq = new StringSequence();

            // act, assert (that an exception is thrown when some code runs.)
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() =>
            {
                var x = seq[0];
            });
        }

        [Fact]
        public void LongestStringShouldReturnLongest()
        {
            // arrange
            var seq = new StringSequence();
            seq.Add("");
            seq.Add("abc");
            seq.Add("0123456789");
            seq.Add("a");

            // act
            var longest = seq.LongestString();

            // assert
            Assert.Equal("0123456789", longest);
        }
    }
}
