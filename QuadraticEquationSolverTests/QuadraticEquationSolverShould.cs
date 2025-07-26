using QuadraticEquationSolver;

namespace QuadraticEquationSolverTests;

public class QuadraticEquationSolverShould
{
    [Theory]
    [InlineData(1, -3, 2, "[2, 1]")]
    [InlineData(1, 2, 1, "[-1]")]
    [InlineData(1, 1, 1, "[]")]
    public void ReturnTwoRootsWhenDiscriminantIsPositive(double a, double b, double c, string expectedResult)
    {
        var equation = new QuadraticEquation(a, b, c);

        var actualResult = equation.Solve();
        
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Fact]
    public void ThrowExceptionWhenNotQuadraticEquation()
    {
        // Arrange
        double a = 0;
        double b = 2;
        double c = 1;
        
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new QuadraticEquation(a, b, c));
        
        Assert.Contains("Not a quadratic equation, a should not be 0.", exception.Message);
    }
}