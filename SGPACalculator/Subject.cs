namespace SGPACalculator;

/// <summary>
/// Represents a subject with its grade point and credit hours
/// </summary>
public class Subject
{
    public string Name { get; set; }
    public double GradePoint { get; set; }
    public int CreditHours { get; set; }

    public Subject(string name, double gradePoint, int creditHours)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Subject name cannot be empty", nameof(name));
        
        if (gradePoint < 0 || gradePoint > 10)
            throw new ArgumentException("Grade point must be between 0 and 10", nameof(gradePoint));
        
        if (creditHours <= 0)
            throw new ArgumentException("Credit hours must be positive", nameof(creditHours));

        Name = name;
        GradePoint = gradePoint;
        CreditHours = creditHours;
    }

    /// <summary>
    /// Calculates the weighted grade points (Grade Point × Credit Hours)
    /// </summary>
    public double WeightedGradePoints => GradePoint * CreditHours;

    public override string ToString()
    {
        return $"{Name}: {GradePoint} GP × {CreditHours} CH = {WeightedGradePoints}";
    }
}