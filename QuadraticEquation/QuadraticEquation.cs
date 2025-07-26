namespace QuadraticEquationSolver;

public class QuadraticEquation
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;
    
    public QuadraticEquation(double a, double b, double c)
    {
        if (a == 0)
        {
            throw new ArgumentException("Not a quadratic equation, a should not be 0.");
        }
            
        _a = a;
        _b = b;
        _c = c;
    }
    
    public string Solve()
    {
        var discriminant = CalculateDiscriminant();
        switch (discriminant)
        {
            case > 0:
            {
                var sqrtDiscriminant = Math.Sqrt(discriminant);
                var x1 = (-_b + sqrtDiscriminant) / (2 * _a);
                var x2 = (-_b - sqrtDiscriminant) / (2 * _a);

                return $"[{x1}, {x2}]";
            }
            case 0:
            {
                var x = -_b / (2 * _a);
                return $"[{x}]";
            }
            default:
                return "[]";
        }
    }
    
    private double CalculateDiscriminant()
    {
        return (_b * _b) - 4 * (_a * _c);
    }
    
    public override string ToString()
    {
        return $"{_a}x² + {_b}x + {_c} = 0";
    }
}