namespace FizzBuzzApp;
public class FizzBuzz
{
    private const int FizzDivisor = 3;
    private const int BuzzDivisor = 5;
    
    private readonly int _number;
    
    public FizzBuzz(int number)
    {
        _number = number;
    }
    
    public string GetResult()
    {
        var result = string.Empty;
        if (IsDivisibleBy(_number, FizzDivisor))
        {
            result += "Fizz";
        }
        if (IsDivisibleBy(_number, BuzzDivisor))
        {
            result += "Buzz";
        }
        return string.IsNullOrEmpty(result) ? _number.ToString() : result;
    }
    
    private static bool IsDivisibleBy(int number, int divisor)
    {
        return number % divisor == 0;
    }
}