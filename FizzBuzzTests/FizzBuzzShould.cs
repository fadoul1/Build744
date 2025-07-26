using FizzBuzzApp;
namespace FizzBuzzTests;

public class FizzBuzzShould
{
    [Theory]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    [InlineData(6, "Fizz")]
    [InlineData(12, "Fizz")]
    [InlineData(20, "Buzz")]
    [InlineData(25, "Buzz")]
    [InlineData(1, "1")]
    [InlineData(4, "4")]
    public void ReturnExpectedOutputOnVariousInputs(int input, string expected)
    {
        var fizzBuzz = new FizzBuzz(input);
        var result = fizzBuzz.GetResult();
        
        Assert.Equal(expected, result);
    }
}