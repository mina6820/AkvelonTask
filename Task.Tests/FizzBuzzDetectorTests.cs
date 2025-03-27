using AkvelonTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Tests
{
    public class FizzBuzzDetectorTests
    {
        private readonly FizzBuzzDetector _detector;

        public FizzBuzzDetectorTests()
        {
            _detector = new FizzBuzzDetector();
        }

        [Fact]
        public void TestExampleCase()
        {
            string input =
                "Mary had a little lamb\n" +
                "Little lamb, little lamb\n" +
                "Mary had a little lamb\n" +
                "It's fleece was white as snow";

            string expectedOutput =
                "Mary had Fizz little Buzz\n" +
                "Fizz lamb, little Fizz\n" +
                "Buzz had Fizz little lamb\n" +
                "FizzBuzz fleece was Fizz as Buzz";
            FizzBuzzResult result = _detector.GetOverlappings(input);
            Assert.Equal(expectedOutput, result.Output);
            Assert.Equal(9, result.Count);
        }

        [Fact]
        public void TestOnlyAlphanumericWords()
        {
            string input = "one two three four five six seven";

            string expectedOutput = "one two Fizz four Buzz Fizz seven";
            FizzBuzzResult result = _detector.GetOverlappings(input);
            Assert.Equal(expectedOutput, result.Output);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void TestWithPunctuation()
        {
            string input = "Hello, world! This is a test.";

            string expectedOutput = "Hello, world! Fizz is Buzz Fizz";
            FizzBuzzResult result = _detector.GetOverlappings(input);
            Assert.Equal(expectedOutput, result.Output);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void TestNonAlphanumericTokens()
        {
            string input = "!!! *** ###";

            FizzBuzzResult result = _detector.GetOverlappings(input);
            Assert.Equal(input, result.Output);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void TestMinimumLengthInput()
        {
            string input = "A1 b2 c3 d4 e5 f6 g7";

            string expectedOutput = "A1 b2 Fizz d4 Buzz Fizz g7";
            FizzBuzzResult result = _detector.GetOverlappings(input);
            Assert.Equal(expectedOutput, result.Output);
            Assert.Equal(3, result.Count);
        }
        [Fact]
        public void TestInvalidInputLength()
        {
            string tooShortInput = "abc";
            Assert.Throws<ArgumentException>(() => _detector.GetOverlappings(tooShortInput));

            string tooLongInput = new string('a', 101);
            Assert.Throws<ArgumentException>(() => _detector.GetOverlappings(tooLongInput));
        }
    }
}
