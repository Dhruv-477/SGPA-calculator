using SGPACalculator;

// Check if we should run tests
if (args.Length > 0 && args[0].ToLower() == "test")
{
    CalculatorTests.RunTests();
}
else
{
    // Main entry point for the SGPA & CGPA Calculator
    ConsoleInterface.Run();
}
