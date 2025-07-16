namespace SGPACalculator;

/// <summary>
/// Represents a semester containing multiple subjects
/// </summary>
public class Semester
{
    public int SemesterNumber { get; set; }
    public List<Subject> Subjects { get; set; }

    public Semester(int semesterNumber)
    {
        if (semesterNumber <= 0)
            throw new ArgumentException("Semester number must be positive", nameof(semesterNumber));

        SemesterNumber = semesterNumber;
        Subjects = new List<Subject>();
    }

    /// <summary>
    /// Adds a subject to this semester
    /// </summary>
    public void AddSubject(Subject subject)
    {
        if (subject == null)
            throw new ArgumentNullException(nameof(subject));

        Subjects.Add(subject);
    }

    /// <summary>
    /// Adds a subject to this semester
    /// </summary>
    public void AddSubject(string name, double gradePoint, int creditHours)
    {
        AddSubject(new Subject(name, gradePoint, creditHours));
    }

    /// <summary>
    /// Calculates the total credit hours for this semester
    /// </summary>
    public int TotalCreditHours => Subjects.Sum(s => s.CreditHours);

    /// <summary>
    /// Calculates the total weighted grade points for this semester
    /// </summary>
    public double TotalWeightedGradePoints => Subjects.Sum(s => s.WeightedGradePoints);

    /// <summary>
    /// Calculates the SGPA (Semester Grade Point Average) for this semester
    /// </summary>
    public double CalculateSGPA()
    {
        if (!Subjects.Any())
            throw new InvalidOperationException("Cannot calculate SGPA for a semester with no subjects");

        return TotalWeightedGradePoints / TotalCreditHours;
    }

    public override string ToString()
    {
        return $"Semester {SemesterNumber}: {Subjects.Count} subjects, {TotalCreditHours} credit hours, SGPA: {CalculateSGPA():F2}";
    }
}