namespace SGPACalculator;

/// <summary>
/// Represents a student with multiple semesters and provides CGPA calculation
/// </summary>
public class Student
{
    public string Name { get; set; }
    public List<Semester> Semesters { get; set; }

    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Student name cannot be empty", nameof(name));

        Name = name;
        Semesters = new List<Semester>();
    }

    /// <summary>
    /// Adds a semester to this student's record
    /// </summary>
    public void AddSemester(Semester semester)
    {
        if (semester == null)
            throw new ArgumentNullException(nameof(semester));

        Semesters.Add(semester);
    }

    /// <summary>
    /// Gets the total credit hours across all semesters
    /// </summary>
    public int TotalCreditHours => Semesters.Sum(s => s.TotalCreditHours);

    /// <summary>
    /// Gets the total weighted grade points across all semesters
    /// </summary>
    public double TotalWeightedGradePoints => Semesters.Sum(s => s.TotalWeightedGradePoints);

    /// <summary>
    /// Calculates the CGPA (Cumulative Grade Point Average) across all semesters
    /// </summary>
    public double CalculateCGPA()
    {
        if (!Semesters.Any())
            throw new InvalidOperationException("Cannot calculate CGPA for a student with no semesters");

        return TotalWeightedGradePoints / TotalCreditHours;
    }

    /// <summary>
    /// Calculates the SGPA for a specific semester
    /// </summary>
    public double CalculateSGPA(int semesterNumber)
    {
        var semester = Semesters.FirstOrDefault(s => s.SemesterNumber == semesterNumber);
        if (semester == null)
            throw new ArgumentException($"Semester {semesterNumber} not found", nameof(semesterNumber));

        return semester.CalculateSGPA();
    }

    /// <summary>
    /// Gets a summary of all semesters with their SGPAs
    /// </summary>
    public string GetSemesterSummary()
    {
        if (!Semesters.Any())
            return "No semesters recorded";

        var summary = $"Student: {Name}\n";
        summary += "=" + new string('=', Name.Length + 8) + "\n\n";

        foreach (var semester in Semesters.OrderBy(s => s.SemesterNumber))
        {
            summary += $"Semester {semester.SemesterNumber}:\n";
            foreach (var subject in semester.Subjects)
            {
                summary += $"  - {subject}\n";
            }
            summary += $"  SGPA: {semester.CalculateSGPA():F2}\n";
            summary += $"  Total Credits: {semester.TotalCreditHours}\n\n";
        }

        summary += $"Overall CGPA: {CalculateCGPA():F2}\n";
        summary += $"Total Credits: {TotalCreditHours}\n";

        return summary;
    }

    public override string ToString()
    {
        return $"{Name}: {Semesters.Count} semesters, CGPA: {CalculateCGPA():F2}";
    }
}