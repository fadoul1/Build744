using PhoneNumberParser;

namespace PhoneNumberParserTests;

public class PhoneNumberShould
{
    private const string ExpectedErrorMessage = "The number must contain exactly 10 digits.";
    private NorthAmericaPhoneNumber _northAmericaPhoneNumber;

    [Theory]
    [InlineData(null)]
    [InlineData("0123")]
    [InlineData("123ea6789d")]
    public void ThrowArgumentExceptionWhenPhoneNumberIsInvalid(string invalidPhoneNumber)
    {
        var exception = Assert.Throws<ArgumentException>(() => 
            _northAmericaPhoneNumber = new NorthAmericaPhoneNumber(invalidPhoneNumber));
        
        Assert.Equal(ExpectedErrorMessage, exception.Message);
    }
    
    [Theory]
    [InlineData("1234567890", "(123)456-7890")]
    [InlineData("5145551234", "(514)555-1234")]
    [InlineData("2120007890", "(212)000-7890")]
    public void ParseTheGivenPhoneNumberToNorthAmericaPhoneNumberformat(string givenPhoneNumber, string expectedFormatedPhoneNumber)
    {
        _northAmericaPhoneNumber = new NorthAmericaPhoneNumber(givenPhoneNumber);
        
        Assert.Equal(expectedFormatedPhoneNumber, _northAmericaPhoneNumber.ToString());
    }
}