using System.Globalization;

namespace SGPACalculator;

/// <summary>
/// Console interface for the SGPA/CGPA calculator
/// </summary>
public static class ConsoleInterface
{
    /// <summary>
    /// Main entry point for the console interface
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("   SGPA & CGPA Calculator");
        Console.WriteLine("=================================");
        Console.WriteLine();

        try
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine() ?? "";
            
            if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Student name cannot be empty.");
                return;
            }

            var student = new Student(studentName);
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add semester data");
                Console.WriteLine("2. View SGPA for specific semester");
                Console.WriteLine("3. View CGPA and summary");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option (1-4): ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddSemesterData(student);
                        break;
                    case "2":
                        ViewSGPA(student);
                        break;
                    case "3":
                        ViewCGPAAndSummary(student);
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using SGPA & CGPA Calculator!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void AddSemesterData(Student student)
    {
        try
        {
            Console.Write("Enter semester number: ");
            if (!int.TryParse(Console.ReadLine(), out int semesterNumber) || semesterNumber <= 0)
            {
                Console.WriteLine("Invalid semester number. Please enter a positive integer.");
                return;
            }

            // Check if semester already exists
            if (student.Semesters.Any(s => s.SemesterNumber == semesterNumber))
            {
                Console.WriteLine($"Semester {semesterNumber} already exists. Data will be replaced.");
                student.Semesters.RemoveAll(s => s.SemesterNumber == semesterNumber);
            }

            var semester = new Semester(semesterNumber);

            Console.Write("Enter number of subjects: ");
            if (!int.TryParse(Console.ReadLine(), out int subjectCount) || subjectCount <= 0)
            {
                Console.WriteLine("Invalid number of subjects. Please enter a positive integer.");
                return;
            }

            for (int i = 1; i <= subjectCount; i++)
            {
                Console.WriteLine($"\nSubject {i}:");
                
                Console.Write("  Subject name: ");
                string subjectName = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(subjectName))
                {
                    Console.WriteLine("  Subject name cannot be empty. Skipping this subject.");
                    continue;
                }

                Console.Write("  Grade point (0-10): ");
                if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double gradePoint) || 
                    gradePoint < 0 || gradePoint > 10)
                {
                    Console.WriteLine("  Invalid grade point. Please enter a value between 0 and 10. Skipping this subject.");
                    continue;
                }

                Console.Write("  Credit hours: ");
                if (!int.TryParse(Console.ReadLine(), out int creditHours) || creditHours <= 0)
                {
                    Console.WriteLine("  Invalid credit hours. Please enter a positive integer. Skipping this subject.");
                    continue;
                }

                semester.AddSubject(subjectName, gradePoint, creditHours);
                Console.WriteLine($"  Added: {subjectName} ({gradePoint} GP, {creditHours} CH)");
            }

            if (semester.Subjects.Any())
            {
                student.AddSemester(semester);
                Console.WriteLine($"\nSemester {semesterNumber} added successfully!");
                Console.WriteLine($"SGPA for Semester {semesterNumber}: {semester.CalculateSGPA():F2}");
            }
            else
            {
                Console.WriteLine("No valid subjects were added. Semester not saved.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding semester data: {ex.Message}");
        }
    }

    private static void ViewSGPA(Student student)
    {
        if (!student.Semesters.Any())
        {
            Console.WriteLine("No semester data available. Please add some semesters first.");
            return;
        }

        Console.WriteLine("\nAvailable semesters:");
        foreach (var semester in student.Semesters.OrderBy(s => s.SemesterNumber))
        {
            Console.WriteLine($"  Semester {semester.SemesterNumber}");
        }

        Console.Write("Enter semester number to view SGPA: ");
        if (!int.TryParse(Console.ReadLine(), out int semesterNumber))
        {
            Console.WriteLine("Invalid semester number.");
            return;
        }

        try
        {
            double sgpa = student.CalculateSGPA(semesterNumber);
            var semester = student.Semesters.First(s => s.SemesterNumber == semesterNumber);
            
            Console.WriteLine($"\nSemester {semesterNumber} Details:");
            Console.WriteLine("==================");
            foreach (var subject in semester.Subjects)
            {
                Console.WriteLine($"  {subject}");
            }
            Console.WriteLine($"Total Credit Hours: {semester.TotalCreditHours}");
            Console.WriteLine($"SGPA: {sgpa:F2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ViewCGPAAndSummary(Student student)
    {
        if (!student.Semesters.Any())
        {
            Console.WriteLine("No semester data available. Please add some semesters first.");
            return;
        }

        try
        {
            Console.WriteLine("\n" + student.GetSemesterSummary());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating CGPA: {ex.Message}");
        }
    }
}