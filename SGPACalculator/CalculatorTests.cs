using SGPACalculator;

namespace SGPACalculator;

/// <summary>
/// Simple test program to validate SGPA and CGPA calculations
/// </summary>
public static class CalculatorTests
{
    public static void RunTests()
    {
        Console.WriteLine("Running SGPA/CGPA Calculator Tests...");
        Console.WriteLine("=====================================");

        TestSGPACalculation();
        TestCGPACalculation();
        TestValidation();

        Console.WriteLine("\nAll tests completed!");
    }

    private static void TestSGPACalculation()
    {
        Console.WriteLine("\n1. Testing SGPA Calculation:");
        
        // Create a test semester
        var semester = new Semester(1);
        semester.AddSubject("Mathematics", 9.0, 4);
        semester.AddSubject("Physics", 8.5, 3);
        semester.AddSubject("Chemistry", 7.0, 3);
        semester.AddSubject("Programming", 9.5, 4);
        
        double expectedSGPA = (9.0*4 + 8.5*3 + 7.0*3 + 9.5*4) / (4+3+3+4);
        double actualSGPA = semester.CalculateSGPA();
        
        Console.WriteLine($"   Expected SGPA: {expectedSGPA:F2}");
        Console.WriteLine($"   Actual SGPA: {actualSGPA:F2}");
        Console.WriteLine($"   Test Result: {(Math.Abs(expectedSGPA - actualSGPA) < 0.01 ? "PASS" : "FAIL")}");
    }

    private static void TestCGPACalculation()
    {
        Console.WriteLine("\n2. Testing CGPA Calculation:");
        
        // Create a test student
        var student = new Student("Test Student");
        
        // Semester 1
        var sem1 = new Semester(1);
        sem1.AddSubject("Math I", 9.0, 4);
        sem1.AddSubject("Physics I", 8.0, 3);
        sem1.AddSubject("Programming I", 9.5, 4);
        student.AddSemester(sem1);
        
        // Semester 2
        var sem2 = new Semester(2);
        sem2.AddSubject("Math II", 8.5, 4);
        sem2.AddSubject("Physics II", 7.5, 3);
        sem2.AddSubject("Programming II", 9.0, 4);
        student.AddSemester(sem2);
        
        double totalWeightedGP = (9.0*4 + 8.0*3 + 9.5*4) + (8.5*4 + 7.5*3 + 9.0*4);
        double totalCredits = (4+3+4) + (4+3+4);
        double expectedCGPA = totalWeightedGP / totalCredits;
        double actualCGPA = student.CalculateCGPA();
        
        Console.WriteLine($"   Expected CGPA: {expectedCGPA:F2}");
        Console.WriteLine($"   Actual CGPA: {actualCGPA:F2}");
        Console.WriteLine($"   Test Result: {(Math.Abs(expectedCGPA - actualCGPA) < 0.01 ? "PASS" : "FAIL")}");
    }

    private static void TestValidation()
    {
        Console.WriteLine("\n3. Testing Input Validation:");
        
        bool testPassed = true;
        
        try
        {
            // Test invalid grade point
            var subject = new Subject("Invalid", 11.0, 3);
            testPassed = false;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("   ✓ Grade point validation works");
        }
        
        try
        {
            // Test invalid credit hours
            var subject = new Subject("Invalid", 8.0, -1);
            testPassed = false;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("   ✓ Credit hours validation works");
        }
        
        try
        {
            // Test empty subject name
            var subject = new Subject("", 8.0, 3);
            testPassed = false;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("   ✓ Subject name validation works");
        }
        
        Console.WriteLine($"   Validation Test Result: {(testPassed ? "PASS" : "FAIL")}");
    }
}