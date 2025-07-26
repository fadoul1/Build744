namespace PhoneNumberParser;

public class NorthAmericaPhoneNumber
{
    private const int RequiredLength = 10;

    private string _areaCode;
    private string _centralOfficeCode;
    private string _lineNumber;
    public NorthAmericaPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != RequiredLength || !IsAllDigit(phoneNumber))
        {
            throw new ArgumentException("The number must contain exactly 10 digits.");
        }
        _areaCode = phoneNumber[..3];
        _centralOfficeCode = phoneNumber[3..6];
        _lineNumber = phoneNumber[6..];
    }

    private static bool IsAllDigit(string phoneNumber)
    {
        return phoneNumber.All(char.IsDigit);
    }

    public override string ToString()
    {
        return $"({_areaCode}){_centralOfficeCode}-{_lineNumber}";
    }
}