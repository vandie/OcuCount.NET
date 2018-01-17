using System;
using Xunit;
using ocucount;

namespace tests
{
    public class OcucountTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(2000)]
        [InlineData(500)]
        [InlineData(90)]
        public void TestCountValue(int sc)
        {
            ocucount.Count c = new ocucount.Count("bill", sc);
            Assert.Equal(c.num, sc);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2000)]
        [InlineData(500)]
        [InlineData(90)]
        public void TestCountIncrease(int sc)
        {
            ocucount.Count c = new ocucount.Count("bill", 0);
            for (int i = 0; i < sc; i++){
                c.increaseCount();
            }
            Assert.Equal(c.num, sc);
        }

        [Theory]
        [InlineData("I really like pie",4)]
        [InlineData("I really don't like pie", 4)]
        [InlineData("Ted knows why", 3)]
        public void TestCounterLength(string text,int expected){
            ocucount.Counter c = new ocucount.Counter(text);
            Assert.Equal(c.dict.Count,expected);
        }

        [Theory]
        [InlineData("I really like pie", "really", 1)]
        [InlineData("I really really don't like pie", "really", 2)]
        [InlineData("Ted knows why", "ted", 1)]
        [InlineData("Ted knows why, don't you ted?", "ted", 2)]
        public void TestCounter(string text, string word, int expected)
        {
            ocucount.Counter c = new ocucount.Counter(text);
            Assert.Equal(c.getWordCount(word).num, expected);
        }
    }
}
